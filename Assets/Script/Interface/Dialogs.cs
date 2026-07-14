using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    public List<string> greatingDialogs = new List<string>();
    [HideInInspector]public string firstplayDialog01, firstplayDialog02, firstplayDialog03, firstplayDialog04, firstplayDialog05, firstplayDialog06;
    void Start()
    {
        SetFirstPlayDialog();
    }

    private void SetFirstPlayDialog()
    {
        firstplayDialog01 = "OH, HI THERE";
        firstplayDialog02 = "WELCOME TO PETOPIA PETSHOP";
        firstplayDialog03 = "WE ASSUME YOU ARE NEW OWNER AND LOOKING FOR NEW PET TO ADOPT";
        firstplayDialog04 = "WHAT SPECIE OF PET YOU PREFER?";
        firstplayDialog05 = "OH THAT AWSOME. HOW WE CALL IT?";
        firstplayDialog06 = "GREAT. LET'S PREVIEW OUR BABY";

        greatingDialogs.Add(firstplayDialog01);
        greatingDialogs.Add(firstplayDialog02);
        greatingDialogs.Add(firstplayDialog03);
        greatingDialogs.Add(firstplayDialog04);
        greatingDialogs.Add(firstplayDialog05);
        greatingDialogs.Add(firstplayDialog06);
    }
}
