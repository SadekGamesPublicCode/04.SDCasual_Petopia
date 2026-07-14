using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineItemSC : ItemDrink_SC
{    void Start()
    {
        base.Start();
        nutritionFact = 30;
        happinessFact = 0;
        energyFact = 0;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            shopCtr.OnPickGoodsDrink(9);
        }
    }
}
