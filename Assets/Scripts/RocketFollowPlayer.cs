using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFollowPlayer : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] private GameObject explosion;
    private GameObject wayPoint;
    private Vector3 direction = new Vector3(0, 1, 0);
    private Vector3 forwardMovement = new Vector3(0, -1, 0);

    private void Start()
    {
        FindTarget();
    }

    private void FixedUpdate()
    {
        if (wayPoint != null)
        {
            direction = wayPoint.transform.position - transform.position;
        }
        else FindTarget();
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), speed * Time.deltaTime);

        transform.Translate(forwardMovement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            GameObject temp = Instantiate(explosion);
            temp.transform.position = transform.position;
            Destroy(temp, .5f);
            Destroy(gameObject);
        }
    }

    private void FindTarget()
    {
        wayPoint = GameObject.FindObjectOfType<PlayerStats>().gameObject;
    }
}
