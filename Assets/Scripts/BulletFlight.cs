using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlight : MonoBehaviour
{
    private Transform bulletPosition;
    private Vector3 direction;
    public float speed = 5f;
    private Vector3 defaultPosition;
    [SerializeField] private GameObject explosion;
    private void Start()
    {
        defaultPosition = new Vector3(0, -15, 0);
        direction = new Vector3(0, 1, 0) * speed;
        bulletPosition = transform;
    }

    private void FixedUpdate()
    {
        bulletPosition.Translate(direction * Time.deltaTime);
        if (bulletPosition.position.y > 14) gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject temp = Instantiate(explosion);
            temp.transform.position = bulletPosition.position;
            Destroy(temp, .5f);
            bulletPosition.position = defaultPosition;
            gameObject.SetActive(false);
        }
    }
}
