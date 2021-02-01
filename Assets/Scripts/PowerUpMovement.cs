using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    private Transform powerUpPosition;
    private Vector3 defaultPosition;
    private Vector3 direction;
    private PowerUp powerUp;
    public float speed = 5f;
    [SerializeField] private ScriptableBool playerDamagable;
    private Vector3 turnRight = new Vector3(0, 1,0 ) * 200;
    [SerializeField] private Transform graphics;

    private void Start()
    {
        powerUp = GetComponent<PowerUp>();
        defaultPosition = new Vector3(0, 16, 0);
        powerUpPosition = transform;
        direction = new Vector3(0, -1, 0) * speed;
    }

    private void FixedUpdate()
    {
        powerUpPosition.Translate(direction * Time.deltaTime);
        if(powerUpPosition.position.y < -14)
        {
            powerUpPosition.position = defaultPosition;
            gameObject.SetActive(false);
        }
        graphics.Rotate(turnRight * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerUp.Effect();
            powerUpPosition.position = defaultPosition;
            GetComponent<PowerUpMovement>().enabled = false;
        }
    }
}
