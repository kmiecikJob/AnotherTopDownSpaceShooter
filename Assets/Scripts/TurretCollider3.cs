using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollider3 : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject explosion;
    [SerializeField] private ScriptableInt playerDamage;
    private Color defaultColor, hitColor;
    private Renderer turretRenderer;
    private Boss3 boss;
    private bool damagable = true;


    private void Start()
    {
        boss = GetComponentInParent<Boss3>();
        turretRenderer = GetComponent<Renderer>();
        defaultColor = turretRenderer.material.color;
        hitColor = new Color(171, 171, 171);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetHit();
        }
    }

    private void GetHit()
    {
        health -= playerDamage.value;
        if (health <= 0 && damagable)
        {
            damagable = false;
            GameObject temp = Instantiate(explosion, transform);
            boss.DestroyNextTurret();
            Destroy(gameObject, 2f);
            Destroy(temp, 2f);
        }
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        turretRenderer.material.color = hitColor;
        yield return new WaitForSeconds(.1f);
        turretRenderer.material.color = defaultColor;
    }
}
