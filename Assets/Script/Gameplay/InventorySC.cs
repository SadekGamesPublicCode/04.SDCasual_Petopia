using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySC : MonoBehaviour
{
    public int showOrder;
    public float step = 0.2f; // how much to move per click
    [SerializeField] ScrollRect inventoryScroll;
    [SerializeField] CareController careCtr;
    [SerializeField] List<Image> foodItems = new List<Image>();
    [SerializeField] List<Image> drinkItems = new List<Image>();
    [SerializeField] List<Image> medItems = new List<Image>();
    void Start()
    {
        showOrder = 0;
        careCtr = GameObject.Find("PNL_Invetories").GetComponent<CareController>();
    }
    public void OnNext()
    {
        inventoryScroll.horizontalNormalizedPosition = Mathf.Clamp01(inventoryScroll.horizontalNormalizedPosition + step);
    }
    public void OnPrevious()
    {
        inventoryScroll.horizontalNormalizedPosition = Mathf.Clamp01(inventoryScroll.horizontalNormalizedPosition - step);
    }
    public void OnSetInevntoryPanel()
    {
        if(showOrder == 1)
        {
            inventoryScroll = GameObject.Find("SCROLL_MiddleFood").GetComponent<ScrollRect>();
        }
        else if(showOrder == 2)
        {
            inventoryScroll = GameObject.Find("SCROLL_MiddleDrink").GetComponent<ScrollRect>();
        }
        else if(showOrder == 3)
        {
            inventoryScroll = GameObject.Find("SCROLL_MiddleMed").GetComponent<ScrollRect>();
        }else if(showOrder == 4)
        {
            inventoryScroll = GameObject.Find("SCROLL_MiddleBath").GetComponent<ScrollRect>();
        }
    }
}
