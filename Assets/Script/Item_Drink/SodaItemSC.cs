using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaItemSC : ItemDrink_SC
{

    void Start()
    {
        base.Start();
        nutritionFact = 10;
        happinessFact = 30;
        energyFact = 0;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsDrink(2);
        }
    }
}
