using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkItemSC : ItemDrink_SC
{
    void Start()
    {
        base.Start();
        nutritionFact = 20;
        happinessFact = 0;
        energyFact = 30;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsDrink(8);
        }
    }
}
