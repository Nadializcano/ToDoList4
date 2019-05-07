using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {
    public void Dispose()
    {
      Item.ClearAll();
    }
    public ItemTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=to_do_list_test;";
    }

    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      string item = "test";
      string dueDate = "03/15";
      Item newItem = new Item(item, dueDate);
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "Walk the dog.";
      string dueDate = "03/15";
      Item newItem = new Item(description, dueDate);
      string result = newItem.GetDescription();
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "Walk the dog.";
      string dueDate = "03/15";
      Item newItem = new Item(description, dueDate);

      string updatedDescription = "Do the dishes";
      newItem.SetDescription(updatedDescription);
      string result = newItem.GetDescription();

      Assert.AreEqual(updatedDescription, result);
    }
    [TestMethod]
    public void GetDueDate_ReturnsDueDate_String()
    {
      string description = "Walk the dog.";
      string dueDate = "03/15";
      Item newItem = new Item(description, dueDate);
      string result = newItem.GetDueDate();
      Assert.AreEqual(result, dueDate);
    }
    [TestMethod]
    public void SetDueDate_SetsDueDate_String()
    {
      string description = "Walk the dog.";
      string dueDate = "03/15";
      Item newItem = new Item(description, dueDate);
      string newDueDate = "05/15";
      newItem.SetDueDate(newDueDate);
      string result = newItem.GetDueDate();
      Assert.AreEqual(result, newDueDate);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      List<Item> newList = new List<Item> { };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    // [TestMethod]
    // public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    // {
    //   Item firstItem = new Item("Mow the lawn");
    //   Item secondItem = new Item("Mow the lawn");
    //   Assert.AreEqual(firstItem, secondItem);
    // }
    // [TestMethod]
    // public void Save_SavesToDatabase_ItemList()
    // {
    //   //Arrange
    //   Item testItem = new Item("Mow the lawn");

    //   //Act
    //   testItem.Save();
    //   List<Item> result = Item.GetAll();
    //   List<Item> testList = new List<Item>{testItem};

    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    // [TestMethod]
    // public void GetAll_ReturnsItems_ItemList()
    // {
    //   //Arrange
    //   string description01 = "Walk the dog";
    //   string description02 = "Wash the dishes";
    //   Item newItem1 = new Item(description01);
    //   Item newItem2 = new Item(description02);
    //   newItem1.Save();
    //   newItem2.Save();

    //   List<Item> newList = new List<Item> { newItem1, newItem2 };

    //   //Act
    //   List<Item> result = Item.GetAll();

    //   //Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }

    // [TestMethod]
    // public void Save_AssignsIdToObject_Id()
    // {
    //   Item testItem = new Item("Mow the lawn");
    //   testItem.Save();
    //   Item savedItem = Item.GetAll()[0];
    //   int result = savedItem.GetId();
    //   int testId = testItem.GetId();
    //   Assert.AreEqual(testId, result);
    // }

    // [TestMethod]
    // public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //     //Arrange
    //     string description = "Walk the dog.";
    //     Item newItem = new Item(description);

    //     //Act
    //     int result = newItem.GetId();

    //     //Assert
    //     Assert.AreEqual(1, result);
    // }
    // [TestMethod]
    // public void Find_ReturnsCorrectItemFromDatabase_Item()
    // {
    //   //Arrange
    //   Item testItem = new Item("Mow the Lawn");
    //   testItem.Save();

    //   //Act
    //   Item foundItem = Item.Find(testItem.GetId());

    //   //Assert
    //   Assert.AreEqual(testItem, foundItem);
    // }

  }
}