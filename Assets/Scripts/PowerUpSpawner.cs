using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUpList = new List<GameObject>();
    private List<GameObject> powerUpPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < powerUpList.Count; i++)
        {
            GameObject temp = Instantiate(powerUpList[i]);
            temp.GetComponent<PowerUpMovement>().enabled = false;
            temp.transform.position = new Vector3(Random.Range(-5, 5), 16, 0);
            powerUpPool.Add(temp);
        }
        InvokeRepeating("SpawnPowerUp", 5, 5);
    }

    private GameObject GetPooledObject()
    {
        GameObject temp = null;
        temp = powerUpPool[Random.Range(0, powerUpPool.Count)];
        temp.GetComponent<PowerUpMovement>().enabled = true;
        return temp;
    }

    public void SpawnPowerUp()
    {
        GameObject temp = GetPooledObject();
        temp.transform.position = new Vector3(Random.Range(-5, 5), 16, 0);
    }
}
