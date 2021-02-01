using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private List<GameObject> listOfBosses = new List<GameObject>();
    [SerializeField] private GameObject healthPanel;
    [SerializeField] private ScriptableInt level;
    private GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }

    private void OnEnable()
    {
        switch (level.value)
        {
            case 1:
                SpawnBoss1();
                break;
            case 2:
                SpawnBoss2();
                break;
            case 3:
                SpawnBoss3();
                break;
        }
    }

    private void SpawnBoss1()
    {
        GameObject healthPanelInstance = Instantiate(healthPanel, canvas.transform);
        GameObject temp = Instantiate(listOfBosses[0], transform.position, Quaternion.identity);
        temp.GetComponent<Boss1>().SetUpHealthBar(healthPanelInstance);
    }

    private void SpawnBoss2()
    {
        GameObject temp = Instantiate(listOfBosses[1]);
    }
    private void SpawnBoss3()
    {
        GameObject temp = Instantiate(listOfBosses[2], new Vector3(0, 12, 0), Quaternion.identity);
    }
}
