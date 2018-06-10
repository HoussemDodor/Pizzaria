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
        PizzaLogic pizzalogic = new PizzaLogic();
        [TestMethod]
        public void TestPizzaSizeCalculations()
        {
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
        public void TestMaxAndMinSizes()
        {
            foreach (Pizza p in pizzalogic.GetAllPizzas())
            {
                if (p.GetSize() < 50 && p.GetSize() > 2500)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestPizzaPriceCalculations()
        {
            Assert.AreEqual((decimal)10.13, pizzalogic.GetPizzaByID(1).Price);

            Assert.AreEqual((decimal)18.53, pizzalogic.GetPizzaByID(5).Price);
        }

        [TestMethod]
        public void TestPriceDiscountIfStandardPizza()
        {
            Pizza pizzaOne = pizzalogic.GetPizzaByID(1);
            Pizza pizzaTwo = pizzalogic.GetPizzaByID(1);

            pizzaTwo.StandardPizza = false;

            Assert.AreNotEqual(pizzaOne.Price, pizzaTwo.Price);
        }
    }
}
