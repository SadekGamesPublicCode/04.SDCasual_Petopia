using System.Collections;
using System.Collections.Generic;
using SQLite;
using System.Linq;

public class InventoryRepository
{
    SQLiteConnection db => DatabaseManager.db;
    public List<InventoryItem> LoadAll()
    {
        return db.Query<InventoryItem>("SELECT * FROM Inventory");
    }
    public void Add(string itemId, int amount)
    {
        var item = db.Query<InventoryItem>("SELECT itemId, quantity FROM Inventory WHERE itemId = ?",itemId).FirstOrDefault(); ;
        if (item == null)
        {
            db.Execute("INSERT INTO Inventory (itemId, quantity) VALUES (?, ?)", itemId, amount);
        }
        else
        {
            db.Execute("UPDATE Inventory SET quantity = quantity + ? WHERE itemId = ?", amount, itemId);
        }
    }
    public void Remove(string itemId, int amount)
    {
        db.Execute("UPDATE Inventory SET quantity = quantity - ? WHERE itemId = ?", amount, itemId);
        db.Execute("DELETE FROM Inventory WHERE quantity <= 0");
    }
}
