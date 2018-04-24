using System;
using Foundation;
using UIKit;

namespace PhonewordCsharp
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var translatedNumber = "";
            TranslateButton.TouchUpInside += (object sender,
                                              EventArgs evt) =>
            {
                // Convert the phone number with text to a number
                // using PhoneTranslator.cs
                translatedNumber =
                    PhoneTranslator.ToNumber(PhoneNumberText.Text);

                // Dismiss the keyboard if text field was tapped
                PhoneNumberText.ResignFirstResponder();

                if (translatedNumber == "")
                {
                    CallButton.SetTitle("Call",
                                        UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.SetTitle("Call " + translatedNumber,
                                        UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };
            CallButton.TouchUpInside += (object sender,
                                         EventArgs evt) =>
            {
                // Use URL handler with tel: prefix to invoke Apple's Phone app...
                var url = new NSUrl("tel:" + translatedNumber);
                if (UIApplication.SharedApplication.OpenUrl(url))
                {
                    return;
                }

                // ...otherwise show an alert dialog
                var alert =
                    UIAlertController.Create("Not supported",
                                             "Scheme 'tel:' is not supported on this device",
                                             UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok",
                                UIAlertActionStyle.Default,
                                null));
                PresentViewController(alert,
                                      true,
                                      null);
            };
        }
    }
}
