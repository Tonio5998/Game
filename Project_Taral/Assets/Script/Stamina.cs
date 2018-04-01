using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private GameObject player;
    public Image stam;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        stam.GetComponent<RectTransform>().sizeDelta = new Vector2(player.GetComponent<PlayerControl>().getstamina(), 20);
    }
}