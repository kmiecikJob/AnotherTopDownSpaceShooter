using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour, Enemy
{
    [SerializeField] private ScriptableInt score;
    [SerializeField] private ScriptableInt playerDamage;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject ray;
    [SerializeField] private Transform p1, p2, p3;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Image healthBar;
    private AudioManager audioManager;
    private int bulletCount = 3;
    private float spreadAngle = 10f;
    private int maxHealth = 80;
    private int currentHealth;
    private Animator anim;
    private bool percent80 = false, percent60 = false, percent40 = false, percent20 = false, alive = true;

    public void SetUpHealthBar(GameObject healthBar)
    {
        this.healthBar = healthBar.GetComponent<Image>();
    }

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        anim = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
    }
    private void OnEnable()
    {
        InvokeRepeating("Attack", 2, 2);
        InvokeRepeating("Attack2", 2, 2);
        InvokeRepeating("Attack3", 2, 2);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void GetHit()
    {
        currentHealth -= playerDamage.value;
        if (currentHealth < 64 && !percent80)
        {
            GameObject tempExplosion = Instantiate(explosion, p1);
            tempExplosion.transform.localScale *= 2;
            Destroy(tempExplosion, 1f);
            GameObject tempExplosion2 = Instantiate(explosion, p3);
            tempExplosion2.transform.localScale *= 2;
            Destroy(tempExplosion2, 1f);
            percent80 = true;
            anim.SetTrigger("percent80");
            CancelInvoke("Attack");
            CancelInvoke("Attack2");
            CancelInvoke("Attack3");
            InvokeRepeating("Attack2", 1, 1);
        }
        if (currentHealth < 48 && !percent60)
        {
            GameObject tempExplosion = Instantiate(explosion,p1);
            tempExplosion.transform.localScale *= 3;
            Destroy(tempExplosion, 1f);
            GameObject tempExplosion2 = Instantiate(explosion,p3);
            tempExplosion2.transform.localScale *= 3;
            Destroy(tempExplosion2, 1f);
            GameObject tempExplosion3 = Instantiate(explosion,p2);
            tempExplosion3.transform.localScale *= 3;
            Destroy(tempExplosion3, 1f);
            percent60 = true;
            anim.SetTrigger("percent60");
            CancelInvoke("Attack2");
            InvokeRepeating("Attack4", 2, 2);
        }
        if (currentHealth < 32 && !percent40)
        {
            GameObject tempExplosion = Instantiate(explosion,p1);
            tempExplosion.transform.localScale *= 4;
            Destroy(tempExplosion, 1f);
            GameObject tempExplosion2 = Instantiate(explosion,p2);
            tempExplosion2.transform.localScale *= 4;
            Destroy(tempExplosion2, 1f);
            GameObject tempExplosion3 = Instantiate(explosion,p3);
            tempExplosion3.transform.localScale *= 4;
            Destroy(tempExplosion3, 1f);
            percent40 = true;
            anim.SetTrigger("percent40");
            InvokeRepeating("Attack2", 1.3f, 1.3f);
        }
        if (currentHealth < 16 && !percent20)
        {
            GameObject tempExplosion = Instantiate(explosion,p1);
            tempExplosion.transform.localScale *= 5;
            Destroy(tempExplosion, 1f);
            GameObject tempExplosion2 = Instantiate(explosion,p2);
            tempExplosion2.transform.localScale *= 5;
            Destroy(tempExplosion2, 1f);
            GameObject tempExplosion3 = Instantiate(explosion,p3);
            tempExplosion3.transform.localScale *= 5;
            Destroy(tempExplosion3, 1f);
            CancelInvoke("Attack2");
            CancelInvoke("Attack4");
            percent20 = true;
            anim.SetTrigger("percent20");
            InvokeRepeating("Attack2", .6f, .6f);
            InvokeRepeating("Attack4", 1.5f, 1.5f);
        }
        if (currentHealth < 0 && alive)
        {
            GameObject tempExplosion = Instantiate(explosion, p1);
            tempExplosion.transform.localScale *= 7;
            Destroy(tempExplosion, 3f);
            GameObject tempExplosion2 = Instantiate(explosion, p2);
            tempExplosion2.transform.localScale *= 7;
            Destroy(tempExplosion2, 3f);
            GameObject tempExplosion3 = Instantiate(explosion, p3);
            tempExplosion3.transform.localScale *= 7;
            Destroy(tempExplosion3, 3f);
            StartCoroutine("TransitToNextScene");
            alive = false;
        }
        float temp = (float)currentHealth / (float)maxHealth;
        healthBar.fillAmount = temp;
    }

    IEnumerator TransitToNextScene()
    {
        CancelInvoke();
        score.value += 300;
        yield return new WaitForSeconds(3f);
        PlayerPrefs.SetInt("Score", score.value);
        SceneManager.LoadSceneAsync("UpgradePlayer");
    }

    public void ResetPosition()
    {
        Destroy(gameObject, 1f);
    }

    public void Attack()
    {
        audioManager.PlayRandomVolumeAndPitch("Boss1");
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bulletClone = (GameObject)Instantiate(bulletPrefab, p1.position, Quaternion.Euler(0, 0, (i * spreadAngle)));
        }
    }
    public void Attack2() {
        audioManager.PlayRandomVolumeAndPitch("Boss1");
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bulletClone1 = (GameObject)Instantiate(bulletPrefab, p2.position, Quaternion.Euler(0, 0, ((i - 1) * spreadAngle)));
        }
    }
    public void Attack3()
    {
        audioManager.PlayRandomVolumeAndPitch("Boss1");
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bulletClone2 = (GameObject)Instantiate(bulletPrefab, p3.position, Quaternion.Euler(0, 0, (i * -spreadAngle)));
        }
    }
    public void Attack4()
    {
        audioManager.PlayRandomVolumeAndPitch("Boss1b");
        GameObject rayAttack = Instantiate(ray, p2);
        Destroy(rayAttack, 1f);
    }
}
