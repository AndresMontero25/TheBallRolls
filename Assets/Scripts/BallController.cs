using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [Header("Values Player")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [Space]

    [Header("Values JetPack")]
    [SerializeField] float jetPackForce = 2;
    [SerializeField] float jetPackFuel = 10;
    bool isUsing;
    [SerializeField] Image imageUI;
    [SerializeField] private GameObject ParticleLeft, ParticleRight;
    [Space]

    [Header("Values BlockUp")]
    [SerializeField] bool grounded = false;
    [SerializeField] float groundedCheckDistance;
    [SerializeField] float bufferCheckDistance = 0.1f;


    void Update()
    {
        speed = PlayerPrefs.GetFloat("Speed");
        jumpForce = PlayerPrefs.GetFloat("JumpForce");
        jetPackForce = PlayerPrefs.GetFloat("jetPackForce");

      
        groundedCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + bufferCheckDistance;

        //Asignar variables de horientación 
        float ejeH = Input.GetAxis("Horizontal");
        float ejeV = Input.GetAxis("Vertical");

        //Entrar al componente Rigi para añadirle fuerza a la esfera
        this.GetComponent<Rigidbody>().AddForce(new Vector3(ejeH * this.speed, 0f, ejeV * this.speed));

        //Condición para que la techa de espacio genere la fuerza para que la esfera salte
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        //Instanciar el Raycast para detectar cuando toque el suelo y se pueda activar nuevamente el salto
        RaycastHit hit;
        if (Physics.Raycast(transform.position, - transform.up, out hit, groundedCheckDistance))
        {
            grounded = true;
            this.GetComponent<Rigidbody>().useGravity = true;
            
        }
        else
        {
            grounded = false;
        }


        //Sistema jetpack
        #region MyRegion
        if (jetPackFuel >= 10)
        {
            jetPackFuel = 10;
        }


        imageUI.fillAmount = jetPackFuel / 10;

        if (Input.GetButton("Fire1"))
        {
            if (jetPackFuel > 0)
            {
                StartJetPack();
            }
        }

        else
        {
            StopJetPack();
        }
        if (jetPackFuel <= 0 && isUsing == false)
        {
            StopJetPack();
        }
        #endregion

    }

    //Metodos para imprimir fuerza al jetpack, tambien activar las particulas y para detectar cuando el personaje esa en el aire y controlar el conbustible.
    #region Metodos JetPack
    void StartJetPack()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * jetPackForce);
        jetPackFuel -= Time.deltaTime;
        isUsing = true;
        ParticleLeft.GetComponent<ParticleSystem>().Play();
        ParticleRight.GetComponent<ParticleSystem>().Play();
    }
    void StopJetPack()
    {
        jetPackFuel += Time.deltaTime;
        isUsing = false;
        ParticleLeft.GetComponent<ParticleSystem>().Stop();
        ParticleRight.GetComponent<ParticleSystem>().Stop();
    }
    #endregion




}
