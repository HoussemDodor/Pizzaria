using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Models;
using DataAccesLayer;
using LogicLayer;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPizzaSize()
        {
            PizzaLogic pizzalogic = new PizzaLogic();

            Pizza p = new Pizza()
            {
                ShapeID = 2,
                Width = 10,
                Length = 15,
                SideLength = 0
            };

            Assert.AreEqual(150, p.GetSize());

            Assert.AreEqual(440, pizzalogic.GetPizzaByID(6).GetSize());

            Assert.AreEqual(537, pizzalogic.GetPizzaByID(5).GetSize());

            Assert.AreEqual(491, pizzalogic.GetPizzaByID(1).GetSize());
        }

        [TestMethod]
        public void TestDatabaseResults()
        {
            CategoryRepository catrepo = new CategoryRepository();
            Assert.AreEqual(2, catrepo.GetAllCategory().Count);

            ToppingRepository toprepo = new ToppingRepository();
            Assert.AreEqual(12, toprepo.GetAllToppings().Count);
        }

        [TestMethod]
        public void Test()
        {
            
        }
    }
}
