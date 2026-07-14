using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMN : Singleton<SceneMN>
{
    [HideInInspector] GenMNSC genCtr;
    void Start()
    {
        DontDestroyOnLoad(this);
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
    }

    // Update is called once per frame
    void Update()
    { }

    public void OnLoadScene(int sceneOder)
    {
        switch (sceneOder)
        {
            case 0:
                SceneManager.LoadScene("Load");
                break;
            case 1:
                SceneManager.LoadScene("FirstScene");
                break;
            case 2:
                print(" in load Main");
                SceneManager.LoadScene("MainScene");
                break;
            case 3:
                SceneManager.LoadScene("PetShop");
                break;
            case 4:
                SceneManager.LoadScene("PetVet");
                break;
            case 5:
                SceneManager.LoadScene("Outside");
                break;
        }
    }
}
