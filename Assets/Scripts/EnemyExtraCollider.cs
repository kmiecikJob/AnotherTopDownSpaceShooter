using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExtraCollider : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet")) enemy.GetHit();
    }
}
