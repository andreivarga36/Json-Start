namespace Json.Classes
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var indexOfDot = input.IndexOf('.');
            var indexOfExponent = input.IndexOfAny("eE".ToCharArray());

            return IsInteger(Integer(input, indexOfDot, indexOfExponent))
               && IsFraction(Fraction(input, indexOfDot, indexOfExponent))
               && IsExponent(Exponent(input, indexOfExponent));
        }

        private static string Integer(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot > 0)
            {
                return input[..indexOfDot];
            }

            if (indexOfExponent > 0)
            {
                return input[..indexOfExponent];
            }

            return input;
        }

        private static string Fraction(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot > 0 && indexOfDot < indexOfExponent)
            {
                return input[indexOfDot..indexOfExponent];
            }

            if (indexOfDot > indexOfExponent)
            {
                return input[indexOfDot..];
            }

            return "";
        }

        private static string Exponent(string input, int indexOfExponent)
        {
            return indexOfExponent >= 0 ? input[indexOfExponent..] : "";
        }

        private static bool IsInteger(string integer)
        {
            if (integer.Length > 1 && integer.StartsWith('0'))
            {
                return false;
            }

            if (integer.StartsWith('-'))
            {
                integer = integer[1..];
            }

            return ContainsOnlyDigits(integer);
        }

        private static bool IsFraction(string fraction)
        {
            return string.IsNullOrEmpty(fraction) || ContainsOnlyDigits(fraction[1..]);
        }

        private static bool IsExponent(string exponent)
        {
            if (string.IsNullOrEmpty(exponent))
            {
                return true;
            }

            exponent = exponent[1..];
            exponent = exponent.StartsWith('-') || exponent.StartsWith('+') ? exponent[1..] : exponent;

            return ContainsOnlyDigits(exponent);
        }

        private static bool ContainsOnlyDigits(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
            }

            return input.Length > 0;
        }
    }
}