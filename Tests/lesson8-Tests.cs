using System.Collections.Generic;
using lesson_8;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class SortTests
    {
        public class Pizza
        {
            public int Diameter { get; set; }
            public decimal Cost { get; set; }
            public string Name { get; set; }
        }
        
        public int[] arrayIntSortedAsc = {-322, -228, -196, -101, -45, -23, -23, -10, -1, 14, 29, 95, 101, 304, 304, 509, 988, 1000};
        public int[] arrayIntSortedDesc = {1000, 988, 509, 304, 304, 101, 95, 29, 14, -1, -10, -23, -23, -45, -101, -196, -228, -322};

        public List<Pizza> listPizzaSortedByCostAsc = new List<Pizza> {
            new Pizza {Diameter = 25, Cost = 300, Name = "Margarita"},
            new Pizza {Diameter = 25, Cost = 330, Name = "4 Cheeses"},
            new Pizza {Diameter = 30, Cost = 350, Name = "Margarita"},
            new Pizza {Diameter = 25, Cost = 350, Name = "Carbonara"},
            new Pizza {Diameter = 25, Cost = 400, Name = "Pepperoni"},
            new Pizza {Diameter = 30, Cost = 410, Name = "Carbonara"},
            new Pizza {Diameter = 25, Cost = 420, Name = "Chicken BBQ"},
            new Pizza {Diameter = 30, Cost = 420, Name = "4 Cheeses"},
            new Pizza {Diameter = 25, Cost = 450, Name = "Big Mac"},
            new Pizza {Diameter = 40, Cost = 460, Name = "Margarita"},
            new Pizza {Diameter = 30, Cost = 510, Name = "Pepperoni"},
            new Pizza {Diameter = 30, Cost = 535, Name = "Chicken BBQ"},
            new Pizza {Diameter = 40, Cost = 580, Name = "Carbonara"},
            new Pizza {Diameter = 40, Cost = 590, Name = "4 Cheeses"},
            new Pizza {Diameter = 30, Cost = 600, Name = "Big Mac"},
            new Pizza {Diameter = 40, Cost = 630, Name = "Pepperoni"},
            new Pizza {Diameter = 40, Cost = 700, Name = "Chicken BBQ"},
            new Pizza {Diameter = 40, Cost = 850, Name = "Big Mac"}
        };

        public List<Pizza> listPizzaSortedByCostDesc = new List<Pizza> {
            new Pizza {Diameter = 40, Cost = 850, Name = "Big Mac"},
            new Pizza {Diameter = 40, Cost = 700, Name = "Chicken BBQ"},
            new Pizza {Diameter = 40, Cost = 630, Name = "Pepperoni"},
            new Pizza {Diameter = 30, Cost = 600, Name = "Big Mac"},
            new Pizza {Diameter = 40, Cost = 590, Name = "4 Cheeses"},
            new Pizza {Diameter = 40, Cost = 580, Name = "Carbonara"},
            new Pizza {Diameter = 30, Cost = 535, Name = "Chicken BBQ"},
            new Pizza {Diameter = 30, Cost = 510, Name = "Pepperoni"},
            new Pizza {Diameter = 40, Cost = 460, Name = "Margarita"},
            new Pizza {Diameter = 25, Cost = 450, Name = "Big Mac"},
            new Pizza {Diameter = 30, Cost = 420, Name = "4 Cheeses"},
            new Pizza {Diameter = 25, Cost = 420, Name = "Chicken BBQ"},
            new Pizza {Diameter = 30, Cost = 410, Name = "Carbonara"},
            new Pizza {Diameter = 25, Cost = 400, Name = "Pepperoni"},
            new Pizza {Diameter = 25, Cost = 350, Name = "Carbonara"},
            new Pizza {Diameter = 30, Cost = 350, Name = "Margarita"},
            new Pizza {Diameter = 25, Cost = 330, Name = "4 Cheeses"},
            new Pizza {Diameter = 25, Cost = 300, Name = "Margarita"},
        };


        [Test]
        public void Test_IsSorted__NumericCollection_Ascending()
        {
            Assert.True(arrayIntSortedAsc.IsSorted(true));
        }


        [Test]
        public void Test_IsSorted__NumericCollection_Ascending_NotSorted()
        {
            Assert.False(arrayIntSortedAsc.IsSorted(false));
        }


        [Test]
        public void Test_IsSorted__NumericCollection_Descending()
        {
            Assert.True(arrayIntSortedDesc.IsSorted(false));
        }
        
        
        [Test]
        public void Test_IsSorted__NumericCollection_Descending_NotSorted()
        {
            Assert.False(arrayIntSortedDesc.IsSorted(true));
        }


        [Test]
        public void Test_IsSorted__NonNumericCollection_Ascending()
        {
            Assert.True(listPizzaSortedByCostAsc.IsSorted(it => it.Cost));
        }
        
        [Test]
        public void Test_IsSorted__NonNumericCollection_Ascending_NotSorted()
        {
            Assert.False(listPizzaSortedByCostAsc.IsSorted(it => it.Cost, false));
        }
        
        
        [Test]
        public void Test_IsSorted__NonNumericCollection_Descending()
        {
            Assert.True(listPizzaSortedByCostDesc.IsSorted(it => it.Cost, false));
        }
        
        [Test]
        public void Test_IsSorted__NonNumericCollection_Descending_NotSorted()
        {
            Assert.False(listPizzaSortedByCostDesc.IsSorted(it => it.Cost));
        }


        [Test]
        public void Test_QuickSort__NumericCollection_Ascending()
        {
            var sortable = arrayIntSortedDesc;
            Sort.QuickSort(sortable, 0, arrayIntSortedDesc.Length - 1);
            
            Assert.True(sortable.IsSorted(true));
        }
        
        [Test]
        public void Test_QuickSort__NumericCollection_Descending()
        {
            var sortable = arrayIntSortedAsc;
            Sort.QuickSort(sortable, 0, arrayIntSortedDesc.Length - 1, false);
            
            Assert.True(sortable.IsSorted(false));
        }


        [Test]
        public void Test_QuickSort__NonNumericCollection_Ascending()
        {
            var sortable = listPizzaSortedByCostDesc.ToArray();

            Sort.QuickSort(sortable, it => it.Cost, 0, sortable.Length - 1, true);

            Assert.True(sortable.IsSorted(it => it.Cost));
        }
        
        [Test]
        public void Test_QuickSort__NonNumericCollection_Descending()
        {
            var sortable = listPizzaSortedByCostAsc.ToArray();

            Sort.QuickSort(sortable, it => it.Cost, 0, sortable.Length - 1, false);

            Assert.True(sortable.IsSorted(it => it.Cost, false));
        }


        [Test]
        public void Test_BucketSort__NumericCollection_Ascending()
        {
            var sortable = arrayIntSortedDesc;

            var actual = sortable.BucketSort();
            
            Assert.True(actual.IsSorted(true));
        }


        [Test]
        public void Test_BucketSort__NumericCollection_Descending()
        {
            var sortable = arrayIntSortedAsc;

            var actual = sortable.BucketSort(false);
            
            Assert.True(actual.IsSorted(false));
        }


        [Test]
        public void Test_BucketSort__NonNumericCollection_Ascending()
        {
            var sortable = listPizzaSortedByCostDesc;

            var actual = sortable.BucketSort(it => it.Cost);
            
            Assert.True(actual.IsSorted(it => it.Cost));
        }
        
        
        [Test]
        public void Test_BucketSort__NonNumericCollection_Descending()
        {
            var sortable = listPizzaSortedByCostAsc;

            var actual = sortable.BucketSort(it => it.Cost, false);
            
            Assert.True(actual.IsSorted(it => it.Cost, false));
        }
    }
}