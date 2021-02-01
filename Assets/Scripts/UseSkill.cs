using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UseSkill : MonoBehaviour
{
    [SerializeField] private ScriptableInt score;
    [SerializeField] private ScriptableInt skillCost;
    [SerializeField] private ScriptableFloat playerAttackRate;
    [SerializeField] private ScriptableInt playerDamage;
    [SerializeField] private ScriptableInt playerBulletCount;
    [SerializeField] private TextMeshProUGUI costHolder;
    [SerializeField] private TextMeshProUGUI scoreHolder;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        score.value = PlayerPrefs.GetInt("Score");
        scoreHolder.text = score.value.ToString();
        Initialize();
        CostHolderText();
    }

    private void CostHolderText()
    {
        if (skillCost.value == 9999)
        {
            button.interactable = false;
            costHolder.text = "MAX";
        }
        else costHolder.text = skillCost.value.ToString();
    }

    private void Initialize()
    {
        if(playerAttackRate != null)
        {
            playerAttackRate.value = PlayerPrefs.GetFloat("AttackSpeed");
            if(playerAttackRate.value <= .2f)
            {
                skillCost.value = 9999;
            } else skillCost.value = PlayerPrefs.GetInt("Skill1");
        }
        if (playerDamage != null)
        {
            playerDamage.value = PlayerPrefs.GetInt("Damage");
            if (playerDamage.value >= 5)
            {
                skillCost.value = 9999;
            } else skillCost.value = PlayerPrefs.GetInt("Skill2");
        }
        if (playerBulletCount != null)
        {
            playerBulletCount.value = PlayerPrefs.GetInt("BulletCount");
            if (playerBulletCount.value >= 3)
            {
                skillCost.value = 9999;
            } else skillCost.value = PlayerPrefs.GetInt("Skill3");
        }
    }

    public void UseSkillEffect()
    {
        if(score.value >= skillCost.value)
        {
            score.value -= skillCost.value;
            if(playerAttackRate != null)
            {
                playerAttackRate.value -= .1f;
                PlayerPrefs.SetFloat("AttackSpeed", playerAttackRate.value);
                if (playerAttackRate.value <= .2f)
                {
                    skillCost.value = 9999;
                }
                UpdateUI();
                PlayerPrefs.SetInt("Skill1", skillCost.value);
            }
            if(playerDamage != null)
            {
                ++playerDamage.value;
                PlayerPrefs.SetInt("Damage", playerDamage.value);
                if (playerDamage.value >= 5)
                {
                    skillCost.value = 9999;
                }
                UpdateUI();
                PlayerPrefs.SetInt("Skill2", skillCost.value);
            }
            if(playerBulletCount != null)
            {
                ++playerBulletCount.value;
                PlayerPrefs.SetInt("BulletCount", playerBulletCount.value);
                if (playerBulletCount.value >= 3)
                {
                    skillCost.value = 9999;
                }
                UpdateUI();
                PlayerPrefs.SetInt("Skill3", skillCost.value);
            }
        }
    }

    private void UpdateUI()
    {
        if(skillCost.value < 9999)
        {
            skillCost.value += skillCost.value / 2;
            costHolder.text = skillCost.value.ToString();
        } else
        {
            button.interactable = false;
            costHolder.text = "Max";
        }
        scoreHolder.text = score.value.ToString();
    }
}
