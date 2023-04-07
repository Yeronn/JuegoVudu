using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muneco : MonoBehaviour
{
    public bool hasElement;
    public bool hasArmor ;
    public bool hasTypeAttack;

    [SerializeField] public  string[] powers;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        hasElement = false;
        hasArmor = false;
        hasTypeAttack = false;

        powers = new string[3];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("padre " + collision.gameObject.transform.parent.tag.Equals(Tags.Options.ToString()));
        if (collision.gameObject.transform.parent.tag.Equals(Tags.Options.ToString()))
        {
            if ( (collision.transform.tag.Equals(Tags.Element.ToString()) && hasElement) ||
                 (collision.transform.tag.Equals(Tags.Armor.ToString()) && hasArmor) ||
                 (collision.transform.tag.Equals(Tags.TypeAttack.ToString()) && hasTypeAttack)
               )
            {
                Debug.Log("Entro siiiii xD");
                collision.GetComponent<Option>().ReturnInitialPosition();
            }
            else
            {
                collision.transform.SetParent(transform, false);
            }
        }

        if (collision.CompareTag(Tags.Element.ToString()) && hasElement == false)
        {
            collision.GetComponent<Option>().SetTag(Tags.SelectedElement);
            hasElement = true;
            powers[0] = collision.transform.name;
        } 
        else if (collision.CompareTag(Tags.Armor.ToString()) && hasArmor == false)
        {
            collision.GetComponent<Option>().SetTag(Tags.SelectedArmor);
            hasArmor = true;
            powers[1] = collision.transform.name;
        }

        else if (collision.CompareTag(Tags.TypeAttack.ToString()) && hasTypeAttack == false)
        {
            collision.GetComponent<Option>().SetTag(Tags.SelectedTypeAttack);
            hasTypeAttack = true;
            powers[2] = collision.transform.name;
        }
    }

}
