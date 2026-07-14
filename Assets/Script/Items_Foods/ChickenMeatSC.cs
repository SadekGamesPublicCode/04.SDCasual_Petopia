using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMeatSC : ItemSC
{
    void Start()
    {
        base.Start();
        nutritionValue = 20;
        energyFact = 10;
        happinessFact = 20;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsFood(6);
        }
    }
}
