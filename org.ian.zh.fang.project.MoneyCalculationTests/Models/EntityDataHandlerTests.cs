using org.ian.zh.fang.project.MoneyCalculation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq.Expressions;

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

        [TestMethod()]
        public void AddTest()
        {
            MaterialFrom materialfrom = new MaterialFrom { FDesc = "自运" };
            Assert.IsTrue(0 < materialfrom.InsertAsync().Result.FromId);

            MaterialSize msize = new MaterialSize { SDesc = "80X80" };
            Assert.IsTrue(0 < msize.InsertAsync().Result.SizeId);

            OrderMaterial ordermaterial = new OrderMaterial
            {
                MFlag = 0,
                MFrom = materialfrom.FDesc,
                MSize = msize.SDesc,
                MQuantity = 10,
                OrderId = 1
            };
            Assert.IsTrue(0 < ordermaterial.InsertAsync().Result.MaterialId);
        }

        [TestMethod()]
        public void ModifyAsyncTest()
        {
            OrderMaterial material = OrderMaterial.FindAsync(1).Result;
            material.MQuantity = 100;
            material.MFlag = 2;
            OrderMaterial result = material.UpdateAsync().Result;
            Assert.IsNotNull(result);

            material.MSize = "120X120";
            material.MQuantity = 200;
            result = material.UpdateAsync(new Expression<Func<OrderMaterial, object>>[] { t => t.MSize, t => t.MQuantity }).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteAsyncTest()
        {
            IEnumerable<MaterialSize> mSizes = MaterialSize.DeleteAsync(t => t.SDesc == "2X2").Result;
            Assert.IsTrue(0 <= mSizes.Count());

            MaterialSize mSize = MaterialSize.DeleteAsync(1002).Result;
            Assert.IsNull(mSize);

            mSize = MaterialSize.DeleteAsync(2002).Result;
            Assert.IsNull(mSize);


            DeleteEntity<MaterialSize>(t => t.SDesc.Contains("2X"));
            DeleteEntity<MaterialSize>(t => t.SDesc.Contains("X100"));
            DeleteEntity<MaterialSize>(t => t.SDesc.Contains("X120"));
        }

        private void DeleteEntity<T>(Expression<Func<T, bool>> predicate)
        {
            MethodInfo method = GetMethod(typeof(T), "DeleteAsync", typeof(Expression<Func<T, bool>>));
            Task<IEnumerable<T>> task = method.Invoke(null, new object[] { predicate }) as Task<IEnumerable<T>>;
            IEnumerable<T> result = task.Result;
            int count = result.Count();
            Debug.WriteLine(string.Format("count: {0},  t-sql: {1}", count, predicate.ToString()));
            Assert.IsTrue(0 <= count);
        }
        
        private MethodInfo GetMethod(Type type, string methodName = "AllAsync", params Type[] paramTypes)
        {
            if (type == null)
                return null;

            MethodInfo method = type.GetMethod(methodName, paramTypes) ?? GetMethod(type.BaseType, methodName, paramTypes);
            return method;
        }
    }
}