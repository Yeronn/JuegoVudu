using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static string[] caracteristicas = new string[3];

    private void Start()
    {
        caracteristicas[0] = "fuego"; 
        caracteristicas[1] = "piedra"; 
        caracteristicas[2] = "punzante";
    }
}
