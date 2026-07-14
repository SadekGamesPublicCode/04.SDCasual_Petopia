using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaItemSC : ItemDrink_SC
{
    void Start()
    {
        base.Start();
        nutritionFact = 20;
        happinessFact = 30;
        energyFact = 0;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsDrink(7);
        }
    }
}
