using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSC : MonoBehaviour
{
    //[HideInInspector] PlayerInforSC infor;
    [SerializeField] SaveSystem saveSys;

    public string deviceID;
    public bool isFirstPlay;

    //Player's data variables
    //Player's data
    public string pName;
    public int pHighPetLevel, pCurrency,pGems;
    public int pSFX, pTheme;
    public int pAbility, pAllowClaimDaily, pDailyStreak;
    public string pLastDailyClaim;

    //Pet Data
    public string petName;
    public int petSpecieOrder, petOld, petGender, petSpecialAbilityOrder, petDied, petExperiment, petSickness;
    public int petHungryValue, petThirstyValue, petHappinessValue, petEnergyValue;

    //Inventroy Datas
    [HideInInspector] public int f01, f02, f03, f04, f05, f06, f07, f08, f09, f00;
    [HideInInspector] public int d01, d02, d03, d04, d05, d06, d07, d08, d09, d00;
    [HideInInspector] public int m01, m02, m03, m04, m05, m06, m07, m08, m09, m00;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        SettingStart();
    }
    void Start() { }
    void Update() { }

    #region Local Handle
    private void SettingStart()
    {
        deviceID = SystemInfo.deviceUniqueIdentifier;
        if (CheckFirstPlay() == true)
        {
            isFirstPlay = true;
            SetNewPlayer();
        }
        else if (CheckFirstPlay() == false)
        {
            isFirstPlay = false;
            LoadOldPlayer();
        }
    }

    #endregion

    #region Player Data Handle
    private void SetNewPlayer()
    {
        Debug.Log("in new player");
        string subStringID = deviceID.Substring(8, 12).ToString();
        string nameFistPlay = "Player" + subStringID;

        PlayerPrefs.SetString("PlayerName", nameFistPlay);

        PlayerPrefs.SetInt("HighPetLevel", 0); //For total overview, leaderboard
        PlayerPrefs.SetInt("Currency", 0); //Actual player in-game currency
        PlayerPrefs.SetInt("Gems", 0); //Player's PIA currency
        
        //Sound Handles
        PlayerPrefs.SetInt("soundState", 1);
        PlayerPrefs.SetInt("sfxState", 1);

        //Pet Special Ablity
        PlayerPrefs.SetInt("CurAblility", 0); //index of ability order in list. 0 is non

        //Patrol Reward
        PlayerPrefs.SetInt("AllowClaimDaily", 0);
        PlayerPrefs.SetString("LastPatrolDailyTime", "");
        PlayerPrefs.SetInt("PatrolDailyStreak", 0);

        //Pet statics
        PlayerPrefs.SetString("PetName", "");
        PlayerPrefs.SetInt("PetSpecie", 0);
        PlayerPrefs.SetInt("PetOld", 0);
        PlayerPrefs.SetInt("PetGender", 0);
        PlayerPrefs.SetInt("PetSpecialAbilityOrder", 0);
        PlayerPrefs.SetInt("PetHasDied", 0);
        PlayerPrefs.SetInt("PetExp", 0);
        PlayerPrefs.SetInt("PetSickness", 0);

        PlayerPrefs.SetInt("PetHungry", 50);
        PlayerPrefs.SetInt("PetThirsty", 50);
        PlayerPrefs.SetInt("PetHappy", 50);
        PlayerPrefs.SetInt("PetEnergy", 50);

        Invoke("LoadOldPlayer", 3f); //De tam thoi
    }
    private void LoadOldPlayer()
    {
        pName = PlayerPrefs.GetString("PlayerName");
        pHighPetLevel = PlayerPrefs.GetInt("HighPetLevel");
        pCurrency = PlayerPrefs.GetInt("Currency");
        pGems = PlayerPrefs.GetInt("Gems");
        pTheme = PlayerPrefs.GetInt("soundState");
        pSFX = PlayerPrefs.GetInt("sfxState");
        pAbility = PlayerPrefs.GetInt("CurAblility");

        //Patrol Reward
        pLastDailyClaim = PlayerPrefs.GetString("LastPatrolDailyTime");
        pAllowClaimDaily = PlayerPrefs.GetInt("AllowClaimDaily");
        pDailyStreak = PlayerPrefs.GetInt("PatrolDailyStreak");

        //Pet Data Hendle
        petName = PlayerPrefs.GetString("PetName");
        petSpecieOrder = PlayerPrefs.GetInt("PetSpecie"); 
        petOld = PlayerPrefs.GetInt("PetOld"); ;
        petGender = PlayerPrefs.GetInt("PetGender");
        petSpecialAbilityOrder = PlayerPrefs.GetInt("PetSpecialAbilityOrder");
        petHungryValue = PlayerPrefs.GetInt("PetHungry"); ;
        petThirstyValue = PlayerPrefs.GetInt("PetThirsty");
        petHappinessValue = PlayerPrefs.GetInt("PetHappy");
        petEnergyValue = PlayerPrefs.GetInt("PetEnergy");
        petDied = PlayerPrefs.GetInt("PetHasDied");
        petExperiment = PlayerPrefs.GetInt("PetExp");
        petSickness = PlayerPrefs.GetInt("PetSickness");
    }
    public void DataDelete()
    {
        PlayerPrefs.DeleteAll();
        SetNewPlayer();
        //infor.GetPlayerData();
    }
    public void UploadPlayerData()
    {

    }
    #endregion

    #region Player Data Update
    public void UpdateHasPlayed()
    {
        PlayerPrefs.SetInt("HasPlayed", 1);
    }
    public void UpdatePName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
        pName = PlayerPrefs.GetString("PlayerName");
    }
    public void UpdateHighScore(int petLevel)
    {
        PlayerPrefs.SetInt("HighPetLevel", petLevel);
        pHighPetLevel = PlayerPrefs.GetInt("HighPetLevel");
    }
    public void UpdateTotalMoney(int currency)
    {
        PlayerPrefs.SetInt("Currency", currency);
        pCurrency = PlayerPrefs.GetInt("Currency");
    }
    public void UpdateTotalGem(int gems)
    {
        PlayerPrefs.SetInt("Gems", gems);
        pGems = PlayerPrefs.GetInt("Gems");
    }
    public void UpdateSFXState(int sfxState)
    {
        PlayerPrefs.SetInt("sfxState", sfxState);
        pSFX = PlayerPrefs.GetInt("sfxState");
    }
    public void UpdateThemeState(int thameState)
    {
        PlayerPrefs.SetInt("soundState", thameState);
        pTheme = PlayerPrefs.GetInt("soundState");
    }

    public void UpdatePatrolDailyReward(string lastPatrolDaily)
    {
        PlayerPrefs.SetString("LastPatrolDailyTime", lastPatrolDaily);
        pLastDailyClaim = PlayerPrefs.GetString("LastPatrolDailyTime");
    }
    public void UpdateAllowClaimDaily(int state)
    {
        PlayerPrefs.SetInt("AllowClaimDaily", state);
        pAllowClaimDaily = PlayerPrefs.GetInt("AllowClaimDaily");
    }
    public void UpdateStreak(int typeStreak, int value)
    {
        switch (typeStreak)
        {
            case 1:
                PlayerPrefs.SetInt("PatrolDailyStreak", value);
                pDailyStreak = value;
                break;
        }
    }
    #endregion

    #region Pet Data UPdate
    public void UpdatePetName(string name)
    {
        PlayerPrefs.SetString("PetName", name);
        pLastDailyClaim = PlayerPrefs.GetString("PetName");
    }
    public void UpdatePetSpecie(int value)
    {
        PlayerPrefs.SetInt("PetSpecie", value);
        petSpecieOrder = PlayerPrefs.GetInt("PetSpecie");
    }
    public void UpdatePetOld(int value)
    {
        PlayerPrefs.SetInt("PetOld", value);
        petOld = PlayerPrefs.GetInt("PetOld");
    }
    public void UpdatePetGender(int value)
    {
        PlayerPrefs.SetInt("PetGender", value);
        petGender = PlayerPrefs.GetInt("PetGender");
    }
    public void UpdateAbility(bool isAbility)
    {
        if (isAbility == true)
        {
            PlayerPrefs.SetInt("PetSpecialAbilityOrder", 1);
            pAbility = PlayerPrefs.GetInt("PetSpecialAbilityOrder");
        }
        else if (isAbility == false)
        {
            PlayerPrefs.SetInt("PetSpecialAbilityOrder", 0);
            pAbility = PlayerPrefs.GetInt("PetSpecialAbilityOrder");
        }
    }
    public void UpdatePetHungry(int value)
    {
        //Only call while switch scene or needed to
        PlayerPrefs.SetInt("PetHungry", value);
        petHungryValue = PlayerPrefs.GetInt("PetHungry");
    }
    public void UpdatePetThirsty(int value)
    {
        //Only call while switch scene or needed to
        PlayerPrefs.SetInt("PetThirsty", value);
        petThirstyValue = PlayerPrefs.GetInt("PetThirsty");
    }
    public void UpdatePetHappy(int value)
    {
        //Only call while switch scene or needed to
        PlayerPrefs.SetInt("PetHappy", value);
        petHappinessValue = PlayerPrefs.GetInt("PetHappy");
    }
    public void UpdatePetenergy(int value)
    {
        //Only call while switch scene or needed to
        PlayerPrefs.SetInt("PetEnergy", value);
        petEnergyValue = PlayerPrefs.GetInt("PetEnergy");
    }
    public void UpdatePetDied(int value)
    {
        //Only call while pet Died
        PlayerPrefs.SetInt("PetHasDied", value);
        petDied = PlayerPrefs.GetInt("PetHasDied");
    }
    public void UpdatePetSickness(int value)
    {
        switch (value)
        {
            case 0:
                PlayerPrefs.SetInt("PetSickness", 0);
                petSickness = PlayerPrefs.GetInt("PetSickness");
                break;
            case 1:
                //Flu
                PlayerPrefs.SetInt("PetSickness", 1);
                petSickness = PlayerPrefs.GetInt("PetSickness");
                break;
            case 2:
                //Digestive
                PlayerPrefs.SetInt("PetSickness", 2);
                petSickness = PlayerPrefs.GetInt("PetSickness");
                break;
            case 3:
                //Stress
                PlayerPrefs.SetInt("PetSickness", 3);
                petSickness = PlayerPrefs.GetInt("PetSickness");
                break;
            case 4:
                //Respiratory Problems
                PlayerPrefs.SetInt("PetSickness", 4);
                petSickness = PlayerPrefs.GetInt("PetSickness");
                break;
            case 5:
                //Obesity
                PlayerPrefs.SetInt("PetSickness",5);
                petSickness = PlayerPrefs.GetInt("PetSickness");
                break;
            case 6:
                //Nutritional Problem
                PlayerPrefs.SetInt("PetSickness", 6);
                petSickness = PlayerPrefs.GetInt("PetSickness");
                break;
            case 7:
                //Parasite Infection
                PlayerPrefs.SetInt("PetSickness", 7);
                petSickness = PlayerPrefs.GetInt("PetSickness");
                break;
        }
    }
    public void UpdatePetExp(int value)
    {
        PlayerPrefs.SetInt("PetExp", value);
        petExperiment = PlayerPrefs.GetInt("PetExp");
    }
    #endregion

    #region Checking Zone
    public bool CheckFirstPlay()
    {
        //print("FirstPlay: " + PlayerPrefs.GetInt("HasPlayed"));
        if (PlayerPrefs.GetInt("HasPlayed") == 1)
        {
            return false;
        }
        else return true;
    }
    private bool CheckNewDay()
    {
        return true;
    }
    #endregion
    public void OnSaveFoodInventory(int index, int quantity)
    {
        int tempAmount = 0;
        switch (index)
        {
            case 0:
                tempAmount = f00;
                break;
            case 1:
                tempAmount = f01;
                break;
            case 2:
                tempAmount = f02;
                break;
            case 3:
                tempAmount = f03;
                break;
            case 4:
                tempAmount = f04;
                break;
            case 5:
                tempAmount = f05;
                break;
            case 6:
                tempAmount = f06;
                break;
            case 7:
                tempAmount = f07;
                break;
            case 8:
                tempAmount = f08;
                break;
            case 9:
                tempAmount = f09;
                break;
        }

        int[] a = { f00, f01, f02, f03, f04, f05, f06, f07, f08, f09 };
        print("index food = " + index);
        a[index] = tempAmount + quantity;
        saveSys.OnSaveFoodDatas(a);
        OnLoadInventory();
    }
    public void OnSaveDrinkInventory(int index, int quantity)
    {
        print("in save drink");
        int tempAmount = 0;
        switch (index)
        {
            case 0:
                tempAmount = d00;
                break;
            case 1:
                tempAmount = d01;
                break;
            case 2:
                tempAmount = d02;
                break;
            case 3:
                tempAmount = d03;
                break;
            case 4:
                tempAmount = d04;
                break;
            case 5:
                tempAmount = d05;
                break;
            case 6:
                tempAmount = d06;
                break;
            case 7:
                tempAmount = d07;
                break;
            case 8:
                tempAmount = d08;
                break;
            case 9:
                tempAmount = d09;
                break;
        }
        int[] a = { d00, d01, d02, d03, d04, d05, d06, d07, d08, d09 };
        print("index drink = " + index);
        a[index] = tempAmount + quantity;
        saveSys.OnSaveDrinkDatas(a);
        OnLoadInventory();
    }
    public void OnSaveMedicineInventory(int index, int quantity)
    {
        switch (index)
        {
            case 0:
                m00 = quantity;
                break;
            case 1:
                m01 = quantity;
                break;
            case 2:
                m02 = quantity;
                break;
            case 3:
                m03 = quantity;
                break;
            case 4:
                m04 = quantity;
                break;
            case 5:
                m05 = quantity;
                break;
            case 6:
                m06 = quantity;
                break;
            case 7:
                m07 = quantity;
                break;
            case 8:
                m08 = quantity;
                break;
            case 9:
                m09 = quantity;
                break;
        }
        int[] a = { m00, m01, m02, m03, m04, m05, m06, m07, m08, m09 };
        a[index] = quantity;
        saveSys.OnSaveFoodDatas(a);
    }
    public void OnLoadInventory()
    {
        InventoryData inven = saveSys.Load();
        f00 = inven.foodDatas[0];
        f01 = inven.foodDatas[1];
        f02 = inven.foodDatas[2];
        f03 = inven.foodDatas[3];
        f04 = inven.foodDatas[4];
        f05 = inven.foodDatas[5];
        f06 = inven.foodDatas[6];
        f07 = inven.foodDatas[7];
        f08 = inven.foodDatas[8];
        f09 = inven.foodDatas[9];

        d00 = inven.drinkDatas[0];
        d01 = inven.drinkDatas[1];
        d02 = inven.drinkDatas[2];
        d03 = inven.drinkDatas[3];
        d04 = inven.drinkDatas[4];
        d05 = inven.drinkDatas[5];
        d06 = inven.drinkDatas[6];
        d07 = inven.drinkDatas[7];
        d08 = inven.drinkDatas[8];
        d09 = inven.drinkDatas[9];

        m00 = inven.medicinesDatas[0];
        m01 = inven.medicinesDatas[1];
        m02 = inven.medicinesDatas[2];
        m03 = inven.medicinesDatas[3];
        m04 = inven.medicinesDatas[4];
        m05 = inven.medicinesDatas[5];
        m06 = inven.medicinesDatas[6];
        m07 = inven.medicinesDatas[7];
        m08 = inven.medicinesDatas[8];
        m09 = inven.medicinesDatas[9];
    }
}
