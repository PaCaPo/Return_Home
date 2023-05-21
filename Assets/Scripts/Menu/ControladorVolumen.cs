using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVolumen : MonoBehaviour
{
    public Slider slider;
    public float volSlider;
    // Start is called before the first frame update
    void Start()
    {
        //Inicia el juego por primera vez con la mitad del volumen
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume=slider.value;
    }

    public void cambioSlider(float vol) { 
        volSlider=vol;
        //Guarda la preferencia de volumen
        PlayerPrefs.SetFloat("volumenAudio", volSlider);
        AudioListener.volume = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
