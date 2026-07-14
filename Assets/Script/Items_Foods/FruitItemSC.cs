using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitItemSC : ItemSC
{
    void Start()
    {
        base.Start();
        nutritionValue = 10;
        energyFact = 20;
        happinessFact = 20;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsFood(2);
        }
    }
}
