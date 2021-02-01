using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHearth : MonoBehaviour, PowerUp
{
    [SerializeField] private ScriptableInt playerHealth;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void Effect()
    {
        if (playerHealth.value < 6)
        {
            ++playerHealth.value;
            gameManager.RemoveHealth();
        }
    }
}
