using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CareController : MonoBehaviour
{
    Vector3 mousePos;
    [HideInInspector] DataSC dataCtr;
    [SerializeField] List<GameObject> food = new List<GameObject>();
    [SerializeField] List<GameObject> drinks = new List<GameObject>();
    [SerializeField] List<GameObject> meds = new List<GameObject>();

    [SerializeField] List<Text> foodAmount = new List<Text>();
    [SerializeField] List<Text> drinkamount = new List<Text>();
    [SerializeField] List<Text> medsAmount = new List<Text>();

    [SerializeField] GameObject showerHandle, soap;

    private void Start()
    {
        dataCtr = GameObject.Find("GenMN").GetComponent<DataSC>();
        LoadItemsUIs();
    }

    public void OnSpawnFood(int foodToSpawn)
    {
        if (foodAmount[foodToSpawn].text != "0")
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(food[foodToSpawn], mousePos, Quaternion.identity);
            OnHandleDecreaseItemAmount(0, foodToSpawn);
        }
    }
    public void OnSpawnDrink(int drinkToSpawn)
    {
        if (drinkamount[drinkToSpawn].text != "0")
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(drinks[drinkToSpawn], mousePos, Quaternion.identity);
            OnHandleDecreaseItemAmount(1, drinkToSpawn);
        }
    }
    public void OnSpawnMed(int medToSpawn)
    {
        if (medsAmount[medToSpawn].text != "0")
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(meds[medToSpawn], mousePos, Quaternion.identity);
            OnHandleDecreaseItemAmount(2, medToSpawn);
        }
    }
    #region bathing
    public void OnSpawnSoap()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(soap, mousePos, Quaternion.identity);
    }
    public void OnSpawnShower()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(showerHandle, mousePos, Quaternion.identity);
    }
    #endregion

    #region Load & Update Items
    private void LoadItemsUIs()
    {
        print("in load Item UI");
        foodAmount[0].text = dataCtr.f00.ToString();
        foodAmount[1].text = dataCtr.f01.ToString();
        foodAmount[2].text = dataCtr.f02.ToString();
        foodAmount[3].text = dataCtr.f03.ToString();
        foodAmount[4].text = dataCtr.f04.ToString();
        foodAmount[5].text = dataCtr.f05.ToString();
        foodAmount[6].text = dataCtr.f06.ToString();
        foodAmount[7].text = dataCtr.f07.ToString();
        foodAmount[8].text = dataCtr.f08.ToString();
        foodAmount[9].text = dataCtr.f09.ToString();

        drinkamount[0].text = dataCtr.d00.ToString();
        drinkamount[1].text = dataCtr.d01.ToString();
        drinkamount[2].text = dataCtr.d02.ToString();
        drinkamount[3].text = dataCtr.d03.ToString();
        drinkamount[4].text = dataCtr.d04.ToString();
        drinkamount[5].text = dataCtr.d05.ToString();
        drinkamount[6].text = dataCtr.d06.ToString();
        drinkamount[7].text = dataCtr.d07.ToString();
        drinkamount[8].text = dataCtr.d08.ToString();
        drinkamount[9].text = dataCtr.d09.ToString();

        medsAmount[0].text = dataCtr.m00.ToString();
        medsAmount[1].text = dataCtr.m01.ToString();
        medsAmount[2].text = dataCtr.m02.ToString();
        medsAmount[3].text = dataCtr.m03.ToString();
        medsAmount[4].text = dataCtr.m04.ToString();
        medsAmount[5].text = dataCtr.m05.ToString();
        medsAmount[6].text = dataCtr.m06.ToString();
        medsAmount[7].text = dataCtr.m07.ToString();
        medsAmount[8].text = dataCtr.m08.ToString();
        medsAmount[9].text = dataCtr.m09.ToString();
    }
    private void OnHandleDecreaseItemAmount(int type, int index)
    {
        if (type == 0)
        {

            switch (index)
            {
                case 0:
                    dataCtr.f00 -= 1;
                    dataCtr.OnSaveFoodInventory(0, 0);
                    break;
                case 1:
                    dataCtr.f01 -= 1;
                    dataCtr.OnSaveFoodInventory(1, 0);
                    break;
                case 2:
                    dataCtr.f02 -= 1;
                    dataCtr.OnSaveFoodInventory(2, 0);
                    break;
                case 3:
                    dataCtr.f03 -= 1;
                    dataCtr.OnSaveFoodInventory(3, 0);
                    break;
                case 4:
                    dataCtr.f04 -= 1;
                    dataCtr.OnSaveFoodInventory(4, 0);
                    break;
                case 5:
                    dataCtr.f05 -= 1;
                    dataCtr.OnSaveFoodInventory(5, 0);
                    break;
                case 6:
                    dataCtr.f06 -= 1;
                    dataCtr.OnSaveFoodInventory(6, 0);
                    break;
                case 7:
                    dataCtr.f07 -= 1;
                    dataCtr.OnSaveFoodInventory(7, 0);
                    break;
                case 8:
                    dataCtr.f08 -= 1;
                    dataCtr.OnSaveFoodInventory(8, 0);
                    break;
                case 9:
                    dataCtr.f09 -= 1;
                    dataCtr.OnSaveFoodInventory(9, 0);
                    break;

            }
        }
        else if (type == 1)
        {

            switch (index)
            {
                case 0:
                    dataCtr.d00 -= 1;
                    dataCtr.OnSaveDrinkInventory(0, 0);
                    break;
                case 1:
                    dataCtr.d01 -= 1;
                    dataCtr.OnSaveDrinkInventory(1, 0);
                    break;
                case 2:
                    dataCtr.d02 -= 1;
                    dataCtr.OnSaveDrinkInventory(2, 0);
                    break;
                case 3:
                    dataCtr.d03 -= 1;
                    dataCtr.OnSaveDrinkInventory(3, 0);
                    break;
                case 4:
                    dataCtr.d04 -= 1;
                    dataCtr.OnSaveDrinkInventory(4, 0);
                    break;
                case 5:
                    dataCtr.d05 -= 1;
                    dataCtr.OnSaveDrinkInventory(5, 0);
                    break;
                case 6:
                    dataCtr.d06 -= 1;
                    dataCtr.OnSaveDrinkInventory(6, 0);
                    break;
                case 7:
                    dataCtr.d07 -= 1;
                    dataCtr.OnSaveDrinkInventory(7, 0);
                    break;
                case 8:
                    dataCtr.d08 -= 1;
                    dataCtr.OnSaveDrinkInventory(8, 0);
                    break;
                case 9:
                    dataCtr.d00 -= 1;
                    dataCtr.OnSaveDrinkInventory(9, 0);
                    break;
            }
        }
        else if (type == 2) 
        {

        }
        LoadItemsUIs();
    }
    #endregion
}
