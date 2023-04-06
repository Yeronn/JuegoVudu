using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.caracteristicas[0] == "fuego")
        {
            Debug.Log("El elemento del muneco esta correcta");

            if (PlayerController.caracteristicas[1] == "paja")
            {
                Debug.Log("La armadura del muneco esta correcta");

                if (PlayerController.caracteristicas[1] == "cortante")
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("El ataque del muneco esta incorrecta");
                }
            }
            else
            {
                
            }

        }
        

    }
}
