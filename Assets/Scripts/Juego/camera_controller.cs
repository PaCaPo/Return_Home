using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public Transform target;
    public float vel = 0.5f;
    public Vector3 posi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 siguientePosi=target.position+posi;
        Vector3 movimientoSuave=Vector3.Lerp(transform.position, siguientePosi, vel);
        movimientoSuave.y=0;
        movimientoSuave.z=-50;
        transform.position=movimientoSuave;
        
    }
}
