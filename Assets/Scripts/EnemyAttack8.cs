using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack8 : MonoBehaviour, Enemy
{
    private Vector3 defaultPosition;
    [SerializeField] private ScriptableInt playerDamage;
    private GameManager gm;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject enemyRocket;
    private int actualHealth;
    private int scoreAmount = 150;
    private AudioManager audioManager;
    [SerializeField] private Transform sP1, sP2;
    [SerializeField] private GameObject explosion;
    private bool leftMissle = true;

    public void Attack()
    {
        if (leftMissle)
        {
            GameObject explosionTemp1 = Instantiate(explosion, sP1);
            Destroy(explosionTemp1, .5f);
            if (audioManager != null)
                audioManager.PlayRandomVolumeAndPitch("Boss2b");
            GameObject temp1 = Instantiate(enemyRocket, sP1.position, sP1.rotation);
            Destroy(temp1, 8f);
        } else
        {
            GameObject explosionTemp2 = Instantiate(explosion, sP2);
            Destroy(explosionTemp2, .5f);
            if (audioManager != null)
                audioManager.PlayRandomVolumeAndPitch("Boss2b");
            GameObject temp2 = Instantiate(enemyRocket, sP2.position, sP2.rotation);
            Destroy(temp2, 8f);
        }
        leftMissle = !leftMissle;
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
        transform.position = defaultPosition;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        defaultPosition = new Vector3(-9.5f, 6.5f, 0);
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
