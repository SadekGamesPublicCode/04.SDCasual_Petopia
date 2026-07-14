using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaconSC : ItemSC
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        nutritionValue = 30;
        happinessFact = 10;
        energyFact = 10;
    }
    internal void OnMouseDown()
    {
        if (gameMode == 3)
        {
            //In Petshop
            print("in click object");
            shopCtr.OnPickGoodsFood(5);
        }
    }
}
