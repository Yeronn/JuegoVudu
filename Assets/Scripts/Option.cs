using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Option : MonoBehaviour
{
    private Vector3 initialPosition;

    private string mainTag;
    private bool checkPower;

    private void Start()
    {
        initialPosition = transform.position;
        mainTag = transform.gameObject.tag;
        checkPower = true;
    }

    public void SetTag(Tags tag)
    {
        Debug.Log($"Setting Unselected tag ");
        transform.gameObject.tag = Tags.Unselected.ToString();
        StartCoroutine("SetPosition",tag);
    }

    private IEnumerator SetPosition(Tags option)
    {
        Debug.Log("Empezando corutina setposition");
        yield return new WaitForSeconds(1.5f);
        Debug.Log($"Setting {option} tag ");
        transform.gameObject.tag = option.ToString();

        switch (option)
        {
            case Tags.SelectedElement:
                transform.localPosition = new Vector3(0, 2.5f, 0);
                break;

            case Tags.SelectedArmor:
                transform.localPosition = new Vector3(-2.5f, 0, 0);
                break;

            case Tags.SelectedTypeAttack:
                transform.localPosition = new Vector3(2.5f, 0, 0);
                break;

            default:
                break;
        }
        Debug.Log("Terminando corutina");
    }

    public void ReturnInitialPosition()
    {
        //Debug.Log(transform.parent.tag);
        transform.parent = null;

        if (transform.CompareTag(mainTag))
        {
            checkPower = false;
            Debug.Log("La main tag es " + mainTag);
        }

        transform.gameObject.tag = Tags.Unselected.ToString();
        Invoke("SetInitialPosition",0.5f);
    }

    private void SetInitialPosition()
    {
        Debug.Log("Return Initial Position" + initialPosition);
        transform.position = initialPosition;

        transform.SetParent(GameObject.Find(Tags.Options.ToString()).transform);
        Debug.Log(transform.parent.name);
        transform.gameObject.tag = mainTag;

        Debug.Log("La main tag es " + mainTag + " y checkpower es " + checkPower + " y "+ Tags.Element.ToString());

        if (checkPower)
        {
            Debug.Log("EEntro a cheeckpower");
            if (mainTag.Equals(Tags.Element.ToString()))
            {
                GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).GetComponent<Muneco>().hasElement = false;
                Debug.Log("hasElement: " + GameObject.Find(Tags.Muneco.ToString()).GetComponent<Muneco>().hasElement);
            }
            else if (mainTag.Equals(Tags.Armor.ToString()))
            {
                GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).GetComponent<Muneco>().hasArmor = false;
                Debug.Log("hasArmor: " + GameObject.Find(Tags.Muneco.ToString()).GetComponent<Muneco>().hasArmor);
            }
            else if (mainTag.Equals(Tags.TypeAttack.ToString()))
            {
                GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).GetComponent<Muneco>().hasTypeAttack = false;
                Debug.Log("hasTypeAttack: " + GameObject.Find(Tags.Muneco.ToString()).GetComponent<Muneco>().hasTypeAttack);
            }
            Debug.Log("salio dee cheeckpower");
        }
        else
        {
            checkPower = true;
            Debug.Log("checkPower es " + checkPower);
        }
    }
}
