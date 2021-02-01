using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Movement : MonoBehaviour
{
    private Transform enemyTransform;
    private Vector3 direction;
    public float speed = 1f;
    private Vector3 defaultPosition;
    [SerializeField] private float startPatrolYPosition;
    private bool reverse = false;

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
        if (!reverse)
        {
            enemyTransform.Translate(direction * Time.deltaTime);
            if (enemyTransform.position.y < startPatrolYPosition)
            {
                direction.y *= -1;
                reverse = true;
            }
            if ((enemyTransform.position.x < -5) || (enemyTransform.position.x > 5))
            {
                direction.x = -direction.x;
            }
        } else
        {
            enemyTransform.Translate(direction * Time.deltaTime);
            if (enemyTransform.position.y > 9)
            {
                direction.y *= -1;
                direction.x *= 2;
                reverse = false;
            }
            if ((enemyTransform.position.x < -5) || (enemyTransform.position.x > 5))
            {
                direction.x = -direction.x;
            }
        }
        if(direction.x > 20)
        {
            direction.x = 4;
        }
    }

    public void ResetPosition()
    {
        enemyTransform.position = defaultPosition;
        gameObject.SetActive(false);
    }
}
