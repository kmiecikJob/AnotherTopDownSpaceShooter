using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7Attack : MonoBehaviour, Enemy
{
    [SerializeField] private ScriptableInt playerDamage;
    private GameManager gm;
    private EnemyMovement movement;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject enemyBullet;
    private int actualHealth;
    private int scoreAmount = 150;
    private AudioManager audioManager;
    [SerializeField] private Transform spawningPoint;
    [SerializeField] private GameObject explosion;

    public void Attack()
    {
        GameObject explosionTemp = Instantiate(explosion, spawningPoint);
        Destroy(explosionTemp, .5f);
        if (audioManager != null)
            audioManager.PlayRandomVolumeAndPitch("GunShoot1");
        GameObject temp = Instantiate(enemyBullet, spawningPoint.position, spawningPoint.rotation);
        Destroy(temp, 8f);
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

    public void ResetPosition()
    {
        actualHealth = maxHealth;
        movement.ResetPosition();
    }

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        movement = GetComponent<EnemyMovement>();
    }

    private void OnEnable()
    {
        actualHealth = maxHealth;
        InvokeRepeating("Attack", 2f, 2f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet")) GetHit();
    }
}
