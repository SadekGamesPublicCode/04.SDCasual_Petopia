using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemSC : MonoBehaviour
{
    [HideInInspector] DataSC dataCtr;
    [HideInInspector] GenMNSC genCtr;
    [HideInInspector] internal PetShopMNSC shopCtr;
    [HideInInspector] internal MainSC mainCtr;
    [HideInInspector] internal int nutritionValue, happinessFact, energyFact;
    internal int gameMode;
    [HideInInspector] Vector3 mousePos;
    protected virtual void Start()
    {
        dataCtr = GameObject.Find("GenMN").GetComponent<DataSC>();
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        gameMode = genCtr.curGameScene;
        if (gameMode == 2)
        {
            mainCtr = GameObject.Find("HomeMN").GetComponent<MainSC>();
        }
        else if (gameMode == 3)
        {
            shopCtr = GameObject.Find("PetShopMN").GetComponent<PetShopMNSC>();
        }
    }
    void Update()
    {
        if(gameMode == 2)
        {
            if (genCtr.deviceType == 1)
            {
                //Touch
                if (Input.touchCount > 0)
                {
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get current position of mouse on screen
                    mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
                    Vector3 temp = Vector3.Lerp(transform.position, mousePos, 100 * Time.deltaTime);
                    transform.position = temp;
                }
            }
            else if (genCtr.deviceType == 2)
            {
                //Key board
                if (Input.GetMouseButton(0) == true)
                {
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
                    transform.position = mousePos;
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pet")
        {
            OnCaculatingPetStat(nutritionValue, happinessFact, energyFact);
               Destroy(gameObject);
        }
    }
    internal void OnCaculatingPetStat(int a, int b, int c)
    {
        int tempHungerValue;
        int tempHappyValue;
        int tempEnergyValue;

        tempHungerValue = dataCtr.petHungryValue + a;
        tempHappyValue = dataCtr.petHappinessValue + b;
        tempEnergyValue = dataCtr.petEnergyValue + c;

        dataCtr.UpdatePetHungry(tempHungerValue);
        dataCtr.UpdatePetHappy(tempHappyValue);
        dataCtr.UpdatePetenergy(tempEnergyValue);
    }
}
