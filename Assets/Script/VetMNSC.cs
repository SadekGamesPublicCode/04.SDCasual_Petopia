using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VetMNSC : MonoBehaviour
{
    [HideInInspector] GenMNSC genCtr;
    void Start()
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
    }
    public void OnHome()
    {
        genCtr.OnChangeScene(2);
    }
}
