using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Models;
using DataAccesLayer;
using LogicLayer;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        ProductLogic productLogic = new ProductLogic();
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

            Assert.AreEqual(440, productLogic.GetPizzaByID(6).GetSize());

            Assert.AreEqual(537, productLogic.GetPizzaByID(5).GetSize());

            Assert.AreEqual(491, productLogic.GetPizzaByID(1).GetSize());
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
            foreach (Pizza p in productLogic.GetAllPizzas())
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
            Assert.AreEqual((decimal)10.13, productLogic.GetPizzaByID(1).Price);

            Assert.AreEqual((decimal)23.76, productLogic.GetPizzaByID(5).Price);
        }

        [TestMethod]
        public void TestPriceDiscountIfStandardPizza()
        {
            // maak 2 dezelfde pizzas aan
            Pizza pizzaOne = productLogic.GetPizzaByID(1);
            Pizza pizzaTwo = productLogic.GetPizzaByID(1);

            // maak een pizza geen standaard pizza meer
            pizzaTwo.StandardPizza = false;

            // de prijzen horen niet meer hetzelfde te zijn omdat er geen 25% korting meer geld.
            Assert.AreNotEqual(pizzaOne.Price, pizzaTwo.Price);
        }

        [TestMethod]
        public void TestTotalPriceOfOrder()
        {
            // nieuwe order aanmaken en 2 pizza's toevoegen
            Order order = new Order();
            order.productsInThisOrder.Add(productLogic.GetPizzaByID(5));
            order.productsInThisOrder.Add(productLogic.GetPizzaByID(1));

            // vergelijk de totaal prijs met de echte prijs
            Assert.AreEqual((decimal)33.89, order.TotalPrice);

            // Voeg nog een product toe 
            order.productsInThisOrder.Add(productLogic.GetSideByID(1));

            // Kijk of de totale prijs is toegenomen met het toegevoegde product
            Assert.AreEqual((decimal)37.39, order.TotalPrice);
        }
    }
}

