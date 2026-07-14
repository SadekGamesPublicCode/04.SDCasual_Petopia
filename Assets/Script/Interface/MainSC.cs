using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSC : MonoBehaviour
{
    Vector3 mousePos;
    [HideInInspector] GenMNSC genCtr;
    [HideInInspector] DataSC data;
    [SerializeField] InventorySC inventoryPanels;
    public Text mouseCoordinate;

    //Pet Prefabs
    [SerializeField] GameObject dogPre, catPre, rabbitPre, fishPre;

    //UIs
    [SerializeField] Text gCoinTxt;
    [SerializeField] Image imgHungry, imgThirsty, imgEnergy, imgHappy;
    [SerializeField] GameObject inventoryFood, inventoryDrink, inventoryMedicine;
    [SerializeField] GameObject achievePnl, patrolRewardPnl, petInforPnl;
    //Pet Statics
    private string gName;
    public int gSpecie, gGender, gOld, gColor, gPetDied, gPetSickCon, gPetExp;
    private int gHungry, gThirsty, gEnergy, gHappy;

    //Gameplay Statics
    private int gCoin;
    public int shitStayOnScreen;
    void Start()
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        data = GameObject.Find("GenMN").GetComponent<DataSC>();
        inventoryPanels = GameObject.Find("PNL_Invetories").GetComponent<InventorySC>();

        gName = genCtr.petName;
        gSpecie = genCtr.petSpecie;
        gOld = genCtr.petOld;
        gGender = genCtr.petGender;
        gPetDied = genCtr.petDied;
        gPetExp = genCtr.petExp;

        gHungry = genCtr.petHungerLvl;
        gThirsty = genCtr.petThirstyLvl;
        gHappy = genCtr.petHappyLvl;
        gEnergy = genCtr.petEnergyLvl;
        gCoin = data.pCurrency;

        InvokeRepeating(nameof(UpdatePetStats), 0f, 60f);
        InitGameEnviroment();
        OnhidePanels();
    }
    private void InitGameEnviroment()
    {
        gCoinTxt.text = gCoin.ToString();
        imgHungry.fillAmount = gHungry / 100;
        imgThirsty.fillAmount = gThirsty / 100;
        imgHappy.fillAmount = gThirsty / 100;
        imgEnergy.fillAmount = gEnergy / 100;

        switch (gSpecie)
        {
            case 0:
                //dog
                Instantiate(dogPre, Vector3.zero, Quaternion.identity);
                break;
            case 1:
                //cat
                Instantiate(catPre, Vector3.zero, Quaternion.identity);
                break;
            case 3:
                //rabbit
                Instantiate(rabbitPre, Vector3.zero, Quaternion.identity);
                break;
            case 4:
                //fish
                Instantiate(fishPre, Vector3.zero, Quaternion.identity);
                break;
        }
    }
    public void UpdateUIs()
    {
        gCoinTxt.text = gCoin.ToString();
        imgHungry.fillAmount = gHungry / 100f;
        imgThirsty.fillAmount = gThirsty / 100f;
        imgHappy.fillAmount = gThirsty / 100f;
        imgEnergy.fillAmount = gEnergy / 100f;
    }

    #region Handle Gameplay Stats
    public void OnPlusCoin(int a)
    {
        int temp;
        temp = gCoin;
        gCoin = temp + a;
        UpdateUIs();
        data.UpdateTotalMoney(gCoin);
    }
    public void OnUpdateHunger(int state, int a)
    {
        if (state == 0)
        {
            data.UpdatePetHungry(a);
        }
        else if (state == 1)
        {
            gHungry = data.petHungryValue;
        }
            UpdateUIs();
    }
    public void OnUpdateThirsty(int state, int a)
    {
        if (state == 0)
        {
            data.UpdatePetThirsty(a);
        }else if(state == 1)
        {
            gThirsty = data.petThirstyValue;

        }
        UpdateUIs();
    }
    public void OnUpdateHappy(int state, int a)
    {
        if(state == 0) { data.UpdatePetHappy(a);}
        else if(state == 1) { gHappy = data.petHappinessValue; }
        UpdateUIs();
    }
    public void OnUpdateEnergy(int state, int a)
    {
        if (state == 0) { data.UpdatePetHappy(a); }
        else if (state == 1) { gEnergy = data.petEnergyValue; }
            UpdateUIs();
    }
    public void OnUpdateOld(int a)
    {
        gOld = a;
        data.UpdatePetOld(a);
        data.UpdatePetOld(gOld);
    }
    public void OnUpdateSleep()
    {
        //Let pet sleep
    }
    public void UpdateShitStayOnScreen(int a)
    {
        shitStayOnScreen += a;
    }
    public void UpdateDied(bool died)
    {
        if(died == true)
        {
            gPetDied = 1;
            genCtr.petDied = 1;
            data.UpdatePetDied(genCtr.petDied);
        }else if(died == false)
        {
            gPetDied = 0;
            genCtr.petDied = 0;
            data.UpdatePetDied(genCtr.petDied);
        }
    }
    private void UpdatePetStats()
    {
        data.UpdatePetHungry(gHungry);
        data.UpdatePetThirsty(gThirsty);
        data.UpdatePetHappy(gHappy);
        data.UpdatePetenergy(gEnergy);
    }
    #endregion

    #region set order of inventory panel
    public void OnShetOrderFood()
    {
        inventoryPanels.showOrder = 1;
        inventoryPanels.OnSetInevntoryPanel();
    }
    public void OnShetOrderDrink()
    {
        inventoryPanels.showOrder = 2;
        inventoryPanels.OnSetInevntoryPanel();
    }
    public void OnShetOrderMed()
    {
        inventoryPanels.showOrder = 3;
        inventoryPanels.OnSetInevntoryPanel();
    }
    public void OnSetOrderShower()
    {
        inventoryPanels.showOrder = 4;
        inventoryPanels.OnSetInevntoryPanel();
    }
    #endregion

    public void OnShowSetting() => genCtr.OnShowSetting();
    private void OnhidePanels()
    {
        OnShowAchievement(false);
        OnShowDailyPatrol(false);

        inventoryFood.gameObject.SetActive(false);
        inventoryDrink.gameObject.SetActive(false);
        inventoryMedicine.gameObject.SetActive(false);
    }
    public void OnShowAchievement(bool isShow) => achievePnl.gameObject.SetActive(isShow);
    public void OnShowDailyPatrol(bool isShow) => patrolRewardPnl.gameObject.SetActive(isShow);
    public void OnShowPetInfor() => genCtr.OnShowPetInfor();
    public void OnGoOutside()
    {
        genCtr.OnChangeScene(5);
    }
    public void OnToPetShop()
    {
        genCtr.OnChangeScene(3);
    }
    public void OnToVet()
    {
        genCtr.OnChangeScene(4);
    }
}
