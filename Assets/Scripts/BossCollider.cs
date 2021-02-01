using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    private Boss1 boss;

    private void Start()
    {
        boss = GetComponentInParent<Boss1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            boss.GetHit();
        }
    }
}
