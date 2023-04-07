using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Tags
{
    Unselected,
    Element,
    Armor,
    TypeAttack,
    SelectedElement,
    SelectedArmor,
    SelectedTypeAttack,
    Options,
    Muneco
};

public class DragDrop : MonoBehaviour
{
    //Drag and Drop Variables
    private RaycastHit2D hit;
    private Camera cam;
    private Vector3 pos;
    private Vector3 mousePos;
    private Transform focus;
    private bool isDrag;

    //Tests
    //bool Traking;

    private void Start()
    {
        isDrag = false;
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));

            if (hit.collider != null)
            {
                focus = hit.transform;
                print("CLICKED = " + hit.collider.transform.name);
                isDrag = true;
            }
            else
            {
                Debug.Log("Collider " +  hit.collider.transform.name);
            }

            if (hit.collider.transform.parent.tag.Equals("Muneco"))
                //hit.collider.CompareTag(Tags.SelectedTypeAttack.ToString())
            {
                Debug.Log("Este ya no es el padre "+hit.collider.transform.parent.tag);
                Debug.Log(hit.collider.GetComponentInParent<Transform>().gameObject.tag.Equals("Muneco"));
                hit.transform.gameObject.GetComponent<Option>().ReturnInitialPosition();
            }
        }
        else if ((Input.GetMouseButtonUp(0) && isDrag == true))
        {
            isDrag = false;
        }
        else if (isDrag == true)
        {
            if (hit.collider.CompareTag(Tags.Unselected.ToString())) /*"Unselected tag is not tracked"*/
            {
                isDrag = false;
            }
            mousePos = Input.mousePosition;
            mousePos.z = -cam.transform.position.z;
            pos = cam.ScreenToWorldPoint(mousePos);
            focus.position = new Vector3(pos.x, pos.y, focus.position.z);
        }
    }
}
