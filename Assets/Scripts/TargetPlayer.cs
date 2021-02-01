using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 direction;
    private Transform playerPosition;
    void Start()
    {
        FindTarget();
    }

    private void FixedUpdate()
    {
        if (playerPosition != null)
        {
            direction = transform.position - playerPosition.position;
        }
        else FindTarget();

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), speed * Time.deltaTime);

    }

    private void FindTarget()
    {
        playerPosition = GameObject.FindObjectOfType<PlayerStats>().transform;
    }
}
