using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MonstruoController : MonoBehaviour
{
    public enum Monstruos {
        Monstruo1,
        Monstruo2
    };
    public Monstruos monstruo;

    public string[] debilidadesMonstruo1;
    public string[] debilidadesMonstruo2;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        switch (monstruo)
        {
            case Monstruos.Monstruo1:
                if (debilidadesMonstruo1[0].Equals(Muneco.powers[0]) &&
                    debilidadesMonstruo1[1].Equals(Muneco.powers[1]) &&
                    debilidadesMonstruo1[2].Equals(Muneco.powers[2])
                   )
                {
                    Debug.Log("GANASATEE!!");
                    Destroy(gameObject,1f);
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
                    Destroy(gameObject,1f);
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

}
