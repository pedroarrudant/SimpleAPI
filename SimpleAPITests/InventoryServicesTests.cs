using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleAPI.Controller;
using SimpleAPI.Services;

namespace SimpleAPITests
{
    [TestClass]
    public class InventoryServicesTests
    {
        [TestMethod]
        public void MustAddObject()
        {
            //Arrange
            var inventoryServices = new InventoryServices();
            var inventoryController = new InventoryController(inventoryServices);
            var inventoryItem = new InventoryItems() { Id = 2, ItemName = "Test", Price = 100 };

            //Act
            var actionResult = inventoryController.AddInvetoryItems(inventoryItem);
            var result = actionResult.Result as CreatedResult;

            //Assert
            Assert.AreEqual(actionResult.Result, result);
        }

        [TestMethod]
        public void MustReturnObject()
        {
            //Arrange
            var inventoryServices = new InventoryServices();
            var inventoryController = new InventoryController(inventoryServices);
            var inventoryItem = new InventoryItems() { Id = 2, ItemName = "Test", Price = 100 };
            var addedResult = inventoryController.AddInvetoryItems(inventoryItem);

            //Act
            var actionResult = inventoryController.GetInventoryItems();
            var result = actionResult.Result as OkObjectResult;

            //Assert
            Assert.AreEqual(actionResult.Result, result);
        }
    }
}
