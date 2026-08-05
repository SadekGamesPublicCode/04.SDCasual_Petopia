using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PetInfoSC : MonoBehaviour
{
    private string pName;
    private int pOld, pExp, pSps, pGender;
    private int pHunger, pThirsty, pHappy, pEnergy, pCondition, pDied;

    [HideInInspector] DataSC petData;
    [SerializeField] Text petNameTxt, petOldTxt, petSpecieTxt, petGenderTxt, petExpTxt;
    [SerializeField] Text petHUngerTxt, petThirstyTxt, petHappyTxt, petEnergyTxt, petConditionTxt;
    int petStatValue;
    private void Awake()
    {
        petData = GameObject.Find("GenMN").GetComponent<DataSC>();
    }
    void Start()
    {
        petStatValue = 0;
        OnCollectData();
    }
    private void OnEnable() 
    {
        OnCollectData();
        OnOverridePetData();
    }
    void OnCollectData()
    {
        pName = petData.petName;
        pOld = petData.petOld;
        pExp = petData.petExperiment;
        pSps = petData.petSpecieOrder;
        pGender = petData.petGender;

        pHunger = petData.petHungryValue;
        pThirsty = petData.petThirstyValue;
        pHappy = petData.petHappinessValue;
        pEnergy = petData.petEnergyValue;
        pDied = petData.petDied;

        OnOverridePetData();
    }
    private void OnOverridePetData()
    {
        petNameTxt.text = pName;
        switch (pSps)
        {
            case 1:
                petSpecieTxt.text = "DOG";
                break;
            case 2:
                petSpecieTxt.text = "CAT";
                break;
            case 3:
                petSpecieTxt.text = "RABBIT";
                break;
            case 4:
                petSpecieTxt.text = "FISH";
                break;
        }
        petOldTxt.text = pOld.ToString();
        switch (pGender)
        {
            case 0:
                petGenderTxt.text = "MALE";
                break;
            case 1:
                petGenderTxt.text = "FEMALE";
                break;
        }
        petExpTxt.text = pExp.ToString();

        petHUngerTxt.text = pHunger.ToString();
        petThirstyTxt.text = pThirsty.ToString();
        petHappyTxt.text = pHappy.ToString();
        petEnergyTxt.text = pEnergy.ToString();

        petStatValue = (pHunger + pThirsty + pHappy + pEnergy)/4;
        if (pDied == 0)
        {
            if(petStatValue >= 75)
            {
                petConditionTxt.text = "Very Good";
            }
            else if(petStatValue >= 50 && petStatValue < 75)
            {
                petConditionTxt.text = "Normal";
            }
            else if (petStatValue >= 25 && petStatValue < 50)
            {
                petConditionTxt.text = "Unhappy";
            }
            else if(petStatValue < 25)
            {
                petConditionTxt.text = "Bad";
            }
        }else if(pDied == 1)
        {
            petConditionTxt.text = "Died";
        }
    }
}
