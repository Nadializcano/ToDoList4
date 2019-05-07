using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item
  {
      private string _description;
      private string _dueDate;
      private int _id;

      public Item (string description, string dueDate, int id = 0)
      {
          _description = description;
          _dueDate = dueDate;
          _id = id;
      }
      public string GetDescription()
      {
          return _description;
      }
      public int GetId()
      {
        return 0;
      }
      public void SetDescription(string newDiscription)
      {
        _description = newDiscription;
      }
      public string GetDueDate()
      {
        return _dueDate;
      }
      public void SetDueDate(string dueDate)
      {
        _dueDate = dueDate;
      }
      public static List<Item> GetAll()
      {
          List<Item> allItems = new List<Item> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM items;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
              int itemId = rdr.GetInt32(0);
              string itemDescription = rdr.GetString(1);
              string dueDate = rdr.GetString(2);
              Item newItem = new Item(itemDescription, dueDate, itemId);
              allItems.Add(newItem);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allItems;
      }
      public static void ClearAll()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM items;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }
      public override bool Equals(System.Object otherItem)
      {
        if (!(otherItem is Item))
        {
          return false;
        }
        else 
        {
          Item newItem = (Item) otherItem;
          bool idEquality = (this.GetId() == newItem.GetId());
          bool descriptionEquality = (this.GetDescription() == newItem.GetDescription());
          return (idEquality && descriptionEquality);
        }
      }
      public static Item Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM `items` WHERE id = @thisId;";
        MySqlParameter thisId = new MySqlParameter();
        thisId.ParameterName = "@thisId";
        thisId.Value = id;
        cmd.Parameters.Add(thisId);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int itemId = 0;
        string itemDescription = "";
        string dueDate = "";
        while (rdr.Read())
        {
          itemId = rdr.GetInt32(0);
          itemDescription = rdr.GetString(1);
        }
        Item foundItem = new Item(itemDescription, dueDate, itemId);

        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return foundItem;
      }
      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO items (description) VALUES (@ItemDescription);";
        MySqlParameter description = new MySqlParameter();
        description.ParameterName = "@ItemDescription";
        description.Value = this._description;
        cmd.Parameters.Add(description);
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;

        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }
  }
}