using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI Best;

    int bestCurrent;

    //Pinta las variables almacenadas en los prefabs en la UI
    void Start()
    {
        Best.text = PlayerPrefs.GetInt("BestTotal").ToString();
        score.text = PlayerPrefs.GetInt("Collection").ToString();

        bestCurrent = PlayerPrefs.GetInt("Collection");

        PlayerPrefs.SetInt("BestTotal", bestCurrent);


    }


}
