using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This is a singleton class - create a gameobject with fadescript attached to it. Use the instance variable to call functions
public class FadeScript : MonoBehaviour
{
    public static FadeScript instance;
    public Image fadeImage;
    private float alpha = 0;
    private Color fadeColor;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public IEnumerator DoFade()
    {
        fadeColor = fadeImage.color;
        while (fadeImage.color.a < 1)
        {
            fadeColor.a += Time.deltaTime;
            fadeImage.color = fadeColor;
            yield return null;
        }
    }
    public IEnumerator DoAppear()
    {
        fadeColor = fadeImage.color;
        while (fadeImage.color.a >= 0)
        {
            fadeColor.a -= Time.deltaTime;
            fadeImage.color = fadeColor;
            yield return null;
        }
    }
}
