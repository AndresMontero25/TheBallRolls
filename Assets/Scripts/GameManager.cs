using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    int _quantityCollectable;
    int _totaCollectable;

    [Header("InputField")]
    public TMP_InputField speedInputFiel;
    public TMP_InputField JumpForceInputFiel;
    public TMP_InputField jetPackForceInputFiel;

    float _speedCurrent;
    float _JumpForceCurrent;
    float _jetPackForceCurrent;


    private void Start()
    {
        //Iniciasion de prefabs
        #region PlayerPrefs
        if (!PlayerPrefs.HasKey("Speed"))
        {
            PlayerPrefs.SetFloat("Speed", 5f);
        }
        if (!PlayerPrefs.HasKey("JumpForce"))
        {
            PlayerPrefs.SetFloat("JumpForce", 1f);
        }
        if (!PlayerPrefs.HasKey("jetPackForce"))
        {
            PlayerPrefs.SetFloat("jetPackForce", 5f);
        }
        if (!PlayerPrefs.HasKey("Collection"))
        {
            PlayerPrefs.SetInt("Collection", 0);
        }
        if (!PlayerPrefs.HasKey("BestTotal"))
        {
            PlayerPrefs.SetInt("BestTotal", 0);
        }
        #endregion

        //Reiniciar variable del coleccionable para iniciar en  Scenas
        this._quantityCollectable = 0;

        //Detectamos la cantidad coleccionamos hay en en la scena
        this._totaCollectable = GameObject.FindObjectsOfType<ObjectCollection>().Length;


        GameObject.FindObjectOfType<ControllerUI>().UpdateUI(SceneManager.GetActiveScene().name,this._quantityCollectable,this._totaCollectable);

        //Traemos a UI los valores que estan en los prefabs
        speedInputFiel.text = PlayerPrefs.GetFloat("Speed").ToString();
        JumpForceInputFiel.text = PlayerPrefs.GetFloat("JumpForce").ToString();
        jetPackForceInputFiel.text = PlayerPrefs.GetFloat("jetPackForce").ToString();
    }

    //Metodo para detectar el coleccionable y para aumentar en una variable
    public void RegisterCollection()
    {
        this._quantityCollectable++;
        GameObject.FindObjectOfType<ControllerUI>().UpdateUI(SceneManager.GetActiveScene().name, this._quantityCollectable, this._totaCollectable);

        if (this._quantityCollectable >= _totaCollectable)
        {
            GameObject.FindObjectOfType<ControllerScene>().LoadNextScene();
            PlayerPrefs.SetInt("Collection", PlayerPrefs.GetInt("Collection") +_quantityCollectable);
        }
    }


    //Metodo para actualizar las propiedades del Jugador
    public void UpdatePlayerProperties()
    {

        #region UpdateSpeed
        _speedCurrent = float.Parse(speedInputFiel.text);
        PlayerPrefs.SetFloat("Speed", _speedCurrent);
        #endregion

        #region UpdateJumpForce
        _JumpForceCurrent = float.Parse(JumpForceInputFiel.text);
        PlayerPrefs.SetFloat("JumpForce", _JumpForceCurrent);
        #endregion

        #region UpdatejetPackForce
        _jetPackForceCurrent = float.Parse(jetPackForceInputFiel.text);
        PlayerPrefs.SetFloat("jetPackForce", _jetPackForceCurrent);
        #endregion


    }


}
