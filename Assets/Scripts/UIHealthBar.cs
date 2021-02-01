using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private List<Sprite> healthSpriteList;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();    
    }

    public void SetUpHelthBarUI(int hp)
    {
        image.sprite = healthSpriteList[hp];
    }
}
