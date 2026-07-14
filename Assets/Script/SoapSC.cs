using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapSC : MonoBehaviour
{
    int swipeCount;

    [HideInInspector] GenMNSC genCtr;
    [HideInInspector] MainSC mainCtr;
    public Vector3 mousePos;
    void Start()
    {
        swipeCount = 0;
        mousePos = Vector3.zero;
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
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
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pet")
        {
            OnSoaping();
        }
    }
    private void OnSoaping()
    {
        swipeCount++;
        if(swipeCount >= 3)
        {
            Destroy(gameObject);
        }
    }
}
