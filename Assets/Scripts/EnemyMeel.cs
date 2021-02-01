using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeel : MonoBehaviour, Enemy
{
    [SerializeField] private ScriptableInt playerDamage;
    private GameManager gm;
    private EnemyMovement movement;
    [SerializeField] private int maxHealth = 3;
    private int actualHealth;
    private int scoreAmount = 30;
    [SerializeField] private GameObject enemyBullet;
    public void Attack()
    {
        
    }

    public void ResetPosition()
    {
        actualHealth = maxHealth;
        movement.ResetPosition();
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
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        actualHealth = maxHealth;
        movement = GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet")) GetHit();
    }

}
