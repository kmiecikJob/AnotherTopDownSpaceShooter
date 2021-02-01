using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFireSpeed : MonoBehaviour, PowerUp
{
    [SerializeField] private ScriptableFloat attackSpeed;
    [SerializeField] private ScriptableFloat powerUpDuration;
    public void Effect()
    {
        StartCoroutine("PowerUp");
    }

    IEnumerator PowerUp()
    {
        // Add animation
        attackSpeed.value *= .5f;
        yield return new WaitForSeconds(powerUpDuration.value);
        attackSpeed.value *= 2;
    }
}
