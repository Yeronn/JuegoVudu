using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MonstruoController : MonoBehaviour
{
    public enum Monstruos {
        Monstruo1,
        Monstruo2,
        Monstruo3
    };
    public Monstruos monstruo;

    public string[] debilidadesMonstruo1;
    public string[] debilidadesMonstruo2;
    public string[] debilidadesMonstruo3;

    public Text winMessage;


    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        switch (monstruo)
        {
            case Monstruos.Monstruo1:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                if (debilidadesMonstruo1[0].Equals(Muneco.powers[0]) &&
                    debilidadesMonstruo1[1].Equals(Muneco.powers[1]) &&
                    debilidadesMonstruo1[2].Equals(Muneco.powers[2])
                   )
                {
                    Debug.Log("GANASATEE!!");
                    Invoke("UnActive", 2f);
                }
                else
                {
                    Debug.Log("Armaste mal al muneco, PERDISTE!!");
                }
                break;
            case Monstruos.Monstruo2:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255,0,0);
                if (debilidadesMonstruo2[0].Equals(Muneco.powers[0]) &&
                    debilidadesMonstruo2[1].Equals(Muneco.powers[1]) &&
                    debilidadesMonstruo2[2].Equals(Muneco.powers[2])
                   )
                {
                    Debug.Log("GANASATEE!!");
                    Invoke("UnActive", 2f);
                }
                else
                {
                    Debug.Log("Armaste mal al muneco, PERDISTE!!");
                }
                break;
            case Monstruos.Monstruo3:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
                if (debilidadesMonstruo3[0].Equals(Muneco.powers[0]) &&
                    debilidadesMonstruo3[1].Equals(Muneco.powers[1]) &&
                    debilidadesMonstruo3[2].Equals(Muneco.powers[2])
                   )
                {
                    Debug.Log("GANASATEE!!");
                    Invoke("UnActive", 2f);
                }
                else
                {
                    Debug.Log("Armaste mal al muneco, PERDISTE!!");
                }
                break;
            default:
                break;
        }
    }

    private void UnActive()
    {
        gameObject.SetActive(false);
        //GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()));
        //Destroy(GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).gameObject,0f);
        winMessage.gameObject.SetActive(true);
        Invoke("SceneMenu", 2f);
    }

    private void SceneMenu()
    {
        SceneManager.LoadScene("Menu");

    }

}
