using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public void setTag(string option)
    {
        Debug.Log("Poner  Tag");
        transform.gameObject.tag = option;
        StartCoroutine("SetPosition",option);
    }

    IEnumerator SetPosition(string option)
    {
        Debug.Log("Empezando corutina");
        yield return new WaitForSeconds(1);

        switch (option)
        {
            case "SelectedElement":
                transform.localPosition = new Vector3(0, 2.5f, 0);
                break;

            case "SelectedArmor":
                transform.localPosition = new Vector3(-2.5f, 0, 0);
                break;

            case "SelectedTypeAttack":
                transform.localPosition = new Vector3(2.5f, 0, 0);
                break;

            default:
                break;
        }
        Debug.Log("Terminando corutina");
    }
}
