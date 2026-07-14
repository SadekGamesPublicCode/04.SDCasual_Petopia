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
    private void Awake()
    {
        petData = GameObject.Find("GenMN").GetComponent<DataSC>();
    }
    void Start()
    {

        OnCollectData();
    }
    private void OnEnable() 
    {
        OnCollectData();
        OnOverridePetData();
    }
    void OnCollectData()
    {
        pName = petData.pName;
        pOld = petData.petOld;
        pExp = petData.petExperiment;
        pSps = petData.petSpecieOrder;
        pGender = petData.petGender;

        pHunger = petData.petHungryValue;
        pThirsty = petData.petThirstyValue;
        pHappy = petData.petHappinessValue;
        pEnergy = petData.petEnergyValue;
        pDied = petData.petDied;
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
            case 1:
                petGenderTxt.text = "MALE";
                break;
            case 2:
                petGenderTxt.text = "FEMALE";
                break;
            case 3:
                petGenderTxt.text = "PRIDE";
                break;
        }
        petExpTxt.text = pExp.ToString();

        petHUngerTxt.text = pHunger.ToString();
        petThirstyTxt.text = pThirsty.ToString();
        petHappyTxt.text = pHappy.ToString();
        petEnergyTxt.text = pEnergy.ToString();
        if(pDied == 0)
        {
            switch (pCondition)
            {
                case 0:
                    //Good
                    petConditionTxt.text = "Very Good";
                    break;
                case 1:
                    //Flu
                    petConditionTxt.text = "Flu";
                    break;
                case 2:
                    //Digestive
                    petConditionTxt.text = "Digestive";
                    break;
                case 3:
                    //Stress
                    petConditionTxt.text = "Stress";
                    break;
                case 4:
                    //Respiratory Problems
                    petConditionTxt.text = "Respiratory Problems";
                    break;
                case 5:
                    //Obesity
                    petConditionTxt.text = "Obesity";
                    break;
                case 6:
                    //Nutritional Problem
                    petConditionTxt.text = "Nutritional Problem";
                    break;
                case 7:
                    //Parasite Infection
                    petConditionTxt.text = "Parasite Infection";
                    break;
            }
        }else if(pDied == 1)
        {
            petConditionTxt.text = "Died";
        }
    }
}
