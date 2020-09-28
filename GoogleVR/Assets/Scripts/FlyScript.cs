using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyScript : MonoBehaviour
{
    private bool isFlying = false;
    public float playerSpeed;
    public Transform startPoint;
    public TextMeshPro label;
    //when user clicks on the ground switch between flying and landing modes
    public void OnGroundSelected()
    {
        if (isFlying)
        {
            isFlying = false;
            StartCoroutine(Land());
        }
        else
        {
            isFlying = true;
        }
    }
    //when user looks at the ground, display label
    public void OnPointerEnter()
    {
        if (isFlying)
            label.text = "Land";
        else
            label.text = "Fly";
    }
    //hide label when user looks away
    public void OnPointerExit()
    {
        label.text = string.Empty;
    }
    void Update()
    {
        if (isFlying)
            transform.position += Camera.main.transform.forward * playerSpeed * Time.deltaTime;
    }
    //teleport and land to starting point
    public IEnumerator Land()
    {
        yield return StartCoroutine(FadeScript.instance.DoFade());
        transform.position = startPoint.position;
        StartCoroutine(FadeScript.instance.DoAppear());
    }
}
