using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float vel = 2;
    public float tiempo = 2;

    private void Start()
    {
        // se destrruye la bala en X tiempo
        Destroy(gameObject,tiempo);
    }

    private void FixedUpdate()
    {   
        // la bala se desplaza hacia la izquierda
        transform.Translate(Vector2.left*vel*Time.deltaTime);
    }
}
