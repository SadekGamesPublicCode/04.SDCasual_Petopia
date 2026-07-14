using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [HideInInspector] DataSC dataCtr;
    string path;
    void Awake()
    {
        path = Application.persistentDataPath + "/data.json";
        dataCtr = GameObject.Find("GenMN").GetComponent<DataSC>();
    }
    private void Start()
    {
        dataCtr.OnLoadInventory();
    }
    #region Handle Save JSON
    public void OnSaveFoodDatas(int[] array)
    {
        InventoryData data = Load();
        data.foodDatas = array;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
    public void OnSaveDrinkDatas(int[] array)
    {
        InventoryData data = Load();
        data.drinkDatas = array;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
    public void OnSaveMedicineDatas(int[] array)
    {
        InventoryData data = Load();
        data.medicinesDatas = array;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
    public void OnReset()
    {
        InventoryData data = Load();
        int[] b = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        data.foodDatas = b;
        data.drinkDatas = b;
        data.medicinesDatas=b;
    }
    #endregion
    public InventoryData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<InventoryData>(json);
        }
        else
        {
            Debug.Log("No save file found");
            return new InventoryData();
        }
    }
}
