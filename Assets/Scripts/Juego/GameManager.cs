using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int monedas=0;
    public int enemigo=0;
    private int vidas = 3;
    private float cronometro = 0f;
    public Transform spawn;
    public PlayerControler jugador;
    public float tiempoRespawn = 2f;
    private float temporizador = 0;
    public bool GameOver = false; 
    private bool NivelFinalizado=false;
    public Text contadorVidas;
    public Text contadorMonedas;
    public Text crono;
    public Text textoFinNivel;
    public GameObject pantallaFinNivel;
    public GameObject pantallaAjustes;
    public GameObject Controles;
    public GameObject PantallaIntro;
    public int Score;


    // Start is called before the first frame update
    void Start()
    {   
        jugador.transform.position = spawn.position;
        Time.timeScale = 0;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.estaVivo == false) {
            if (temporizador < tiempoRespawn)
            {
                temporizador = temporizador + Time.deltaTime;
            }
            else {
                //Respawn player
                if (vidas > 0)
                {
                    vidas--;
                    jugador.transform.position = spawn.position;
                    jugador.estaVivo = true;
                    jugador.GetComponent<BoxCollider2D>().enabled = true;
                    jugador.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.None;
                    temporizador = 0;
                }
                else {
                    GameOver = true;
                }
            }
        }
        // Cuando GameOver o nivel finalizado son true salta la ventana de fin de nivel
        if (GameOver || NivelFinalizado) {
            pantallaFinNivel.SetActive(true);
            Controles.SetActive(false);
            Time.timeScale = 0;
            if (GameOver) {
                textoFinNivel.text = "Game Over";
            }
            if (NivelFinalizado)
            {
                textoFinNivel.text = "Nivel Finalizado";
                if (vidas != 0)
                {
                    Score = (100 + (enemigo * 10) + monedas - (int)cronometro)* vidas;
                }
                else {
                    Score = 100 + (enemigo * 10) + monedas - (int)cronometro;
                }
            }
        }
        if (GameOver) {
            vidas=0;
        }

        contadorVidas.text =  vidas+"X" ;
        contadorMonedas.text=monedas+"X" ;
        cronometro=cronometro+Time.deltaTime ;
        crono.text= cronometro.ToString("f0") ;
    }
    

    public void FinDeNivel(){NivelFinalizado = true;}

    // Metodo que se inicia al empezar todos los niveles
    private void empezar() { 
        Time.timeScale = 1;
        Controles.SetActive(true);
        PantallaIntro.SetActive(false);
        
    }


    //AJUSTES
    // Pausa el juego para abrir la ventana de ajustes
    private void ajustes()
    {
        if (Time.timeScale == 1)
        {
            pantallaAjustes.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pantallaAjustes.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void VolverMenu() { SceneManager.LoadScene("Menu"); }

    public void reiniciarNivel()
    {
        //reinicia el nivel en el que estas
        switch (SceneManager.GetActiveScene().name)
        {
            case "Nivel 1":
                SceneManager.LoadScene("Nivel 1");
                break;
            case "Nivel 2":
                SceneManager.LoadScene("Nivel 2");
                break;
            case "Nivel 3":
                SceneManager.LoadScene("Nivel 3");
                break;
            case "Nivel 4":
                SceneManager.LoadScene("Nivel 4");
                break;
            default:
                SceneManager.LoadScene("Menu");
                break;
        }
    }
}
