using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Models;
using DataAccesLayer;
using LogicLayer;

namespace Tests
{
    [TestClass]
    public class IntegrationTest
    {
        ProductLogic productLogic = new ProductLogic();
        ShapeRepository shapeRepo = new ShapeRepository();
        DoughTypeRepository doughRepo = new DoughTypeRepository();
        ToppingRepository toppingRepo = new ToppingRepository();
        CategoryRepository categoryRepo = new CategoryRepository();

        [TestMethod]
        public void TestPizzaRelationWithOtherModels()
        {
            Pizza pizza = productLogic.GetPizzaByID(6);

            Shape shape = shapeRepo.GetShapeByID(pizza.ShapeID);
            DoughType doughType = doughRepo.GetDoughTypeByID(pizza.DoughID);

            Assert.AreEqual(shape.ID, pizza.Shape.ID);
            Assert.AreEqual(doughType.ID, pizza.DoughType.ID);
        }

        [TestMethod]
        public void TestSideRelationWithCategory()
        {
            Side side = productLogic.GetSideByID(1);

            Category category = categoryRepo.GetCategoryByID(side.CategoryID);

            Assert.AreEqual(category.ID, side.Category.ID);
        }

        [TestMethod]
        public void PizzaSideCalculationsWithTestData()
        {
            Shape shape = new Rectangle();
            Pizza pizza = new Pizza();
            pizza.Shape = shape;
            pizza.ShapeID = 2;

            pizza.Width = 10;
            pizza.Length = 15;

            Assert.AreEqual(150,pizza.GetSize());
        }
    }
}
