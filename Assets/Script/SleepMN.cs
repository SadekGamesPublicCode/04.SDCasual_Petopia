using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepMN : MonoBehaviour
{
    [SerializeField] MainSC mainCtr;
    [SerializeField] Text progressTxt;
    int progressCount;
    private void Start()
    {
        progressCount = 0;
    }
    private void OnEnable()
    {
        if(mainCtr.gEnergy < 100)
        {
            mainCtr.OnUpdateSleep();
        }
        InvokeRepeating(nameof(OnHandleSleepAnim), 0f, 1f);
        Invoke(nameof(OnHandleSleepComplate), 5f);
    }
    private void OnHandleSleepComplate()
    {
        gameObject.SetActive(false);
        CancelInvoke(nameof(OnHandleSleepAnim));
    }
    private void OnHandleSleepAnim()
    {
        progressCount++;
        if (progressCount == 1)
        {
            progressTxt.text = "SLEEPING.";
        }
        else if (progressCount == 2)
        {
            progressTxt.text = "SLEEPING..";
        }
        else if (progressCount == 3)
        {
            progressCount = 0;
            progressTxt.text = "SLEEPING...";
        }
    }
}
