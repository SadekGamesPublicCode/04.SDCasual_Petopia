using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPoolSC : MonoBehaviour
{
    [SerializeField] List<Sprite> catSpirtes = new List<Sprite>();
    [SerializeField] List<Sprite> dogSprites = new List<Sprite>();
    [SerializeField] List<Sprite> rabbitSprites = new List<Sprite>();
    [SerializeField] List<Sprite> fishSprites = new List<Sprite>();

    [SerializeField] List<Sprite> hamsterSpirtes = new List<Sprite>();
    [SerializeField] List<Sprite> pigSprites = new List<Sprite>();
    [SerializeField] List<Sprite> birdSpirtes = new List<Sprite>();
    [SerializeField] List<Sprite> bugsSpirtes = new List<Sprite>();
    [SerializeField] List<Sprite> catlesSpirtes = new List<Sprite>();

    [HideInInspector] GenMNSC genCtr;
    int petSpecie, petOld, petColor;

    List<Sprite> spriteDog = new List<Sprite>();
    void Start()
    {
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        OnCollectPetData();
    }
    void Update() { }

    private void OnCollectPetData()
    {
        petSpecie = genCtr.petSpecie;
        petOld = genCtr.petOld;

    }
}
