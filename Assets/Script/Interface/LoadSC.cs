using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSC : MonoBehaviour
{
    [SerializeField] GenMNSC genCtr;
    [SerializeField] DataSC data;
    [SerializeField] Text loadTips;
    [SerializeField] Slider loadSlide;
    [SerializeField] Text versionTxt;
    private float loadSpd;
    private float target = 1;
    private void Awake()
    {
        versionTxt.text = Application.version;
    }
    private IEnumerator Start()
    {
        loadSpd = Random.Range(0.1f, 1f);
        loadSlide.value = 0;
        InvokeRepeating(nameof(OnShowTips),0f, 2f);
        while (loadSlide.value < target)
        {
            loadSlide.value = Mathf.MoveTowards(loadSlide.value, target, loadSpd * Time.deltaTime);
            yield return null;
        }

        if(loadSlide.value >= target)
        {
            print("data.Firstplay = " + data.isFirstPlay);
            if (data.CheckFirstPlay() == false) 
            {
                print("in firsr play false");
                genCtr.OnLoadPet();
                genCtr.OnChangeScene(2); 
            }
            else if (data.CheckFirstPlay() == true) 
            {
                print("in firsr play true");
                genCtr.OnChangeScene(1); 
            }
        }
    }
    private void OnShowTips()
    {
        int tempTipsOrder;
        tempTipsOrder = Random.Range(0, 10);
        switch (tempTipsOrder)
        {
            case 1:
                loadTips.text = "COLLECTING DATA";
                break;
            case 2:
                loadTips.text = "HAVE YOU FEED YOU PET?";
                break;
            case 3:

                loadTips.text = "TREAT YOUR PET RIGHT!!!";
                break;
            case 4:
                loadTips.text = "CARFULL WHILE WASHING YOUR MEOWW";
                break;
            case 5:
                loadTips.text = "YOUR PET MAY THIRSTY, DON'T FORGET HYDRATION";
                break;
            case 6:
                loadTips.text = "CHOOSE RIGHT FOOD FOR YOUR PET";
                break;
            case 7:
                loadTips.text = "CAT PREFER PETTING";
                break;
            case 8:
                loadTips.text = "DOGS LOVE TO WALK IN PARK";
                break;
            case 9:

                loadTips.text = "PLAY WITH YOUR PET TO MAKE THEM HAPPY";
                break;
            case 10:
                loadTips.text = "DON'T FORGET TO FEED YOUR PET";
                break;
        }
    }
}
