using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Camera cam;
    private bool IsDragable = true;
    private Transform playerTransform;

    private void Start()
    {
        cam = Camera.main;
        playerTransform = gameObject.transform;
    }

    void OnMouseDown()
    {
        if (IsDragable)    // Only do if IsDraggable == true
        {
            screenPoint = cam.WorldToScreenPoint(gameObject.transform.position);

            offset = playerTransform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (IsDragable)    // Only do if IsDraggable == true
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); // hardcode the y and z for your use

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            if(curPosition.x < -6.3)
            {
                curPosition.x = -6.3f;
            }
            if(curPosition.x > 6.3f)
            {
                curPosition.x = 6.3f;
            }
            if(curPosition.y < -12)
            {
                curPosition.y = -12;
            }
            if (curPosition.y > 12)
            {
                curPosition.y = 12;
            }
            playerTransform.position = curPosition;
        }
    }
}
