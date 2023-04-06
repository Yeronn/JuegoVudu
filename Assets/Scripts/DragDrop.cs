using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    RaycastHit2D hit;
    Camera cam;
    Vector3 pos;
    Vector3 mousePos;
    Transform focus;
    bool isDrag;
    bool tags;

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

            tags = hit.collider.CompareTag("Element") || hit.collider.CompareTag("Armor") ||
            hit.collider.CompareTag("TypeAttack");

            if (hit.collider != null && tags)
            {
                focus = hit.transform;
                print("CLICKED = " + hit.collider.transform.name);
                isDrag = true;
            }
            else
            {
                Debug.Log("Collider " +  hit.collider.transform.name);
            }
        }
        else if ((Input.GetMouseButtonUp(0) && isDrag == true))
        {
            isDrag = false;
        }
        else if (isDrag == true)
        {
            if (!(hit.collider.CompareTag("Element") || hit.collider.CompareTag("Armor") ||
            hit.collider.CompareTag("TypeAttack")))
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
