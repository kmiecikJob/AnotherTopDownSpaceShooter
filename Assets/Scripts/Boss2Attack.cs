using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2Attack : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject explosion;
    [SerializeField] private ScriptableInt score;
    [SerializeField] private ScriptableInt playerDamage;
    [SerializeField] private GameObject cannonBall, laserRay, rocketMissle;
    private List<Transform> spawningPoints = new List<Transform>();
    private Vector3 offset;
    private bool leftSide = true;
    private int counterOfDestroyedCannons;
    private AudioManager audioManager;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        counterOfDestroyedCannons = 0;
        offset = new Vector3(0, -1f, 0);
        Transform[] transforms = GetComponentsInChildren<Transform>();
        foreach(Transform temp in transforms)
        {
            spawningPoints.Add(temp);
        }
        StartCoroutine("CannonAttack");
        StartCoroutine("LaserAttack");
        StartCoroutine("RocketAttack");
    }

    public void DestroyNextCannon()
    {
        ++counterOfDestroyedCannons;
        if(counterOfDestroyedCannons >= 6)
        {
            GetHit();
            counterOfDestroyedCannons = 0;
        }
    }

    public void GetHit()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        StopAllCoroutines();
        StartCoroutine("TransitToNextScene");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


    IEnumerator CannonAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            audioManager.PlayRandomVolumeAndPitch("Boss2a");
            if (leftSide)
            {
                if(spawningPoints[1] != null)
                {
                    GameObject temp = Instantiate(cannonBall, spawningPoints[1].position + offset, Quaternion.identity);
                    Destroy(temp, 5f);
                }
            } else if (spawningPoints[4] != null)
            {
                GameObject temp = Instantiate(cannonBall, spawningPoints[4].position + offset, Quaternion.identity);
                Destroy(temp, 5f);
            }
        }
    }

    IEnumerator LaserAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            audioManager.PlayRandomVolumeAndPitch("Boss2b");
            if (leftSide)
            {
                if(spawningPoints[2] != null)
                {
                    GameObject temp = Instantiate(laserRay, spawningPoints[2].position + offset, Quaternion.identity);
                    Destroy(temp, 5f);
                }
            } else if (spawningPoints[5] != null)
            {
                GameObject temp = Instantiate(laserRay, spawningPoints[5].position + offset, Quaternion.identity);
                Destroy(temp, 5f);
            }
        }
    }

    IEnumerator RocketAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            audioManager.PlayRandomVolumeAndPitch("Boss2c");
            if (leftSide)
            {
                if(spawningPoints[3] != null)
                {
                    GameObject temp = Instantiate(rocketMissle, spawningPoints[3].position + offset, Quaternion.identity);
                }
            }
            else if (spawningPoints[6].position != null)
            {
                GameObject temp = Instantiate(rocketMissle, spawningPoints[6].position + offset, Quaternion.identity);
            }
        }
    }

    public void ChangeSpawningPoint(bool leftSide)
    {
        this.leftSide = leftSide;
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
