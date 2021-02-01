using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomMenuPanel : MonoBehaviour
{
    [SerializeField] private ScriptableInt score;
    [SerializeField] private ScriptableBool newGame;
    [SerializeField] private ScriptableInt level;
    [SerializeField] private Animator anim;
    private AudioManager audioManager;
    private bool clicked;

    private void Start()
    {
        clicked = false;
        audioManager = GameManager.FindObjectOfType<AudioManager>();
    }
    public void StartNextRound()
    {
        if (!clicked)
        {
            ++level.value;
            if(level.value < 4)
            {
                PlayerPrefs.SetInt("Level", level.value);
                PlayerPrefs.SetInt("Score", score.value);
                newGame.value = false;
                SceneManager.LoadSceneAsync(2);
            } else
            {
                TransitToBetaVersion();
            }
            
        }
        clicked = true;
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayButtonSound(string name)
    {
        if(audioManager!=null)
        audioManager.Play(name);
    }

    private void TransitToBetaVersion()
    {
        anim.SetTrigger("Finish");
    }
}
