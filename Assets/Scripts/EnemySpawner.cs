using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ScriptableInt level;
    [SerializeField] private ScriptableFloat roundTime;
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    private List<GameObject> enemyPool = new List<GameObject>();
    private bool rightSide = true;

    private void Start()
    {
        InitializeEnemies();
        SpawnEnemy();
    }

    // Initialize pool of enemies in accord with level
    private void InitializeEnemies()
    {
        switch (level.value)
        {
            case 1:
                Level1Enemies();
                break;
            case 2:
                Level2Enemies();
                break;
            case 3:
                Level3Enemies();
                break;
        }
    }

    private void Level1Enemies()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject temp = Instantiate(enemiesList[i + ((level.value - 1) * 3)]);
            temp.SetActive(false);
            enemyPool.Add(temp);
            temp = Instantiate(enemiesList[i + ((level.value - 1) * 3)]);
            temp.SetActive(false);
            enemyPool.Add(temp);
            temp = Instantiate(enemiesList[i + ((level.value - 1) * 3)]);
            temp.SetActive(false);
            enemyPool.Add(temp);
        }
    }

    private void Level2Enemies()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(enemiesList[3]);
            temp.SetActive(false);
            enemyPool.Add(temp);
        }
        for(int i = 0; i < 6; i++)
        {
            GameObject temp2 = Instantiate(enemiesList[4]);
            temp2.SetActive(false);
            enemyPool.Add(temp2);
        }
        for(int i = 0; i < 3; i++)
        {
            GameObject temp3 = Instantiate(enemiesList[5]);
            temp3.SetActive(false);
            enemyPool.Add(temp3);
        }
    }

    private void Level3Enemies()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject temp = Instantiate(enemiesList[5]);
            temp.SetActive(false);
            enemyPool.Add(temp);
        }
        for(int i = 0; i < 3; i++)
        {
            GameObject temp1 = Instantiate(enemiesList[6]);
            temp1.SetActive(false);
            enemyPool.Add(temp1);
            GameObject temp2 = Instantiate(enemiesList[7]);
            temp2.SetActive(false);
            enemyPool.Add(temp2);
        }
    }

    private void Update()
    {
        roundTime.value -= Time.deltaTime;
        if(roundTime.value <= 0)
        {
            CancelInvoke();
            GetComponent<SpawnBoss>().enabled = true;
            this.enabled = false;
        }
    }

    //Get random object from pool
    private GameObject GetPooledObject()
    {
        GameObject temp = enemyPool[Random.Range(0, enemyPool.Count)];
        if (temp.activeInHierarchy == true)
        {
            temp = GetPooledObject();
        }
        return temp;
    }

    //Function to decide of spawning enemies patter, depends of level
    public void SpawnEnemy()
    {
        switch (level.value)
        {
            case 1:
                InvokeRepeating("SpawnLevel1", 1, 1);
                break;
            case 2:
                InvokeRepeating("SpawnLevel2", 1, 10);
                break;
            case 3:
                InvokeRepeating("SpawnLevel3", 1f, 10);
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }
    }

    private void SpawnLevel1()
    {
        GameObject temp = GetPooledObject();
        temp.transform.position = new Vector3(Random.Range(-5, 5), 12, 0);
        temp.SetActive(true);
    }

    private void SpawnLevel2()
    {
        int placementX = Random.Range(-5, 0);
        int j = 1;
        if (rightSide)
        {
            j = -1;
        }
        for (int i = -5; i < 5; i++)
        {
            GameObject temp = enemyPool[i + 5];
            temp.transform.position = new Vector3(i * j, 17 + i, 0);
            temp.SetActive(true);
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject temp2 = enemyPool[10 + i];
            if (!temp2.activeInHierarchy)
            {
                temp2.transform.position = new Vector3(placementX + i * 2, 12, 0);
                temp2.SetActive(true);
            }
            else
            {
                GameObject temp3 = enemyPool[13 + i];
                if (!temp3.activeInHierarchy)
                {
                    temp3.transform.position = new Vector3(placementX + i * 2, 12, 0);
                    temp3.SetActive(true);
                }
                else
                {
                    GameObject temp4 = Instantiate(enemiesList[4]);
                    temp4.transform.position = new Vector3(placementX + i * 2, 12, 0);
                    temp4.SetActive(true);
                    enemyPool.Add(temp4);
                }
            }
        }
        GameObject temp5 = enemyPool[16];
        if (!temp5.activeInHierarchy)
        {
            temp5.transform.position = new Vector3(Random.Range(-4, 4), 12, 0);
            temp5.SetActive(true);
        } else if(!enemyPool[17].activeInHierarchy)
        {
            GameObject temp6 = enemyPool[17];
            temp6.transform.position = new Vector3(Random.Range(-4, 4), 12, 0);
            temp6.SetActive(true);
        } else
        {
            GameObject temp6 = enemyPool[18];
            temp6.transform.position = new Vector3(Random.Range(-4, 4), 12, 0);
            temp6.SetActive(true);
        }
        
        
        rightSide = !rightSide;
    }

    private void SpawnLevel3()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject temp = enemyPool[i];
            if (!temp.activeInHierarchy)
            {
                temp.transform.position = new Vector3(Random.Range(-4, 4), 12, 0);
                temp.SetActive(true);
            }
        }
        GameObject temp2 = GetPooledObject();
        temp2.SetActive(true);
    }
}
