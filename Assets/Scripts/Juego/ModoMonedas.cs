using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoMonedas : MonoBehaviour
{
    public GameManager gameManager;
    private GameObject[] monedas;
    void Update()
    {
        //añade a la lista todas las cherrys del mapa
        monedas = GameObject.FindGameObjectsWithTag("Cherry");
        if (monedas.Length == 0) 
        {
            gameManager.FinDeNivel();
        }
    }
}
