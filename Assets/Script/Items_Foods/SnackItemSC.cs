using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackItemSC : ItemSC
{
    void Start()
    {
        base.Start();
        nutritionValue = 10;
        energyFact = 10;
        happinessFact = 30;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsFood(3);
        }
    }
}
