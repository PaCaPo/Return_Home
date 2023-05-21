using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject SelecNiveles,MenuPrin,Ajustes,Score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void volver()
    {
        MenuPrin.SetActive(true);
        SelecNiveles.SetActive(false);
    }
    public void volverAjustes()
    {
        MenuPrin.SetActive(true);
        Ajustes.SetActive(false);
    }
    public void volverScore()
    {
        SelecNiveles.SetActive(true);
        Score.SetActive(false);
    }


    public void menulvl()
    {
        MenuPrin.SetActive(false);
        SelecNiveles.SetActive(true);
    }
    public void menuAjustes()
    {
        MenuPrin.SetActive(false);
        Ajustes.SetActive(true);
    }
    public void menuScore()
    {
        SelecNiveles.SetActive(false);
        Score.SetActive(true);
    }

    public void Turorial() {
        SceneManager.LoadScene("Tutorial");
    }
    public void Nivel1() {
        SceneManager.LoadScene("Nivel 1");
    }
    public void Nivel2() {
        SceneManager.LoadScene("Nivel 2");
    }
    public void Nivel3() {
        SceneManager.LoadScene("Nivel 3");
    }
    public void Nivel4() {
        SceneManager.LoadScene("Nivel 4");
    }
    public void salir() {
        Application.Quit();
    }


}
