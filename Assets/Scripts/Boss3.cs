using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss3 : MonoBehaviour
{
    private int counterOfDestroyedCannons = 0;
    private GameManager gameManager;
    private AudioManager audioManager;
    [SerializeField] private Transform sp1, sp2, sp3, sp4, sp5, sp6, sp7;
    [SerializeField] private GameObject explosion;
    [SerializeField] private ScriptableInt score;
    [SerializeField] private ScriptableInt playerDamage;
    [SerializeField] private List<GameObject> misslesPrefab;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        counterOfDestroyedCannons = 0;
        StartCoroutine("MissleAttack");
        StartCoroutine("LaserAttack");
        StartCoroutine("CannonAttack");
    }

    IEnumerator MissleAttack()
    {
        while (true)
        {
            if (sp1 != null)
            {
                GameObject temp = Instantiate(misslesPrefab[0], sp1.position, sp1.rotation);
            }
            yield return new WaitForSeconds(.5f);
            if (sp2 != null)
            {
                GameObject temp2 = Instantiate(misslesPrefab[0], sp2.position, sp2.rotation);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator LaserAttack()
    {
        while (true)
        {
            if (sp3 != null)
            {
                GameObject temp = Instantiate(misslesPrefab[1], sp3.position, sp3.rotation);
            }
            if (sp5 != null)
            {
                GameObject temp2 = Instantiate(misslesPrefab[1], sp5.position, sp5.rotation);
            }
            yield return new WaitForSeconds(.5f);
            if (sp6 != null)
            {
                GameObject temp2 = Instantiate(misslesPrefab[1], sp6.position, sp6.rotation);
            }
            if (sp4 != null)
            {
                GameObject temp = Instantiate(misslesPrefab[1], sp4.position, sp4.rotation);
            }

            yield return new WaitForSeconds(1f);
        } 
    }

    IEnumerator CannonAttack()
    {
        while (true)
        {
            Debug.Log("CannonAttack");
            if (sp7 != null)
            {
                GameObject temp = Instantiate(misslesPrefab[2], sp7.position, sp7.rotation);
            }
            yield return new WaitForSeconds(.7f);
        }
    }


    public void DestroyNextTurret()
    {
        ++counterOfDestroyedCannons;
        if (counterOfDestroyedCannons >= 5)
        {
            StartCoroutine("TransitToNextScene");

            Debug.Log("GameOver");
            counterOfDestroyedCannons = 0;
        }
    }

    IEnumerator TransitToNextScene()
    {
        CancelInvoke();
        score.value += 300;
        yield return new WaitForSeconds(3f);
        PlayerPrefs.SetInt("Score", score.value);
        SceneManager.LoadSceneAsync("UpgradePlayer");
    }
}
