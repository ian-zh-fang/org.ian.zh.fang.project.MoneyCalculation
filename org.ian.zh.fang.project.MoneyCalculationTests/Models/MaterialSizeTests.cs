using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.ian.zh.fang.project.MoneyCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace org.ian.zh.fang.project.MoneyCalculation.Models.Tests
{
    [TestClass()]
    public class MaterialSizeTests
    {
        [TestMethod()]
        public void MaterialSizeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MaterialSizeTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MaterialSizeDataHandlerTest()
        {
            MaterialSize mSize = new MaterialSize { SDesc = "1X1" };
            MaterialSize result = mSize.InsertAsync().Result;
            Assert.IsTrue(0 < result.SizeId);

            mSize.SDesc = "1X2";
            result = mSize.UpdateAsync().Result;
            Assert.IsNotNull(result);

            mSize.SDesc = "1X3";
            result = mSize.UpdateAsync(new Expression<Func<MaterialSize, object>>[] { t => t.SDesc }).Result;
            Assert.IsNotNull(result);

            result = result.DeleteAsync().Result;
            Assert.IsNotNull(result);

        }
    }
}