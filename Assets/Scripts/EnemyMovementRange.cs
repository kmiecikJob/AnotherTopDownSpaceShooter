﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRange : MonoBehaviour, EnemyMovement
{
    private Transform enemyTransform;
    private Vector3 direction;
    public float speed = 1f;
    private Vector3 defaultPosition;
    [SerializeField] private float startPatrolYPosition;

    private void Start()
    {
        enemyTransform = gameObject.transform;
        defaultPosition = enemyTransform.position;
    }

    private void OnEnable()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-2f, -.5f), 0) * speed;
    }

    private void FixedUpdate()
    {
        enemyTransform.Translate(direction * Time.deltaTime);
        if (enemyTransform.position.y < startPatrolYPosition)
        {
            enemyTransform.position = new Vector3(enemyTransform.position.x, startPatrolYPosition + .1f, enemyTransform.position.z);
            direction.y = 0;
            direction.x *= 2;
        }
        if ((enemyTransform.position.x < -5) || (enemyTransform.position.x > 5))
        {
            direction.x = -direction.x;
        }
    }

    public void ResetPosition()
    {
        enemyTransform.position = defaultPosition;
        gameObject.SetActive(false);
    }
}
