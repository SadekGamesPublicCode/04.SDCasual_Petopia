using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkItem_SC : ItemDrink_SC
{
    void Start()
    {
        base.Start();
        nutritionFact = 20;
        happinessFact = 10;
        energyFact = 10;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsDrink(1);
        }
    }
}