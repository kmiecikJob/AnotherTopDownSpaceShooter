using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
    [SerializeField] private ScriptableInt score;
    [SerializeField] private ScriptableFloat attackSpeed;
    [SerializeField] private TextMeshProUGUI scoreValueHolder;

    private void Start()
    {
        scoreValueHolder.text = score.value.ToString();
    }

    public void Upgrade1(int value)
    {
        if(score.value >= value)
        {
            score.value -= value;
            scoreValueHolder.text = score.value.ToString();
            attackSpeed.value -= .1f;
        }
    }

    public void Upgrade2(int value)
    {
        if (score.value >= value)
        {
            score.value -= value;
            scoreValueHolder.text = score.value.ToString();
            //Add second bullet
        }
    }

    public void Upgrade3(int value)
    {
        if (score.value >= value)
        {
            score.value -= value;
            scoreValueHolder.text = score.value.ToString();
            //Increase bullet damage
        }
    }

}
