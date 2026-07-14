using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPlaySC : MonoBehaviour
{
    [HideInInspector] GenMNSC genCtr;
    [SerializeField] Text greatingLines, petNameToShow, petSpecieToShow, petOld, petStatusTxt;
    [SerializeField] InputField petNameInput;
    [SerializeField] Dialogs dialogStrings;
    [SerializeField] GameObject selectSpeciePanel, selectNamePanel, petCustomPanel, dialogPanel;
    [SerializeField] Image petAvatar, genderImg;
    [SerializeField] Sprite genderMale, genderFemale;
    [SerializeField] List<GameObject> petToShow = new List<GameObject>();
    [HideInInspector] GameObject petShadow;

    [SerializeField] List<Sprite> petDefaultAvt = new List<Sprite>();

    public Transform canvasParent;
    int greatingDialogOrder, petOldAmounts;
    int petInitStage;
    bool isAbility;

    //Pet static
    [HideInInspector] public int petColorOrder, petMisteryOrder, petGenderOrder;
    int specieOrder;
    string petName;
    void Start()
    {
        specieOrder = 0;
        petColorOrder = 0;
        petMisteryOrder = 02;
        petGenderOrder = 0;

        selectSpeciePanel.gameObject.SetActive(false);
        greatingLines.gameObject.SetActive(false);
        greatingDialogOrder = 0;
        petInitStage = 0;
        genCtr = GameObject.Find("GenMN").GetComponent<GenMNSC>();
        dialogStrings = GameObject.Find("FirstPlayMN").GetComponent<Dialogs>();
        petShadow = null;
        Invoke(nameof(ShowText), 5f);
        InvokeRepeating(nameof(GreatingDialog), 5f, 5f);
    }
    private void GreatingDialog()
    {
        UpdateDialog(greatingDialogOrder);
        greatingDialogOrder++;
    }
    private void UpdateDialog(int order)
    {
        greatingLines.text = dialogStrings.greatingDialogs[order];
        if (order == 3)
        {
            CancelInvoke();
            Invoke(nameof(ShowSpeciePanel), 1f);
            Invoke(nameof(HideDialogPanel), 1f);
        }
    }
    private void ShowText() => greatingLines.gameObject.SetActive(true);
    private void ShowDialogPanel() => dialogPanel.gameObject.SetActive(true);
    private void HideDialogPanel() => dialogPanel.gameObject.SetActive(false);
    private void ShowSpeciePanel() => selectSpeciePanel.gameObject.SetActive(true);
    private void HideSpeciePanel() => selectSpeciePanel.gameObject.SetActive(false);
    private void ShowPetNamePanel() => selectNamePanel.gameObject.SetActive(true);
    private void HidePetNamePanel() => selectNamePanel.gameObject.SetActive(false);
    private void ShowPetPreview()
    {
        petCustomPanel.gameObject.SetActive(true);
        OveridePetPreview();
    }
    private void HidePetPreview() => petCustomPanel.gameObject.SetActive(false);
    private void OveridePetPreview()
    {
        petInitStage = 3;
        petNameToShow.text = petName;
        petAvatar.sprite = petDefaultAvt[specieOrder- 1];
        petOldAmounts = Random.Range(0, 10);
        petGenderOrder = Random.Range(0, 10);
        switch (specieOrder)
        {
            case 1:
                petSpecieToShow.text = "DOG";              
                break;
            case 2:
                petSpecieToShow.text = "CAT";
                break;
            case 3:
                petSpecieToShow.text = "RABBIT";
                break;
            case 4:
                petSpecieToShow.text = "FISH";
                break;
            case 5:
                //Chicken
                petSpecieToShow.text = "CHICKEN";
                break;
            case 6:
                //duck
                petSpecieToShow.text = "DUCK";
                break;
            case 7:
                //pig
                petSpecieToShow.text = "PIG";
                break;
            case 8:
                //cow
                petSpecieToShow.text = "COW";
                break;
                case 9:
                //alien
                petSpecieToShow.text = "ALIEN";
                break;
        }
        
        if(petGenderOrder < 5) { genderImg.GetComponent<Image>().sprite = genderMale; }
        else if(petGenderOrder >= 5) { genderImg.GetComponent<Image>().sprite = genderFemale; }

        petOld.text = petOldAmounts.ToString();
        petStatusTxt.text = "OK";
    }

    public void OnSelectDog()
    {
        specieOrder = 1;
        petInitStage = 1;
        UpdateDialog(4);
        HideSpeciePanel();
        ShowDialogPanel();
        petShadow = Instantiate(petToShow[specieOrder-1], new Vector3(-1.5f, 0, 0), Quaternion.identity);
        Invoke(nameof(HideDialogPanel), 5f);
        Invoke(nameof(ShowPetNamePanel), 5f);

        //UPdate pet to main control script
    }
    public void OnSelectCat()
    {
        specieOrder = 2;
        petInitStage = 1;
        UpdateDialog(4);
        ShowDialogPanel();
        HideSpeciePanel();
        Instantiate(petToShow[specieOrder - 1], Vector3.zero, Quaternion.identity);
        Invoke(nameof(HideDialogPanel), 5f);
        Invoke(nameof(ShowPetNamePanel), 5f);
        //UPdate pet to main control script
    }
    public void OnSelectFish()
    {
        specieOrder = 3;
        petInitStage = 1;
        UpdateDialog(4);
        ShowDialogPanel();
        HideSpeciePanel();
        Instantiate(petToShow[specieOrder - 1], Vector3.zero, Quaternion.identity);
        Invoke(nameof(HideDialogPanel), 5f);
        Invoke(nameof(ShowPetNamePanel), 5f);
        //UPdate pet to main control script
    }
    public void OnSelectRabbit()
    {
        specieOrder = 4;
        petInitStage = 1;
        UpdateDialog(4);
        HideSpeciePanel();
        ShowDialogPanel();
        Instantiate(petToShow[specieOrder - 1], Vector3.zero, Quaternion.identity);
        Invoke(nameof(HideDialogPanel), 5f);
        Invoke(nameof(ShowPetNamePanel), 5f);
        //UPdate pet to main control script
    }
    public void OnDonePetName()
    {
        petName = petNameInput.text;
        HidePetNamePanel();
        petInitStage = 2;
        UpdateDialog(5);
        Invoke(nameof(ShowDialogPanel), 1f);
        Invoke(nameof(HideDialogPanel), 6f);
        Invoke(nameof(ShowPetPreview), 6f);
    }
    public void DonePetPreview()
    {
        //Update all Pet data
        if(petMisteryOrder == 0) { isAbility = false; }
        else if(petMisteryOrder == 1) { isAbility = true; }

        genCtr.OnGeneratePet(petName, specieOrder, petOldAmounts, petGenderOrder, isAbility);
        genCtr.OnChangeScene(2);
        genCtr.OnLoadPet();

    }
    public void OnResetPet()
    {
        petName = "";
        petAvatar.sprite = null;
        specieOrder = 0;
        petGenderOrder = 0;
        petMisteryOrder = 0;
        petColorOrder = 0;
        petShadow = null;
        Destroy(petAvatar);
        HidePetPreview();
        ShowSpeciePanel();
    }
    public void OnMisteryYes() => petMisteryOrder = 1;
    public void OnMisteryNo() => petMisteryOrder = 1;
}
