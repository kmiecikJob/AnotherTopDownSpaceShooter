using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<Transform> spawningBulletsList = new List<Transform>();
    [SerializeField] private ScriptableFloat attackSpeed;
    [SerializeField] private ScriptableInt bulletsPerShoot;
    private List<GameObject> bulletPool = new List<GameObject>();
    private AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();

        //Instantiate bullet objects, add them to list, set then as inactive
        for(int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(bulletPrefab);
            temp.SetActive(false);
            bulletPool.Add(temp);
        }

        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            for(int i = 0; i < bulletsPerShoot.value; i++)
            {
                if(audioManager != null)
                    audioManager.PlayRandomVolumeAndPitch("GunShoot2");
                
                //Get object from pool, move onto player and make it active
                GameObject temp = GetPooledObject();
                temp.transform.position = spawningBulletsList[i].position;
                temp.SetActive(true);
            }
            yield return new WaitForSeconds(attackSpeed.value);
        }
    }

    private GameObject GetPooledObject()
    {
        // Get in active game object from pool
        GameObject temp = null;
        for(int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                temp = bulletPool[i];
                break;
            }
        }
        //Just for safety
        //If every possible object in pool is active create new object
        if(temp == null)
        {
            temp = Instantiate(bulletPrefab);
            temp.SetActive(false);
            bulletPool.Add(temp);
        }
        return temp;
    }

}
