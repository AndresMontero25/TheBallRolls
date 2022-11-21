using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControllerUI : MonoBehaviour
{
    //Pintamos informacion en la UI, como cantidad de coleccionables y nivel actual
    public void UpdateUI(string nameLevel,int currentAmountCollection, int totalCurrentCollection)
    {
        GameObject.Find("Namelevel_Txt").GetComponent<TextMeshProUGUI>().text = nameLevel;
        GameObject.Find("Colecctionable_Txt").GetComponent<TextMeshProUGUI>().text = currentAmountCollection + "/" + totalCurrentCollection + "Recolectable";
    }
}
