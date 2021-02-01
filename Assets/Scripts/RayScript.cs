using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    private Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }
    public void AddCollider()
    {
        collider.enabled = true;
    }

    public void RemoveCollider()
    {
        collider.enabled = false;
    }
}
