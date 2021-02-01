using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private ScriptableBool newGame;
    [SerializeField] private ScriptableInt level;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        level.value = PlayerPrefs.GetInt("Level");
        if (level.value > 0)
        {
            continueButton.interactable = true;
        }
    }
    public void StartNewGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        newGame.value = true;
        SceneManager.LoadSceneAsync(2);
    }

    public void Continue()
    {
        if (level.value > 1)
        {
            --level.value;
            SceneManager.LoadSceneAsync(1);
        }
        else SceneManager.LoadSceneAsync(2);
        
    }

    public void RateUs()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
