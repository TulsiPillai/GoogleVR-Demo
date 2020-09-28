using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleport : MonoBehaviour
{
    private bool clickable = false;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnClick()
    {
        StartCoroutine(StartFade());
    }
    IEnumerator StartFade()
    {
        yield return StartCoroutine(FadeScript.instance.DoFade());
        TeleportPlayer();
        StartCoroutine(FadeScript.instance.DoAppear());
    }
    public void TeleportPlayer()
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }
}
