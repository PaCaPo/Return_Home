using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aguila_controller : MonoBehaviour
{
    public float vel = 1f;
    private SpriteRenderer spriteR;

    private Transform target;
    private Vector2 posIni;
    private bool dentroTrigger = false;
    private PlayerControler jugador;


    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        posIni=transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // Muerte del aguila
        if (gameObject.transform.GetComponent<ControladorEnemigos>().estaMuerto)
        {
            gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            vel = 0;
        }
        //Cuando muere player vuelve a la posicion inicial
        if (jugador.estaVivo==false) 
        {
            transform.position = posIni;
        }
        if (transform.position.x >= target.transform.position.x)
        {
            spriteR.flipX = false;
        }
        if (transform.position.x <= target.transform.position.x)
        {
            spriteR.flipX = true;
        }
        //Si player esta dentro le persigue
        if (dentroTrigger)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, vel * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dentroTrigger = true;
        }       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            dentroTrigger = false;
    }
}
