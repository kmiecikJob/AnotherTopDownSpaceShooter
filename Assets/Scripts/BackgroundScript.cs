using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds = new List<GameObject>();
    [SerializeField] private ScriptableInt level;
    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            Instantiate(backgrounds[i + ((level.value - 1) * 2)], transform);
        }
    }
}
