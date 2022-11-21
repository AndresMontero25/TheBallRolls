using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollection : MonoBehaviour
{
    //Para rotar el colecionable 
    private void Update()
    {
        this.transform.Rotate(20f *Time.deltaTime, 20f * Time.deltaTime, 20f * Time.deltaTime);
    }

    //Detecta la colision 
    private void OnTriggerEnter(Collider other)
    {

        this.Collection();

    }

    //Metodo para llamar un metodo del Game Manager que permite sumar en variable y lo destruye
    void Collection()
    {
        GameObject.FindObjectOfType<GameManager>().RegisterCollection();
        Destroy(this.gameObject);
    }
}
