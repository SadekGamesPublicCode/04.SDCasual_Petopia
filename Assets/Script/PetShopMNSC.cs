using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PetShopMNSC : MonoBehaviour
{
    [HideInInspector] GenMNSC genCtr;
    [HideInInspector] DataSC dataCtr;
    [HideInInspector] AdsMN adsCtr;
    [SerializeField] List<Sprite> goodsSpriteList =  new List<Sprite>();
    [SerializeField] GameObject confirmBuyPnl;
    [SerializeField] Text quantityTxt, unitPriceTxt, curPlayerMoneyTxt, itemNameTxt, totalPriceTxt;
    [SerializeField] Image pickedGoodsSpirte;

    int curGoodOnChoose, goodsQuantity;
    int stuffPrice;
    void Start()
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        dataCtr = GameObject.Find("GenMN").GetComponent<DataSC>();
        adsCtr = GameObject.Find("AdsMN").GetComponent<AdsMN>();
        OnResetConfirmBuyPanel();
        UpdateShopUIs();
    }
    public void OnHome() => genCtr.OnChangeScene(2);
    private void UpdateShopUIs()
    {
        curPlayerMoneyTxt.text = dataCtr.pCurrency.ToString();
        confirmBuyPnl.gameObject.SetActive(false);
    }
    public void OnShowConfirmbuy(int goodsToShow, int unitPrice)
    {
        confirmBuyPnl.gameObject.SetActive(true);
        quantityTxt.text = "1";
        totalPriceTxt.text = unitPrice.ToString();
        unitPriceTxt.text = unitPrice.ToString();
        pickedGoodsSpirte.sprite = goodsSpriteList[goodsToShow];
    }

    public void OnPickGoodsFood(int order)
    {
        switch (order)
        {
            case 0:
                //PEAD
                curGoodOnChoose = 0;
                stuffPrice = 10;
                itemNameTxt.text = "PEAD";
                break;
            case 1:
                //SAUSAGE
                curGoodOnChoose = 1;
                stuffPrice = 10;
                itemNameTxt.text = "SUASAGE";
                break;
            case 2:
                //FRUIT
                curGoodOnChoose = 2;
                stuffPrice = 20;
                itemNameTxt.text = "FRUITS";
                break;
            case 3:
                //SNACK
                curGoodOnChoose = 3;
                stuffPrice = 20;
                itemNameTxt.text = "SNACK";
                break;
            case 4:
                //TOFU
                curGoodOnChoose = 4;
                stuffPrice = 30;
                itemNameTxt.text = "TOFU";
                break;
            case 5:
                //BACON
                curGoodOnChoose = 5;
                stuffPrice = 30;
                itemNameTxt.text = "BACON";
                break;
            case 6:
                //CHICKEN
                curGoodOnChoose = 6;
                stuffPrice = 40;
                itemNameTxt.text = "CHICKEN";
                break;
            case 7:
                //FISH
                curGoodOnChoose = 7;
                stuffPrice = 40;
                itemNameTxt.text = "FISH";
                break;
            case 8:
                //PORK
                curGoodOnChoose = 8;
                stuffPrice = 50;
                itemNameTxt.text = "PORK";
                break;
            case 9:
                ///OCTOPUS
                curGoodOnChoose = 9;
                stuffPrice = 50;
                itemNameTxt.text = "OCTOPUS";
                break;
        }
        OnShowConfirmbuy(curGoodOnChoose, stuffPrice);
    }
    public void OnPickGoodsDrink(int order)
    {
        switch (order)
        {
            case 0:
                //wATER
                curGoodOnChoose = 10;
                stuffPrice = 10;
                itemNameTxt.text = "WATER";
                break;
            case 1:
                //mILK
                curGoodOnChoose = 11;
                stuffPrice = 10;
                itemNameTxt.text = "MILK";
                break;
            case 2:
                //PLAIN SODA
                curGoodOnChoose = 12;
                stuffPrice = 20;
                itemNameTxt.text = "MILK";
                break;
            case 3:
                //COKE
                curGoodOnChoose = 13;
                stuffPrice = 20;
                itemNameTxt.text = "COKE";
                break;
            case 4:
                //LIME
                curGoodOnChoose = 14;
                stuffPrice = 30;
                itemNameTxt.text = "LIME";
                break;
            case 5:
                //JUICE
                curGoodOnChoose = 15;
                stuffPrice = 30;
                itemNameTxt.text = "JUICE";
                break;
            case 6:
                //COFE
                curGoodOnChoose = 16;
                stuffPrice = 40;
                itemNameTxt.text = "KAFE";
                break;
            case 7:
                //BOBA
                curGoodOnChoose = 17;
                stuffPrice = 40;
                itemNameTxt.text = "BOBA";
                break;
            case 8:
                //ENERGY
                curGoodOnChoose = 18;
                stuffPrice = 50;
                itemNameTxt.text = "ENERGY DRINK";
                break;
            case 9:
                //LIQUOR
                curGoodOnChoose = 19;
                stuffPrice = 50;
                itemNameTxt.text = "LIQUOR";
                break;
        }
        OnShowConfirmbuy(curGoodOnChoose, stuffPrice);
    }
    public void OnIncreaseQuantity()
    {
        goodsQuantity++;
        quantityTxt.text = goodsQuantity.ToString();
        totalPriceTxt.text = (goodsQuantity * stuffPrice).ToString();
    }
    public void OnDecreaseQuantity()
    {
        if(goodsQuantity > 1)
        {
            goodsQuantity--;
        }
        quantityTxt.text = goodsQuantity.ToString();
        totalPriceTxt.text = (goodsQuantity * stuffPrice).ToString();
    }
    private void OnResetConfirmBuyPanel()
    {
        goodsQuantity = 1;
        curGoodOnChoose = -1;
        stuffPrice = 0;
        confirmBuyPnl.gameObject.SetActive(false);
    }
    public void OnConfirmBuyByMoney()
    {
        int tempCurrencyToUpdate;
        int tempCalPrice;
        tempCalPrice = stuffPrice * goodsQuantity;
        if (tempCalPrice <= dataCtr.pCurrency)
        {
            tempCurrencyToUpdate = dataCtr.pCurrency - (stuffPrice * goodsQuantity);
            dataCtr.UpdateTotalMoney(tempCurrencyToUpdate);
            UpdateShopUIs();
            if(curGoodOnChoose <= 9)
            {
                //Food
                dataCtr.OnSaveFoodInventory(curGoodOnChoose, goodsQuantity);
            }else if(curGoodOnChoose >= 10 && curGoodOnChoose <= 19)
            {
                //Drink
                dataCtr.OnSaveDrinkInventory(curGoodOnChoose - 10, goodsQuantity);
            }
            OnResetConfirmBuyPanel();

        }
        else
        {
            //Show warning out of money
            print("out of money");
        }
    }
    public void OnConfirmBuyByAds()
    {
        adsCtr.ShowAds(2);
        if (curGoodOnChoose <= 9)
        {
            //Food
            dataCtr.OnSaveFoodInventory(curGoodOnChoose, 1);
        }
        else if (curGoodOnChoose >= 10 && curGoodOnChoose <= 19)
        {
            //Drink
            print("in buy drink");
            dataCtr.OnSaveDrinkInventory(curGoodOnChoose - 10, 1);
        }
        UpdateShopUIs();
        OnResetConfirmBuyPanel();
    }
}
