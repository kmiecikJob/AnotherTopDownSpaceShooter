using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Movement : MonoBehaviour
{
    private Vector3 direction = new Vector3(0, 1, 0);
    private float speed = 3f;
    private Boss2Attack boss;

    private void Start()
    {
        boss = GetComponent<Boss2Attack>();
    }


    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if(transform.position.x < -12)
        {
            transform.Rotate(0, 0, 180);
            boss.ChangeSpawningPoint(false);
        }
        if (transform.position.x > 12)
        {
            transform.Rotate(0, 0, 180);
            boss.ChangeSpawningPoint(true);
        }
    }
}
