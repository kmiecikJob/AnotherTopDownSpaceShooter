using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Movement : MonoBehaviour, EnemyMovement
{
    private Transform enemyTransform;
    private Vector3 direction;
    public float speed;
    private Vector3 defaultPosition;

    private void Start()
    {
        enemyTransform = gameObject.transform;
        defaultPosition = enemyTransform.position;
        direction = new Vector3(0, -1, 0) * speed;
    }

    private void FixedUpdate()
    {
        enemyTransform.Translate(direction * Time.deltaTime);
        if (enemyTransform.position.y < -12)
        {
            enemyTransform.position = defaultPosition;
            gameObject.SetActive(false);
        }
    }

    public void ResetPosition()
    {
        enemyTransform.position = defaultPosition;
        gameObject.SetActive(false);
    }
}
