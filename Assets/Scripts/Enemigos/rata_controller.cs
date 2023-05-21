using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rata_controller : MonoBehaviour
{
    public float vel = 2f;
    public float distancia = 1f;
    private SpriteRenderer spriteR;

    private float posDerecha;
    private float posIzquierda;

    private bool seMueveIzquierda = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        posDerecha = gameObject.transform.position.x - distancia;
        posIzquierda = gameObject.transform.position.x + distancia;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //Muerte de la rata
        if (gameObject.transform.GetComponent<ControladorEnemigos>().estaMuerto) 
        {
            gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled=false;
            vel = 0;
        }
        if (seMueveIzquierda == true)
        {
            gameObject.transform.Translate(Vector2.right * vel * Time.deltaTime);
        }
        else
        {
            gameObject.transform.Translate(Vector2.left * vel * Time.deltaTime);
        }

        if (transform.position.x >= posIzquierda)
        {
            spriteR.flipX = false;
            seMueveIzquierda = false;
        }
        if (transform.position.x <= posDerecha)
        {
            spriteR.flipX = true;
            seMueveIzquierda = true;
        }
    }
}
