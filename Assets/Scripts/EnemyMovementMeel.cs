
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementMeel : MonoBehaviour, EnemyMovement
{
    private Transform enemyTransform;
    private Vector3 direction;
    public float speed;
    private Vector3 defaultPosition;

    public void SetNewDirection(Vector3 direction)
    {
        this.direction = direction;
    }

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
        if(enemyTransform.position.y < -12)
        {
            enemyTransform.position = defaultPosition;
            gameObject.SetActive(false);
        }
        if((enemyTransform.position.x < -5) || (enemyTransform.position.x > 5))
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
