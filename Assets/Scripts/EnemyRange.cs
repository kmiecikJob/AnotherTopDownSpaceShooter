using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour , Enemy
{
    
    [SerializeField] private ScriptableInt playerDamage;
    [SerializeField] private GameManager gm;
    private EnemyMovement movement;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private GameObject enemyBullet;
    private int actualHealth;
    private Vector3 offset;
    private int scoreAmount = 40;
    private AudioManager audioManager;
    
    public void Attack()
    {
        if(audioManager != null)
            audioManager.PlayRandomVolumeAndPitch("GunShoot1");
        Instantiate(enemyBullet, transform.position + offset, Quaternion.identity);
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


    private void OnEnable()
    {
        InvokeRepeating("Attack", 1f, 1f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        offset = new Vector3(0, -1.5f, 0);
        actualHealth = maxHealth;
        movement = GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet")) GetHit();
    }

}
