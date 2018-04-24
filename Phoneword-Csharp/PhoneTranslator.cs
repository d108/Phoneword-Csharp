using System.Text;

namespace PhonewordCsharp
{
    public static class PhoneTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return "";
            }
            raw = raw.ToUpperInvariant();
            var newNumber = new StringBuilder();
            foreach (var chr in raw)
            {
                if (" -0123456789".Contains(chr))
                {
                    newNumber.Append(chr);
                }
                else
                {
                    var result = TranslateToNumber(chr);
                    if (result != null)
                    {
                        newNumber.Append(result);
                    }
                    // otherwise we've skipped a non-numeric char
                }
            }
            return newNumber.ToString();
        }

        private static bool Contains(this string keyString,
                                     char chr)
        {
            return keyString.IndexOf(chr) >= 0;
        }

        private static int? TranslateToNumber(char chr)
        {
            if ("ABC".Contains(chr))
            {
                return 2;
            }
            if ("DEF".Contains(chr))
            {
                return 3;
            }
            if ("GHI".Contains(chr))
            {
                return 4;
            }
            if ("JKL".Contains(chr))
            {
                return 5;
            }
            if ("MNO".Contains(chr))
            {
                return 6;
            }
            if ("PQRS".Contains(chr))
            {
                return 7;
            }
            if ("TUV".Contains(chr))
            {
                return 8;
            }
            if ("WXYZ".Contains(chr))
            {
                return 9;
            }
            return null;
        }
    }
}
