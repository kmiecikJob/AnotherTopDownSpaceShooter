using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 offset = new Vector2();
    private Renderer ren;

    private void Start()
    {
        ren = GetComponent<Renderer>();
    }
    private void FixedUpdate()
    {
        offset = new Vector2(0, Time.time * -speed);
        ren.material.mainTextureOffset = offset;
    }

}
