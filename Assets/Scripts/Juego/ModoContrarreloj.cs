using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoContrarreloj : MonoBehaviour
{

    public GameManager gameManager;
    public float temporizador = 300f;
    
    
    void Update()
    {
        if (temporizador > 0) 
        { 
            temporizador=temporizador-Time.deltaTime;
        }
        else
        {
            if (gameManager.GameOver == false) 
            {
                gameManager.GameOver = true;
                gameManager.jugador.muerto();
                
            }
        }
    }
}
