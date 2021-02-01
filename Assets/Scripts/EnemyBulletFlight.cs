using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFlight : MonoBehaviour
{
    private Transform bulletPosition;
    private Vector3 direction;
    public float speed = 5f;
    [SerializeField] private GameObject explosion;

    private void Start()
    {
        direction = new Vector3(0, -1, 0) * speed;
        bulletPosition = transform;
    }

    private void FixedUpdate()
    {
        bulletPosition.Translate(direction * Time.deltaTime);
        if (bulletPosition.position.y < -14) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject temp = Instantiate(explosion);
            temp.transform.position = bulletPosition.position;
            Destroy(temp, .5f);
            Destroy(gameObject);
        }
    }

}
