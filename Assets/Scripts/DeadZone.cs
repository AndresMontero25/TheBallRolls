using UnityEngine;

public class DeadZone : MonoBehaviour
{

    void Update()
    {
        
    }

    //Detectamos cuando el player cae de la plataforma
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindObjectOfType<ControllerScene>().LoadSceneCurrent();
    }
}
