using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Movement : MonoBehaviour, EnemyMovement
{
    private Transform enemyTransform;
    private Vector3 direction;
    [SerializeField] private float speed = 1;
    private Vector3 defaultPosition;

    private void Start()
    {
        enemyTransform = gameObject.transform;
        defaultPosition = enemyTransform.position;
    }

    private void OnEnable()
    {
        direction = new Vector3(0, -1, 0) * speed;
    }

    private void FixedUpdate()
    {
        enemyTransform.Translate(direction * Time.deltaTime);
        if (enemyTransform.position.y < -12)
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        enemyTransform.position = defaultPosition;
        gameObject.SetActive(false);
    }

}
