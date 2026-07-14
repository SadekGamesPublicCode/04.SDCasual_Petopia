using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerHandleSC : MonoBehaviour
{
    [SerializeField] List<GameObject> waterSpill;
    [HideInInspector] GenMNSC genCtr;
    [HideInInspector] MainSC mainCtr;
    public Vector3 mousePos;
    int spillCount, swipeCount;
    void Start()
    {
        mousePos = Vector3.zero;
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        mainCtr = GameObject.Find("HomeMN").GetComponent<MainSC>();
        spillCount = 0;
        swipeCount = 0;
        for(int i = 0; i<waterSpill.Count; i++)
        {
            waterSpill[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (genCtr.deviceType == 1)
        {
            //Touch
            if (Input.touchCount > 0)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get current position of mouse on screen
                mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
                Vector3 temp = Vector3.Lerp(transform.position, mousePos, 100 * Time.deltaTime);
                transform.position = temp;
            }
        }
        else if (genCtr.deviceType == 2)
        {
            //Key board
            if (Input.GetMouseButton(0) == true)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
                transform.position = mousePos;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pet")
        {
            SpillWater();
            swipeCount++;
            if(swipeCount >= 3)
            {
                Destroy(gameObject);
            }
        }
    }
    private void SpillWater()
    {
        VisibleWaterSpill();
        Invoke(nameof(InvisibleWaterSpill), 3);
        mainCtr.OnPlusCoin(1);
    }
    private void VisibleWaterSpill()
    {
        for(int i = 0; i < waterSpill.Count; i++)
        {
            waterSpill[i].gameObject.SetActive(true);
            spillCount++;
            if (i >= waterSpill.Count) spillCount = 0;
        }
    }
    private void InvisibleWaterSpill()
    {
        for (int i = 0; i < waterSpill.Count; i++)
        {
            waterSpill[i].gameObject.SetActive(false);
        }
    }
}
