using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPIUnitTest
{
    [TestClass]
    public class StarWarsBaseUnitTest
    {
        protected void TestArrayItems<T>(IEnumerable<string> items, string[] expectedItems, Func<Task<IEnumerable<T>>> method) where T : StarWarsBase
        {
            Assert.IsNotNull(items);


            Assert.AreEqual(items.Count(), expectedItems.Length);

            foreach (var item in items)
            {
                var found = expectedItems.Contains(item);
                Assert.AreEqual(found, true);
            }

            TestArrayItemsObject(expectedItems, method);
        }


      protected  void TestArrayItemsObject<T>(string[] expectedItems, Func<Task<IEnumerable<T>>> method) where T : StarWarsBase
        {
            IEnumerable<T> items = method().Result;

            foreach (var item in items)
            {
                var url = item.url;
                var found = expectedItems.Contains(url);
                Assert.AreEqual(found, true);
            }

        }

    }
}
