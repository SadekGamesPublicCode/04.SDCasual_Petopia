using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PetSC : MonoBehaviour
{
    [HideInInspector] GenMNSC genCtr;
    [HideInInspector] DataSC dataCtr;
    [HideInInspector] MainSC gameMainCtr;
    [SerializeField] internal List<Sprite> petVisual = new List<Sprite>();
    [SerializeField] List<GameObject> shitSpawn = new List<GameObject>();
    internal int color, curScene;
    Vector3 mousePos;

    //Pet Valua
    private Vector3 curPos;
    internal int hungryValue, thirstyValue, energyValue, happuValue, specie;
    internal int waitTimeForNextPoop;
    internal int sicknessOrder, chanceToSick;
    internal int oldLevel, expLv, expLvTarget;
    internal bool isDied, isSleep, isSick;
    internal int petChance;

    //Game mechinc control
    private int soapCountSwipe;
    protected virtual void Start()
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        dataCtr = GameObject.Find("GenMN").GetComponent<DataSC>();
        curScene = genCtr.curGameState;
        if (curScene != 1)
        {
            gameMainCtr = GameObject.Find("HomeMN").GetComponent<MainSC>();
            CollectPetData();
            RandTimeNextPoop();
            InvokeRepeating(nameof(OnHungry), 0, 60);
            InvokeRepeating(nameof(OnThirsty), 0, 180);
            InvokeRepeating(nameof(MovingAround), 0, 3.5f);
            InvokeRepeating(nameof(OnShit), 25, waitTimeForNextPoop);
        }
        soapCountSwipe = 0;
    }
    internal void Update()
    {
        if (genCtr.deviceType == 1 && IsAllowPeting() == true)
        {
            //Touch
            if (Input.touchCount > 0)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get current position of mouse on screen
                mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
                Vector3 temp = Vector3.Lerp(transform.position, mousePos, 100 * Time.deltaTime);
                if(IsAllowPeting() == true)
                {
                    transform.position = temp;
                    //Do peting animation
                }
                else
                {
                    transform.position = new Vector3(temp.x -1, temp.y -1, 0f);
                }
            }
        }
        else if (genCtr.deviceType == 2 && IsAllowPeting() == true)
        {
            //Key board
            if (Input.GetMouseButton(0) == true)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
                if (IsAllowPeting() == true)
                {
                    transform.position = mousePos;
                    //Do peting animation
                }
                else
                {
                    transform.position = new Vector3(mousePos.x - 1, mousePos.y - 1, 0f);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            Feeding();
        }else if(collision.gameObject.tag == "Drink")
        {
            Drinking();
        }else if(collision.gameObject.tag == "Med")
        {
            Curing();
        }else if(collision.gameObject.tag == "Soap")
        {
            Washing();
        }
    }
    #region Initing Pet
    void CollectPetData()
    {
        color = gameMainCtr.gColor;
        hungryValue = dataCtr.petHungryValue;
        thirstyValue = dataCtr.petThirstyValue;
        happuValue = dataCtr.petHappinessValue;
        energyValue = dataCtr.petEnergyValue;
        oldLevel = genCtr.petOld;
        specie = genCtr.petSpecie;
        sicknessOrder = genCtr.petSickCondition;
        if(sicknessOrder != 0) { isSick = true; }
        if(genCtr.petDied == 0) { isDied = false; }
        else if(genCtr.petDied == 1) { isDied = true; }

        expLvTarget = oldLevel * 100;

        waitTimeForNextPoop = 0;

        curPos = gameObject.transform.position;
        InitPetVisual();
    }
    void InitPetVisual()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = petVisual[0];
    }
    #endregion

    #region Pet behaviour
    void RandTimeNextPoop() => waitTimeForNextPoop = Random.Range(0, 100); //0 to 100 Seconds
    void OnShit()
    {
        Vector3 shitSpawnPos;
        int tempX, tempY;
        tempX = Random.Range((int)transform.position.x - 1, (int)transform.position.x + 1);
        tempY = Random.Range((int)transform.position.y - 1, (int)transform.position.y + 1);
        shitSpawnPos = new Vector3(tempX, tempY, 0);
        if (happuValue > 50 && happuValue <= 100)
        {
            int rainbowChance;
            rainbowChance = Random.Range(0, 100);
            if(rainbowChance >= 95)
            {
                Instantiate(shitSpawn[3], shitSpawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(shitSpawn[0], shitSpawnPos, Quaternion.identity);
            }
        }
        else if (happuValue > 25 && happuValue <= 50)
        {
            Instantiate(shitSpawn[1], shitSpawnPos, Quaternion.identity);
        }
        else if (happuValue > 0 && happuValue <= 25)
        {
            Instantiate(shitSpawn[2], shitSpawnPos, Quaternion.identity);
        }
        RandTimeNextPoop();
        gameMainCtr.UpdateShitStayOnScreen(1);
        OnCheckHappy();
    }
    void OnHungry()
    {
        if(isDied == false && hungryValue > 0)
        {
            hungryValue = dataCtr.petHungryValue;
            hungryValue--;
            gameMainCtr.OnUpdateHunger(0, hungryValue);
            if(hungryValue <= 0)
            {
                OnDied();
            }
        }
    }
    void OnThirsty()
    {
        if(isDied == false)
        {
            thirstyValue = dataCtr.petThirstyValue;
            thirstyValue--;
            gameMainCtr.OnUpdateThirsty(0, thirstyValue);
            if (thirstyValue <= 0)
            {
                OnDied();
            }
        }
    }
    void OnCheckHappy()
    {
        if(gameMainCtr.shitStayOnScreen == 0) 
        {
            chanceToSick = 0;
            happuValue = 100;
            OnSick();
        }
        else if(gameMainCtr.shitStayOnScreen > 0 && gameMainCtr.shitStayOnScreen <= 10) 
        {
            chanceToSick = 5;
            happuValue = 75;
            OnSick();
        }
        else if(gameMainCtr.shitStayOnScreen > 10 && gameMainCtr.shitStayOnScreen <= 20) 
        {
            chanceToSick = 25;
            happuValue = 45;
            OnSick();
        }
        else if(gameMainCtr.shitStayOnScreen > 20) 
        {
            chanceToSick = 50;
            happuValue = 10;
            OnSick();
        }
        gameMainCtr.OnUpdateHappy(1, happuValue);
    }
    void OnSick()
    {
        if(chanceToSick == 5)
        {

        }
    }
    void OnDied()
    {
        isDied = true;
        gameMainCtr.UpdateDied(isDied);
        //Update sprite
    }
    void MovingAround()
    {
        float tempNewPosX, tempNewPosY;

        do
        {
            tempNewPosX = Random.Range(curPos.x - 1, curPos.x + 1);
        } while (tempNewPosX > 2 || tempNewPosX < -2);
        do
        {
            tempNewPosY = Random.Range(curPos.y - 1, curPos.y + 1);
        } while (tempNewPosY > 2 || tempNewPosY < -2);
        gameObject.transform.DOMove(new Vector3(tempNewPosX, tempNewPosY,0), 1f);
        curPos = new Vector3(tempNewPosX, tempNewPosY, 0);
    }
    void OnAgingUp()
    {
        oldLevel++;
        expLvTarget = oldLevel * 100;
        if(oldLevel >= 50)
        {
            //Load mature sprite
        }else if(oldLevel >= 75)
        {
            //Load old sprite
        }else if(oldLevel >= 100)
        {
            //Load dead sprte
        }
    }
    void Feeding()
    {
        //Check correct food
        //Id food correct -> Consume else refuse
        //HungerLevel minus
        expLv++;
        hungryValue++;
        happuValue++;

        if(expLv >= expLvTarget) { OnAgingUp(); }
        else if(hungryValue >= 100) { hungryValue = 100; }

        gameMainCtr.OnPlusCoin(3);
        gameMainCtr.OnUpdateHunger(1, 0);
        gameMainCtr.OnPlaySoundSFX();
    }
    void Drinking()
    {
        expLv++;
        thirstyValue++;
        happuValue++;

        if (expLv >= expLvTarget) { OnAgingUp(); }
        else if (thirstyValue >= 100) { thirstyValue = 100; }

        gameMainCtr.OnPlusCoin(3);
        gameMainCtr.OnUpdateThirsty(1,0);
        gameMainCtr.OnPlaySoundSFX();
    }
    void Curing()
    {
        gameMainCtr.OnPlusCoin(10);
    }
    void Washing()
    {
        soapCountSwipe++;
        expLv++;
        happuValue++;
        energyValue++;
        gameMainCtr.OnPlusCoin(1);
        gameMainCtr.OnUpdateHappy(1, 0);
        gameMainCtr.OnPlaySoundSFX();
    }
    bool IsAllowPeting()
    {
        petChance = Random.Range(0, 100);

        if(specie == 0 && petChance >= 25)
        {
            return true;
        }else if(specie == 2 && petChance >= 75)
        {
            return true;
        }else return false;
    }
    #endregion
}
