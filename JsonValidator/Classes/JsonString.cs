namespace Json.Classes
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !string.IsNullOrEmpty(input) &&
                IsDoubleQuoted(input) &&
                !ContainControlCharacter(input) &&
                !ContainUnescapedCharacters(input);
        }

        private static bool IsDoubleQuoted(string input)
        {
            if (input == null)
            {
                return false;
            }

            const byte minRequiredLength = 2;

            return input.StartsWith('"') && input.EndsWith('"') && input.Length >= minRequiredLength;
        }

        private static bool ContainControlCharacter(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < ' ')
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainUnescapedCharacters(string input)
        {
            int step;

            for (int i = 0; i < input.Length - 1; i += step)
            {
                step = 1;

                if (input[i] == '\\' && input[i + 1] == 'u' && !IsValidUnicode(input, i + 1))
                {
                    return true;
                }

                if (input[i] == '\\' && !IsValidCharacter(input[i + 1], ref step))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValidCharacter(char character, ref int step)
        {
            const string escaped = "\"\\/bfnrtu";

            if (!escaped.Contains(character))
            {
                return false;
            }

            step++;
            return true;
        }

        private static bool IsValidUnicode(string input, int startIndex)
        {
            int requiredLength = startIndex + 5;

            for (int i = startIndex + 1; i < requiredLength; i++)
            {
                if (!char.IsDigit(input[i]) && !HexRange(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HexRange(char character)
        {
            return character >= 'a' && character <= 'f' || character >= 'A' && character <= 'F';
        }
    }
}
