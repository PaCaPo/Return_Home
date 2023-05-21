using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_controller : MonoBehaviour
{
    public GameManager gameManager;
    public Text SC1;
    public Text SC2;
    public Text SC3;
    public Text SC4;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu") {
            ActualizarScore();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuardarScore() {
        //Almacena el score en funcion de la escena en la que estes
        switch (SceneManager.GetActiveScene().name) 
        {
            case "Nivel 1":
                if (gameManager.Score > PlayerPrefs.GetInt("SC_Nivel_1"))
                {
                    PlayerPrefs.SetInt("SC_Nivel_1", gameManager.Score);
                }
                break;
            case "Nivel 2":
                if (gameManager.Score > PlayerPrefs.GetInt("SC_Nivel_2"))
                {
                    PlayerPrefs.SetInt("SC_Nivel_2", gameManager.Score);
                }
                break;
            case "Nivel 3":
                if (gameManager.Score > PlayerPrefs.GetInt("SC_Nivel_3"))
                {
                    PlayerPrefs.SetInt("SC_Nivel_3", gameManager.Score);
                }
                break;
            case "Nivel 4":
                if (gameManager.Score > PlayerPrefs.GetInt("SC_Nivel_4"))
                {
                    PlayerPrefs.SetInt("SC_Nivel_4", gameManager.Score);
                }
                break;
            default:
                break;
        }
    }
    // actualiza el Score de la ventana de Score
    public void ActualizarScore() {
        SC1.text = PlayerPrefs.GetInt("SC_Nivel_1").ToString();
        SC2.text = PlayerPrefs.GetInt("SC_Nivel_2").ToString();
        SC3.text = PlayerPrefs.GetInt("SC_Nivel_3").ToString();
        SC4.text = PlayerPrefs.GetInt("SC_Nivel_4").ToString();
    }
}
