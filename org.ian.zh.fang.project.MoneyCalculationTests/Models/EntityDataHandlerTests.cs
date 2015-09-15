using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace org.ian.zh.fang.project.MoneyCalculation.Models.Tests
{
    [TestClass()]
    public class EntityDataHandlerTests
    {
        [TestMethod()]
        public void EntityDataHandlerTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void EntityDataHandlerTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AllTest()
        {
            IEnumerable<MaterialFrom> froms = MaterialFrom.AllAsync().Result;
            Assert.IsTrue(froms.Count() >= 0);

            IEnumerable<MaterialSize> sizes = MaterialSize.AllAsync().Result;
            Assert.IsTrue(0 <= sizes.Count());

            IEnumerable<OrderMaterial> ordermaterials = OrderMaterial.AllAsync().Result;
            Assert.IsTrue(0 <= ordermaterials.Count());          
        }

        [TestMethod()]
        public void AddTest()
        {
            MaterialFrom materialfrom = new MaterialFrom { FDesc = "自运" };
            Assert.IsTrue(0 < materialfrom.AddAsync().Result.FromId);

            MaterialSize msize = new MaterialSize { SDesc = "80X80" };
            Assert.IsTrue(0 < msize.AddAsync().Result.SizeId);

            OrderMaterial ordermaterial = new OrderMaterial
            {
                MFlag = 0,
                MFrom = materialfrom.FDesc,
                MSize = msize.SDesc,
                MQuantity = 10,
                OrderId = 1
            };
            Assert.IsTrue(0 < ordermaterial.AddAsync().Result.MaterialId);
        }
    }
}