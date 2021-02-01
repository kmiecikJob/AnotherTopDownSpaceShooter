using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScriptableBool newGame;
    [SerializeField] private ScriptableFloat attackSpeed;
    [SerializeField] private ScriptableInt damage;
    [SerializeField] private ScriptableInt bulletCount;
    [SerializeField] private ScriptableInt skill1;
    [SerializeField] private ScriptableInt skill2;
    [SerializeField] private ScriptableInt skill3;

    [SerializeField] private ScriptableFloat roundTime;
    [SerializeField] private ScriptableInt score;
    [SerializeField] private ScriptableInt playerHealth;
    [SerializeField] private UIHealthBar healthPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScriptableInt level;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private GameObject background;
    [SerializeField] private float timeRound;

    private void Start()
    {
        if (newGame.value)
        {
            ResetPlayerStats();
        }
        attackSpeed.value = PlayerPrefs.GetFloat("AttackSpeed");
        damage.value = PlayerPrefs.GetInt("Damage");
        bulletCount.value = PlayerPrefs.GetInt("BulletCount");
        score.value = PlayerPrefs.GetInt("Score");
        playerHealth.value = 6;
        roundTime.value = timeRound;
        InitializeLevel();
        scoreText.text = score.value.ToString();
    }

    private void ResetPlayerStats()
    {
        attackSpeed.value = .5f;
        damage.value = 1;
        bulletCount.value = 1;
        score.value = 0;
        PlayerPrefs.SetInt("Score", score.value);
        skill1.value = 1000;
        skill2.value = 1500;
        skill3.value = 2000;
        PlayerPrefs.SetInt("Skill1", skill1.value);
        PlayerPrefs.SetInt("Skill2", skill2.value);
        PlayerPrefs.SetInt("Skill3", skill3.value);
        level.value = 1;
        PlayerPrefs.SetInt("Damage", damage.value);
        PlayerPrefs.SetInt("BulletCount", bulletCount.value);
        PlayerPrefs.SetFloat("AttackSpeed", attackSpeed.value);
    }

    public void RemoveHealth()
    {
        healthPanel.SetUpHelthBarUI(playerHealth.value);
        if(playerHealth.value <= 0)
        {
            StartCoroutine("TransitToMenu");
        }
    }

    IEnumerator TransitToMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(0);
    }

    public void UpdateText(int i)
    {
        score.value += i;
        scoreText.text = score.value.ToString(); 
    }

    public void InitializeLevel()
    {
        Instantiate(player);
        Instantiate(spawnManager);
        Instantiate(background);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                StopAllCoroutines();
                if(level.value > 1)
                {
                    level.value -= 1;
                    SceneManager.LoadSceneAsync("UpgradePlayer");
                } else
                {
                    SceneManager.LoadSceneAsync("MenuScene");
                }
                
                
            }
        }
    }
}
