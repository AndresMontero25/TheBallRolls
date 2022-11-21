using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{
    //Metodo para hacer el paso de scenas de acuerdo al index
    public void LoadSceneCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Metodo para controlar el paso de scenas
    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex +1 < SceneManager.sceneCountInBuildSettings )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            
            Debug.Log("Juego terminado");

        }


    }

    //Reseteaos e juego
    public void RestarGame()
    {
        SceneManager.LoadScene(0);
    }
}
