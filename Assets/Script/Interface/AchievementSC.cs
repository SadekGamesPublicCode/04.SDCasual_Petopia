using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSC : MonoBehaviour
{
    [HideInInspector] MainSC menu;
    void Start()
    {
        menu = GameObject.Find("HomeMN").GetComponent<MainSC>();
    }
}
