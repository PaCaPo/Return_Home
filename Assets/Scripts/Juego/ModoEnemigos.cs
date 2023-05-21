using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoEnemigos : MonoBehaviour
{
    public GameManager gameManager;
    private GameObject[] enemigos;
    void Update()
    {
        //añade a todos los enemigos del mapa a la lista
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        if (enemigos.Length == 0)
        {
            gameManager.FinDeNivel();
        }
    }
}
