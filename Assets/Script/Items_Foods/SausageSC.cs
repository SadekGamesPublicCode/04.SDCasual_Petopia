using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SausageSC : ItemSC
{
    void Start()
    {
        base.Start();
        nutritionValue = 20;
        energyFact = 20;
        happinessFact = 10;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsFood(1);
        }
    }
}
