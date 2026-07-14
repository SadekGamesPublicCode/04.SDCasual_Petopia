using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimeSodaItemSC : ItemDrink_SC
{
    void Start()
    {
        base.Start();
        nutritionFact = 10;
        happinessFact = 40;
        energyFact = 00;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsDrink(4);
        }
    }
}
