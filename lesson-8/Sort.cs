using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lesson_8
{
    public static class Sort
    {

        /// <summary>
        /// Check whether the collection of items of the specified type is sorted (by ascending or by descending).
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <param name="accessor">The expression the comparable values are taken by.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        /// <typeparam name="TCompare">The type of values the collection items must be sorted by.</typeparam>
        /// <returns>The value indicating whether the collection is sorted.</returns>
        public static bool IsSorted<TItem, TCompare>(this IEnumerable<TItem> collection, Func<TItem, TCompare> accessor, bool isAscendingOrder = true) 
            where TCompare : IComparable<TCompare>
        {
            // to check whether the collection is sorted we can just check whether the collection of accessed values is sorted
            var valuesCollection = collection.Select(accessor).ToList();

            if (valuesCollection.Count <= 1)
                return true;

            return IsSorted(valuesCollection, isAscendingOrder);
        }
        
        
        /// <summary>
        /// Check whether the collection of comparable items is sorted (by ascending or by descending).
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        /// <returns>The value indicating whether the collection is sorted.</returns>
        public static bool IsSorted<TItem>(this IEnumerable<TItem> collection, bool isAscendingOrder) where TItem : IComparable<TItem>
        {
            TItem[] array = collection.ToArray();

            if (array.Length <= 1)
                return true;
            
            
            for (var i = 0; i < array.Length - 1; i++)
            {
                TItem currentVal = array[i];
                TItem nextVal = array[i + 1];

                if (isAscendingOrder)
                {
                    if (currentVal.CompareTo(nextVal) > 0)
                        return false;
                }
                else
                {
                    if (currentVal.CompareTo(nextVal) < 0)
                        return false;
                }
            }
            
            return true;
        }
        
        
        /// <summary>
        /// Sort the array of comparable items using the quick sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="first">The start index of the array.</param>
        /// <param name="last">The end index of the array. </param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        public static void QuickSort<TItem>(TItem[] array, int first, int last, bool isAscendingOrder = true) where TItem : IComparable<TItem>
        {
            int i = first, j = last;
            TItem x = array[(first + last) / 2];

            do
            {
                if (isAscendingOrder)
                {
                    while (array[i].CompareTo(x) < 0)
                        i++;
                    
                    while (array[j].CompareTo(x) > 0)
                        j--;
                }
                else
                {
                    while (array[i].CompareTo(x) > 0)
                        i++;
                    
                    while (array[j].CompareTo(x) < 0)
                        j--;
                }
                

                if(i <= j)
                {
                    if (isAscendingOrder)
                    {
                        if (array[i].CompareTo(array[j]) > 0)
                        {
                            var tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;
                        }
                    }
                    else
                    {
                        if (array[i].CompareTo(array[j]) < 0)
                        {
                            var tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;
                        }
                    }
                    
                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                QuickSort(array, i, last, isAscendingOrder);
            if (first < j)
                QuickSort(array, first, j, isAscendingOrder);
        }


        /// <summary>
        /// Sort the array of items of the specified type using the quick sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="first">The start index of the array.</param>
        /// <param name="last">The end index of the array. </param>
        /// <param name="accessor">The expression the comparable values are taken by.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        /// <typeparam name="TCompare">The type of values the collection items must be sorted by.</typeparam>
        public static void QuickSort<TItem, TCompare>(TItem[] array, Func<TItem, TCompare> accessor , int first, int last, bool isAscendingOrder) 
            where TCompare : IComparable<TCompare>
        {
            int i = first, j = last;
            TCompare x = accessor(array[(first + last) / 2]);

            do
            {
                if (isAscendingOrder)
                {
                    while (accessor(array[i]).CompareTo(x) < 0)
                        i++;
                    while (accessor(array[j]).CompareTo(x) > 0)
                        j--;
                }
                else
                {
                    while (accessor(array[i]).CompareTo(x) > 0)
                        i++;
                    while (accessor(array[j]).CompareTo(x) < 0)
                        j--;
                }


                if(i <= j)
                {
                    if (isAscendingOrder)
                    {
                        if (accessor(array[i]).CompareTo(accessor(array[j])) > 0)
                        {
                            var tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;
                        } 
                    }
                    else
                    {
                        if (accessor(array[i]).CompareTo(accessor(array[j])) < 0)
                        {
                            var tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;
                        }
                    }

                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                QuickSort(array, accessor, i, last, isAscendingOrder);
            if (first < j)
                QuickSort(array, accessor, first, j, isAscendingOrder);
        }
        
        
        
        /// <summary>
        /// Sort the collection of items of the specified type using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="accessor">The expression the comparable values are taken by.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection or accessor is null.</exception>
        public static IEnumerable<TItem> BucketSort<TItem>(this IEnumerable<TItem> collection, Func<TItem, int> accessor, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            if (accessor is null)
                throw new ArgumentNullException(nameof(accessor));
            
            
            IEnumerable<TItem> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(accessor, isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, accessor, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum(accessor) / sortable.Count();
            
            var leftBucket = new List<TItem>(); // lesser then average or equal to it
            var rightBucket = new List<TItem>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (accessor(item) <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<TItem>();
            var rightCollectionPart = new List<TItem>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, accessor, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, accessor, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of items of the specified type using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="accessor">The expression the comparable values are taken by.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection or accessor is null.</exception>
        public static IEnumerable<TItem> BucketSort<TItem>(this IEnumerable<TItem> collection, Func<TItem, long> accessor, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            if (accessor is null)
                throw new ArgumentNullException(nameof(accessor));
            
            
            IEnumerable<TItem> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(accessor, isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, accessor, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum(accessor) / sortable.Count();
            
            var leftBucket = new List<TItem>(); // lesser then average or equal to it
            var rightBucket = new List<TItem>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (accessor(item) <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<TItem>();
            var rightCollectionPart = new List<TItem>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, accessor, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, accessor, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of items of the specified type using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="accessor">The expression the comparable values are taken by.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection or accessor is null.</exception>
        public static IEnumerable<TItem> BucketSort<TItem>(this IEnumerable<TItem> collection, Func<TItem, decimal> accessor, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            if (accessor is null)
                throw new ArgumentNullException(nameof(accessor));
            
            
            IEnumerable<TItem> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(accessor, isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, accessor, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum(accessor) / sortable.Count();
            
            var leftBucket = new List<TItem>(); // lesser then average or equal to it
            var rightBucket = new List<TItem>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (accessor(item) <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<TItem>();
            var rightCollectionPart = new List<TItem>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, accessor, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, accessor, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of items of the specified type using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="accessor">The expression the comparable values are taken by.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection or accessor is null.</exception>
        public static IEnumerable<TItem> BucketSort<TItem>(this IEnumerable<TItem> collection, Func<TItem, float> accessor, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            if (accessor is null)
                throw new ArgumentNullException(nameof(accessor));
            
            
            IEnumerable<TItem> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(accessor, isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, accessor, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum(accessor) / sortable.Count();
            
            var leftBucket = new List<TItem>(); // lesser then average or equal to it
            var rightBucket = new List<TItem>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (accessor(item) <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<TItem>();
            var rightCollectionPart = new List<TItem>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, accessor, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, accessor, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of items of the specified type using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="accessor">The expression the comparable values are taken by.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <typeparam name="TItem">The type of items of the collection.</typeparam>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection or accessor is null.</exception>
        public static IEnumerable<TItem> BucketSort<TItem>(this IEnumerable<TItem> collection, Func<TItem, double> accessor, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            if (accessor is null)
                throw new ArgumentNullException(nameof(accessor));
            
            
            IEnumerable<TItem> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(accessor, isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, accessor, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum(accessor) / sortable.Count();
            
            var leftBucket = new List<TItem>(); // lesser then average or equal to it
            var rightBucket = new List<TItem>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (accessor(item) <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<TItem>();
            var rightCollectionPart = new List<TItem>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, accessor, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, accessor, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of integer items using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection is null.</exception>
        public static IEnumerable<int> BucketSort(this IEnumerable<int> collection, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            
            IEnumerable<int> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum() / sortable.Count();
            
            var leftBucket = new List<int>(); // lesser then average or equal to it
            var rightBucket = new List<int>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (item <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<int>();
            var rightCollectionPart = new List<int>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of long integer items using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection is null.</exception>
        public static IEnumerable<long> BucketSort(this IEnumerable<long> collection, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            
            IEnumerable<long> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum() / sortable.Count();
            
            var leftBucket = new List<long>(); // lesser then average or equal to it
            var rightBucket = new List<long>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (item <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<long>();
            var rightCollectionPart = new List<long>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of decimal items using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection is null.</exception>
        public static IEnumerable<decimal> BucketSort(this IEnumerable<decimal> collection, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            
            IEnumerable<decimal> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum() / sortable.Count();
            
            var leftBucket = new List<decimal>(); // lesser then average or equal to it
            var rightBucket = new List<decimal>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (item <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<decimal>();
            var rightCollectionPart = new List<decimal>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of float items using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection is null.</exception>
        public static IEnumerable<float> BucketSort(this IEnumerable<float> collection, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            
            IEnumerable<float> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum() / sortable.Count();
            
            var leftBucket = new List<float>(); // lesser then average or equal to it
            var rightBucket = new List<float>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (item <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<float>();
            var rightCollectionPart = new List<float>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
        
        
        /// <summary>
        /// Sort the collection of double items using the bucket sort algorithm.
        /// </summary>
        /// <param name="collection">The collection to sort.</param>
        /// <param name="isAscendingOrder">The value indicating in what order the collection must be sorted.</param>
        /// <returns>The sorted collection.</returns>
        /// <exception cref="ArgumentNullException">if collection is null.</exception>
        public static IEnumerable<double> BucketSort(this IEnumerable<double> collection, bool isAscendingOrder = true)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            
            IEnumerable<double> sortable = collection.ToList();
            
            
            if (sortable.IsSorted(isAscendingOrder))
                return sortable;
            
            // if collection is not sorted but consists of 10 or less items then sort it using the quicksort
            if (sortable.Count() <= 10)
            {
                var bucket = sortable.ToArray();
                
                QuickSort(bucket, 0, bucket.Length - 1, isAscendingOrder);

                return bucket;
            }
            
            
            //calculate arithmetic average for all elements of the collection
            var average = sortable.Sum() / sortable.Count();
            
            var leftBucket = new List<double>(); // lesser then average or equal to it
            var rightBucket = new List<double>(); // greater then average
        
            foreach (var item in sortable)
            {
                if (item <= average)
                    leftBucket.Add(item);
                else
                    rightBucket.Add(item);
            }
        
            
            var leftCollectionPart = new List<double>();
            var rightCollectionPart = new List<double>();
        
            leftCollectionPart = leftCollectionPart.Concat(BucketSort(leftBucket, isAscendingOrder)).ToList();
            rightCollectionPart = rightCollectionPart.Concat(BucketSort(rightBucket, isAscendingOrder)).ToList();
            
            return isAscendingOrder ? leftCollectionPart.Concat(rightCollectionPart) : rightCollectionPart.Concat(leftCollectionPart);
        }
    }
}