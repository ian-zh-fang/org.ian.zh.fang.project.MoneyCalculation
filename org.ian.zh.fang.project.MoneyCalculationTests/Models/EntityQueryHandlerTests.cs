using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.ian.zh.fang.project.MoneyCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.ian.zh.fang.project.MoneyCalculation.Models.Tests
{
    [TestClass()]
    public class EntityQueryHandlerTests
    {
        [TestMethod()]
        public void FindAsyncTest()
        {
            MaterialFrom mFrom = MaterialFrom.FindAsync(1).Result;
            Assert.IsNotNull(mFrom);

            MaterialSize mSize = MaterialSize.FindAsync(1).Result;
            Assert.IsNotNull(mSize);

            OrderMaterial oMaterial = OrderMaterial.FindAsync(1).Result;
            Assert.IsNotNull(oMaterial);

            Order order = Order.FindAsync(1).Result;
            Assert.IsNull(order);
        }

        [TestMethod()]
        public void FindAsyncTest1()
        {
            IEnumerable<MaterialSize> mSizes = MaterialSize.FindAsync(t => t.SDesc == "2X2").Result;
            Assert.IsTrue(0 <= mSizes.Count());
        }
    }
}