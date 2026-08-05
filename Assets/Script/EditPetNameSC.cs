using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditPetNameSC : MonoBehaviour
{
    [SerializeField] InputField inputPetName;
    [SerializeField] DataSC dataSC;

    public void OnOverridePetName()
    {
        dataSC.UpdatePetName(inputPetName.text);
    }
}
