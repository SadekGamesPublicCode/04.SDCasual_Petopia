using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusMeatSC : ItemSC
{
    void Start()
    {
        base.Start();
        nutritionValue = 40;
        energyFact = 10;
        happinessFact = 00;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsFood(9);
        }
    }
}
