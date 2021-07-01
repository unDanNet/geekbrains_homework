namespace lesson_4
{
    public static class Utils
    {
        /// <summary>
        /// Get the amount of digits in the specified number.
        /// </summary>
        /// <param name="number">The number to get amount of digits for.</param>
        public static int GetNumberLength(int number)
        {
            var length = 0;
            while (number > 0)
            {
                number /= 10;
                length++;
            }

            return length;
        }

        
        public static string Replace(this string str, int startIndex, string val)
        {
            var modified = "";

            var j = 0;
            for (var i = 0; i < str.Length; i++)
            {
                var symbol = str[i];
                
                if (i >= startIndex && i < startIndex + val.Length)
                {
                    symbol = val[j];
                    j++;
                }

                modified += symbol;
            }

            return modified;
        }


        public static string Replace(this string str, int startIndex, int endIndex, char symbol)
        {
            var modified = "";

            for (var i = 0; i < str.Length; i++)
            {
                var s = str[i];

                if (i >= startIndex && i < endIndex)
                {
                    s = symbol;
                }

                modified += s;
            }

            return modified;
        }
    }
}