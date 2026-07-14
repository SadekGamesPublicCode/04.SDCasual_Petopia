using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMeatSC : ItemSC
{
    void Start()
    {
        base.Start();
        nutritionValue = 30;
        energyFact = 10;
        happinessFact = 10;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsFood(7);
        }
    }
}
