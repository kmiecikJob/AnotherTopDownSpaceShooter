using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private ScriptableBool damagable;
    [SerializeField] private ScriptableFloat attackSpeed;
    [SerializeField] private ScriptableFloat powerUpDuration;
    [SerializeField] private GameObject shield;
    [SerializeField] private ScriptableInt playerHealth;
    [SerializeField] private GameObject explosion;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        shield.SetActive(false);
        damagable.value = true;
    }

    public void GetDamage()
    {
        if (damagable)
        {
            GetShield();
            --playerHealth.value;
            if (playerHealth.value <= 0)
            {
                Destroy(gameObject);
            }
            gm.RemoveHealth();
        }
    }

    public void GetShield()
    {
        StartCoroutine("GetShieldCoroutine");
    }

    IEnumerator GetShieldCoroutine()
    {
        damagable.value = false;
        shield.SetActive(true);
        yield return new WaitForSeconds(powerUpDuration.value);
        damagable.value = true;
        shield.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && damagable.value)
        {
            GameObject temp = Instantiate(explosion);
            temp.transform.position = transform.position;
            Destroy(temp, .5f);
            StartCoroutine("GetDamage");
        }
        if (other.CompareTag("EnemyBullet") && damagable.value)
        {
            GameObject temp = Instantiate(explosion);
            temp.transform.position = transform.position;
            Destroy(temp, .5f);
            StartCoroutine("GetDamage");
        }
    }
}
