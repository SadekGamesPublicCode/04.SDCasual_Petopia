using System.Collections;
using System.Collections.Generic;
using SQLite;

[Table("Inventory")]
public class InventoryItem
{
    public int id; //maps to PRIMARY KEY
    public string itemId;
    public int quantity;
}
