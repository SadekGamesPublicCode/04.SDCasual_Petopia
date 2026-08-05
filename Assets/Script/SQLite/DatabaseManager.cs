using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    public static SQLiteConnection db;
    private void Awake()
    {
        if (db != null)
        {
            Destroy(gameObject);
            return;
        }

        string dbPath = Path.Combine(Application.persistentDataPath,"PInventory.db");

        db = new SQLiteConnection(dbPath);
        CreateTables();
        //Debug.Log(Application.persistentDataPath);
    }
    void CreateTables()
    {
        db.Execute(@"CREATE TABLE IF NOT EXISTS Inventory(id INTEGER PRIMARY KEY AUTOINCREMENT, itemId TEXT NOT NULL, quantity INTEGER NOT NULL);        ");
        //repo: C:/Users/Usr/AppData/LocalLow/DefaultCompany/Petopia
    }

    #region Database Services
    public void AddItem(string itemId, int quantity)
    {
        var repo = new InventoryRepository();
        repo.Add(itemId, quantity);
    }
    public void UpdateItems()
    {

    }
    public void RemoveItem(string itemId, int quantity)
    {
        var repo = new InventoryRepository();
        repo.Remove(itemId, quantity);
    }
    #endregion
}
