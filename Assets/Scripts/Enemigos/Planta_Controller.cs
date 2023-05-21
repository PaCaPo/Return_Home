using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planta_Controller : MonoBehaviour
{
    private float espera;
    public float tiempo_espera_ataque;
    public Animator animator;
    public GameObject bala;
    public Transform posDisparo;
    // Start is called before the first frame update
    void Start()
    {
        espera = tiempo_espera_ataque;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Muerte de la Planta
        if (gameObject.transform.GetComponent<ControladorEnemigos>().estaMuerto)
        {
            gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        }
        // Cadencia de la planta, cada segundo se resta tiempo a espera y cuando llega a 0 se dispara la bala
        if (espera <= 0)
        {
            espera = tiempo_espera_ataque;
            animator.Play("ataquePlanta");
            Invoke("DispararBala", 0.5f);
        }
        else {
            espera -= Time.deltaTime;
        }
    }

    public void DispararBala() {
        GameObject nuevaBala;
        nuevaBala= Instantiate(bala,posDisparo.position,posDisparo.rotation);
    }
}
