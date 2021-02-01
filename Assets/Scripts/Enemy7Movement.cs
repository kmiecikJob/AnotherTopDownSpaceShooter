using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7Movement : MonoBehaviour, EnemyMovement
{
    private Vector3 direction;
    public float speed = 1f;
    private Vector3 defaultPosition;
    private Transform playerPosition;
    private Vector3 forwardMovement = new Vector3(0, -1, 0);

    private void FindTarget()
    {
        playerPosition = GameObject.FindObjectOfType<PlayerStats>().transform;
    }

    public void ResetPosition()
    {
        transform.position = defaultPosition;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        FindTarget();
        defaultPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (playerPosition != null)
        {
            direction = playerPosition.position - transform.position;
        }
        else FindTarget();

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), speed * Time.deltaTime);

        transform.Translate(forwardMovement * speed * Time.deltaTime);
    }

    
}
