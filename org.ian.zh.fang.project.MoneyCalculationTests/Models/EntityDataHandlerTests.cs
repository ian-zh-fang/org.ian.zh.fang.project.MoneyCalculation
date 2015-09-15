using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
            AssertAll<Customer>();
            AssertAll<CustomerAmountTotal>();
            AssertAll<CustomerOrderCountTotal>();
            AssertAll<MaterialFrom>();
            AssertAll<MaterialSize>();
            AssertAll<Order>();
            AssertAll<OrderAmountTotal>();
            AssertAll<OrderContent>();
            AssertAll<OrderMaterial>();
            AssertAll<OrderMaterialTotal>();
            AssertAll<OrderType>();
            AssertAll<UnitContent>();

            //IEnumerable<MaterialFrom> froms = MaterialFrom.AllAsync().Result;
            //Assert.IsTrue(froms.Count() >= 0);

            //IEnumerable<MaterialSize> sizes = MaterialSize.AllAsync().Result;
            //Assert.IsTrue(0 <= sizes.Count());

            //IEnumerable<OrderMaterial> ordermaterials = OrderMaterial.AllAsync().Result;
            //Assert.IsTrue(0 <= ordermaterials.Count());          
        }

        private void AssertAll<T>() where T : class, new()
        {
            Type type = typeof(T);
            MethodInfo method = GetMethod(type);
            Task<IEnumerable<T>> task = method.Invoke(null, null) as Task<IEnumerable<T>>;
            IEnumerable<T> result = task.Result;
            int count = result.Count();
            Debug.WriteLine(string.Format("count: {0}, type: {1}", count, type.Name));
            Assert.IsTrue(0 <= result.Count());
        }

        private MethodInfo GetMethod(Type type, string methodName = "AllAsync")
        {
            if (type == null)
                return null;

            MethodInfo method = type.GetMethod(methodName) ?? GetMethod(type.BaseType);
            return method;
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