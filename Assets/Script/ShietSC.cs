using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShietSC : MonoBehaviour
{
    [SerializeField] MainSC gameCtr;
    string name;
    private int selfScore;
    void Start()
    {
        gameCtr = GameObject.Find("HomeMN").GetComponent<MainSC>();
        name = gameObject.name;
        if(name == "OBJ_ShitNormal(Clone)" || name == "OBJ_ShitNormal")
        {
            selfScore = 2;
        }
        else if (name == "OBJ_ShitUnhealthy(Clone)" || name == "OBJ_ShitUnhealthy")
        {
            selfScore = 1;
        }
        else if (name == "OBJ_ShitSick(Clone)" || name == "OBJ_ShitSick")
        {
            selfScore = 0;
        }
        else if (name == "OBJ_ShitRainbow(Clone)" || name == "OBJ_ShitRainbow")
        {
            selfScore = 10;
        }
    }
    private void OnMouseDown()
    {
        gameCtr.OnPlusCoin(selfScore);
        gameCtr.UpdateShitStayOnScreen(-1);
        Destroy(gameObject);
    }
}
