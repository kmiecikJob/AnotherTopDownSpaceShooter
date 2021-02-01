using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immortality : MonoBehaviour, PowerUp
{
    [SerializeField] private ScriptableBool damagable;
    [SerializeField] private ScriptableFloat powerUpDuration;
    [SerializeField] private PlayerStats ps;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public void Effect()
    {
        StartCoroutine("PowerUp");
    }
    IEnumerator PowerUp()
    {
        ps.GetShield();
        // Add animation
        damagable.value = false;
        yield return new WaitForSeconds(powerUpDuration.value);
        damagable.value = true;
    }


}
