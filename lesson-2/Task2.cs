namespace lesson_2
{
    public static class Task2
    {
        public static int BinarySearch(long[] array, long searchValue)
        {
            var min = 0;
            var max = array.Length - 1;

            while (min <= max)
            {
                var mid = (min + max) / 2;

                if (searchValue == array[mid])
                    return mid;

                if (searchValue <= array[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }

            return -1;
        }
    }
}