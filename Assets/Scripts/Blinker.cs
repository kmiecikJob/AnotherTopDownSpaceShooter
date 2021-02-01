using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    private SpriteRenderer image;
    private Color defaultColor;
    private Color alphaZero;

    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
        defaultColor = image.color;
        alphaZero = new Color(0, 0, 0, 0);
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        while (true)
        {
            image.color = alphaZero;
            yield return new WaitForSeconds(.1f);
            image.color = defaultColor;
            yield return new WaitForSeconds(.1f);
        }
    }
}
