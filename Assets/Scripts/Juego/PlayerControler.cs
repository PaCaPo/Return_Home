using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float velocidadActual= 0f;
    public float velocidad = 3f;
    public float salto = 3f;
    private  bool haSaltado = false;
    private SpriteRenderer spriteR;
    private Rigidbody2D rigidbody;
    public bool estaVivo = true;
    private bool derecha = false;
    private bool izquierda = false;
    public GameManager manager;
    public Animator animator;

    

    //AUDIO
    public AudioSource audioSource;
    public AudioClip sonidoCherry;
    public AudioClip sonidoSalto;
    public AudioClip sonidoMuerto;
    public AudioClip sonidoEnemigoMuerto;
    

    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        //Comprueba si esta vivo para ver si puede saltar
        if (estaVivo == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Salto();
            }
        }
        else
        {
            velocidadActual = 0;
        }

        //Animaciones
        animator.SetBool("En_El_Suelo", !haSaltado);
        animator.SetBool("Esta_Vivo", estaVivo);
        if (velocidadActual == 0)
        {
            animator.SetBool("Movimiento", false);
        }
        else {
            animator.SetBool("Movimiento",true);
        }
    }

    private void FixedUpdate()
    {
        // si esta vivo se puede mover
        if (estaVivo == true)
        {
            Movimiento(); 
        }
        // si se cae poer el precipicio muere
        if (gameObject.transform.position.y < -1.712)
            if(estaVivo)
                muerto();
        
    }
    //Eventos para movimiento con botones
    public void derechaDown() { derecha = true; }
    public void derechaUp() { derecha = false; }
    public void izquierdaDown() { izquierda = true; }
    public void izquierdaUp() { izquierda = false; }

    private void Movimiento()
    {
        velocidadActual = 0;
        if(derecha|| Input.GetKey(KeyCode.D))
        {
            if (spriteR.flipX==true) {
                spriteR.flipX = false;
            }
            velocidadActual = velocidad;
        }
        if (izquierda|| Input.GetKey(KeyCode.A))
        {
            if (spriteR.flipX == false)
            {
                spriteR.flipX = true;
            }
            velocidadActual = velocidad*-1;
        }

        transform.Translate(velocidadActual*Time.deltaTime,0f,0f);
    }

    
    private void Salto()
    {
        if (haSaltado==false)
        {
            rigidbody.AddForce(new Vector2(0f, salto), ForceMode2D.Impulse);
            haSaltado = true;
            animator.SetTrigger("Salto");
            audioSource.PlayOneShot(sonidoSalto, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cherry") {
            manager.monedas++;
            audioSource.PlayOneShot(sonidoCherry, 1f);
            Destroy(collision.gameObject);
        } 
        if (collision.gameObject.tag == "CherryTrampa") {
            muerto();
            Destroy(collision.gameObject);
        } 
        if (collision.gameObject.tag == "CheckPoint") {
            manager.spawn = collision.gameObject.transform;
        } 
        if (collision.gameObject.tag == "FinNivel") {
            manager.FinDeNivel();
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Muerte del enemigo
        if (collision.gameObject.tag == "ZonaDebil")
        {
            audioSource.PlayOneShot(sonidoEnemigoMuerto, 1f);
            manager.enemigo++;
            gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, salto/(float)1.7), ForceMode2D.Impulse);
            collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            collision.transform.parent.GetComponent<ControladorEnemigos>().estaMuerto=true;
            collision.transform.parent.GetComponent<Animator>().SetBool("Muerte",true);
            Destroy(collision.transform.parent.gameObject,0.5f);
        }
        if (collision.gameObject.tag == "Pinchos" || collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "bala")
        {
            if (estaVivo) 
            {
                muerto(); 
            }
        }
        if (collision.gameObject.tag == "Suelo")
        {
            haSaltado = false; 
        }

    }

    public void muerto() {
        estaVivo = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionY;
        animator.SetTrigger("Muerto");
        audioSource.PlayOneShot(sonidoMuerto, 1f);
    }

}
