using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSC : PetSC
{
    [SerializeField] List<Sprite> petStateAnim = new List<Sprite>();
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
