using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GenMNSC : Singleton<GenMNSC>
{
    [SerializeField] List<GameObject> panelList = new List<GameObject>();

    [SerializeField] DataSC data;
    [SerializeField] GameObject notificationPnl;
    [SerializeField] AdsMN adsCtr;
    [SerializeField] SoundSC sfxCtr;
    [SerializeField] MainThemeSC themeCtr;
    [SerializeField] DatabaseManager dbMN;
    [HideInInspector] public int deviceType, curGameState;
    [HideInInspector] public string toDay;

    //Pet's Data
    [HideInInspector]
    public string petName;
    [HideInInspector]
    public int petSpecie, petOld, petGender, petDied, petSickCondition, petExp;
    [HideInInspector]
    public int petHungerLvl, petThirstyLvl, petHappyLvl, petEnergyLvl;
    public int curGameScene;
    private int countToInterstialShow;
    private void Awake() => DontDestroyOnLoad(this);
    [SerializeField] SceneMN sceneCtr;
    void Start()
    {
        dbMN = GameObject.Find("GenMN").GetComponent<DatabaseManager>();
        sceneCtr = GameObject.Find("GenMN").GetComponent<SceneMN>();
        data = GameObject.Find("GenMN").GetComponent<DataSC>();
        adsCtr = GameObject.Find("AdsMN").GetComponent<AdsMN>();
        if (Application.platform == RuntimePlatform.Android
                   || Application.platform == RuntimePlatform.IPhonePlayer) { deviceType = 1; }//Mobile
        else if (Application.platform == RuntimePlatform.WindowsEditor
            || Application.platform == RuntimePlatform.WindowsPlayer
            || Application.platform == RuntimePlatform.WebGLPlayer) { deviceType = 2; }//Window & Web
        HideAllPanel();
        toDay = (DateTime.Today.Day).ToString() ;
        countToInterstialShow = 0;
    }

    #region Handle Switching Scene
    public void OnChangeScene(int scenOrder)
    {
        countToInterstialShow++;
        if(countToInterstialShow >= 5)
        {
            adsCtr.ShowAds(1);
            countToInterstialShow = 0;
        }
        curGameState = scenOrder;
        curGameScene = curGameState;
        sceneCtr.OnLoadScene(scenOrder);
    }
    #endregion

    #region Panels Visible
    void IsShowPanel(bool isShow, int panel)
    {
        //0 = notification
        //1 = setting
        //2 = mechanic shop
        //3 = rate us
        //4 = credit
        //5 = promotion panel
        //6 = read me
        //7 = pet infor
        panelList[panel].SetActive(isShow);
    }
    public void OnShowNotic() => IsShowPanel(true, 0);
    public void OnShowSetting() => IsShowPanel(true, 1);
    public void OnShowRate() => IsShowPanel(true, 3);
    public void OnShowCredit() => IsShowPanel(true, 4);
    public void OnShowPromotion() => IsShowPanel(true, 5);
    public void OnShowReadme() => IsShowPanel(true, 6);
    public void OnShowPetInfor() => IsShowPanel(true, 7);
    public void OnHideNotic() => IsShowPanel(false, 0);
    public void OnHideSetting() => IsShowPanel(false, 1);
    public void OnHideRate() => IsShowPanel(false, 3);
    public void OnHideCredit() => IsShowPanel(false, 4);
    public void OnHidePromotion() => IsShowPanel(false, 5);
    public void OnHideReadMe() => IsShowPanel(false, 6);
    public void OnHidePetInfor() => IsShowPanel(false, 7);
    private void HideAllPanel()
    {
        OnHideNotic();
        OnHidePromotion();
        OnHideSetting();
        OnHideRate();
        OnHideCredit();
        OnHideReadMe();
        OnHidePetInfor();
    }
    #endregion

    public void OnGeneratePet(string petName, int petSpecie, int petOld, int petGender, bool petAbility)
    {
        data.UpdatePetName(petName);
        data.UpdatePetSpecie(petSpecie);
        data.UpdatePetOld(petOld);
        data.UpdatePetGender(petGender);
        data.UpdateAbility(petAbility);
        data.UpdateHasPlayed();
        string tempString;
        tempString = "F01";
        dbMN.AddItem(tempString, 10);
    }
    public void OnLoadPet()
    {
        petName = data.petName;
        petSpecie = data.petSpecieOrder;
        petOld = data.petOld;
        petGender = data.petGender;
        petDied = data.petDied;
        petSickCondition = data.petSickness;
        petExp = data.petExperiment;

        petHungerLvl = data.petHungryValue;
        petThirstyLvl = data.petThirstyValue;
        petHappyLvl = data.petHappinessValue;
        petEnergyLvl = data.petEnergyValue;
    }
    public void PlaySFX()
    {
        if(data.pSFX == 1) { sfxCtr.PlaySFX(); }
    }
}
