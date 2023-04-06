using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Muneco : MonoBehaviour
{
    bool hasElement;
    bool hasArmor ;
    bool hasTypeAttack;
    string[] options = {"Element","Armor","TypeAttack"};
    string[] Selectedoptions;

    private void Start()
    {
        hasElement = false;
        hasArmor = false;
        hasTypeAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(options[0]) && hasElement == false)
        {
            Debug.Log("Element");
            collision.transform.SetParent(transform,false);
            collision.GetComponent<Option>().setTag("Selected" + options[0]);
            hasElement = true;
        }

        if (collision.CompareTag(options[1]) && hasArmor == false)
        {
            Debug.Log("Armor");
            collision.transform.SetParent(transform, false);
            collision.GetComponent<Option>().setTag("Selected" + options[1]);
            hasArmor = true;
        }

        if (collision.CompareTag(options[2]) && hasTypeAttack == false)
        {
            Debug.Log("TypeAttack");
            collision.transform.SetParent(transform, false);
            collision.GetComponent<Option>().setTag("Selected" + options[2]);
            hasTypeAttack = true;
        }

    }

}
