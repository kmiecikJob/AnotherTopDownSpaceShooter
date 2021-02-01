using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Attack : MonoBehaviour, Enemy
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private ScriptableInt playerDamage;
    private GameManager gm;
    private EnemyMovement movement;
    [SerializeField] private int maxHealth = 10;
    private int actualHealth;
    private int scoreAmount = 80;
    [SerializeField] private List<Transform> spawningBulletsPoints = new List<Transform>();
    private AudioManager audioManager;
    public void Attack()
    {
        if(audioManager!= null)
            audioManager.PlayRandomVolumeAndPitch("GunShoot3");
        for(int i = 0; i < spawningBulletsPoints.Count; i++)
        {
            GameObject temp = Instantiate(enemyBullet, spawningBulletsPoints[i].position, Quaternion.identity);
            Vector3 direction = Vector3.down;
            switch (i)
            {
                case 0:
                    temp.transform.Rotate(0, 0, 180);
                    break;
                case 1:
                    temp.transform.Rotate(0, 0, 90);
                    break;
                case 2:
                    temp.transform.Rotate(0, 0, 270);
                    break;
            }
            Destroy(temp, 5f);
        }
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
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        actualHealth = maxHealth;
        movement = GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet")) GetHit();
    }
}
