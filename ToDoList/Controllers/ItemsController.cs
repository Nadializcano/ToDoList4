using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/categories/{categoryId}/items/new")]
    public ActionResult New(int categoryId)
    {
       Category category = Category.Find(categoryId);
       return View(category);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
        Item.ClearAll();
        return View();
    }
    [HttpGet("/categories/{categoryId}/items/{itemId}")]
    public ActionResult Show(int categoryId, int itemId)
    {
        Item item = Item.Find(itemId);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category category = Category.Find(categoryId);
        model.Add("item", item);
        model.Add("category", category);
        return View(model);
    }
    [HttpGet("/categories/{categoryId}/items/{itemId}/edit")]
      public ActionResult Edit(int categoryId, int itemId)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category category = Category.Find(categoryId);
        model.Add("category", category);
        Item item = Item.Find(itemId);
        model.Add("item", item);
        return View(model);
      }
    [HttpPost("/categories/{categoryId}/items/{itemId}")]
      public ActionResult Update(int categoryId, int itemId, string newDescription)
      {
        Item item = Item.Find(itemId);
        item.Edit(newDescription);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category category = Category.Find(categoryId);
        model.Add("category", category);
        model.Add("item", item);
        return View("Show", model);
      }
      [HttpGet("/categories/{categoryId}/items/{itemId}/delete")]
        public ActionResult Delete(int categoryId, int itemId)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Item item = Item.Find(itemId);
          item.Delete();
          model.Add("item", item);
          return View(model);
        }

        [HttpPost("/items/deleted")]
          public ActionResult Deleted(int itemId)
          {
            Item item = Item.Find(itemId);
            item.Delete();
            return View("Index");
          }
  }
}
