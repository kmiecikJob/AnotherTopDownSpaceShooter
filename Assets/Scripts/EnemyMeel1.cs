using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeel1 : MonoBehaviour, Enemy
{
    [SerializeField] private ScriptableInt playerDamage;
    private GameManager gm;
    private EnemyMovementMeel movement;
    [SerializeField] private int maxHealth = 3;
    private int actualHealth;
    private int scoreAmount = 30;
    private Transform playerPosition;
    private Transform enemyTransform;
    private bool charge = true;
    public void Attack()
    {
        Vector3 temp = (playerPosition.position - transform.position).normalized * 15;
        movement.SetNewDirection(temp);
    }

    public void ResetPosition()
    {
        actualHealth = maxHealth;
        charge = true;
        movement.ResetPosition();
    }

    private void FixedUpdate()
    {
        if(enemyTransform.position.y < 6 && charge)
        {
            charge = false;
            Attack();
        }
    }

    public void GetHit()
    {
        actualHealth -= playerDamage.value;
        if (actualHealth <= 0)
        {
            ResetPosition();
            gm.UpdateText(scoreAmount);
        }
    }

    void Start()
    {
        enemyTransform = gameObject.transform;
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        actualHealth = maxHealth;
        movement = GetComponent<EnemyMovementMeel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet")) GetHit();
    }
}
