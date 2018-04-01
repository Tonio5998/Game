using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] slot = new GameObject[5];
    public Text[] t = new Text[4];
    public GameObject player;
    public int select = 0;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update ()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        foreach (var s in slot)
        {
            s.GetComponent<Image>().enabled = false;
        }
        player.GetComponent<PlayerControl>().resetarm();
        if (Input.GetKeyDown(Control.tir))
        {
            player.GetComponent<PlayerControl>().tirarm(select);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            select += 1;
            if (select == 5)
            {
                select = 0;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            select -= 1;
            if (select == -1)
            {
                select = 4;
            }
        }
        slot[select].GetComponent<Image>().enabled = true;
        player.GetComponent<PlayerControl>().arm(select);
        t[0].text = Convert.ToString(player.GetComponent<PlayerControl>().ar());
        t[1].text = Convert.ToString(player.GetComponent<PlayerControl>().glo());
        t[2].text = Convert.ToString(player.GetComponent<PlayerControl>().he());
        t[3].text = Convert.ToString(player.GetComponent<PlayerControl>().c());
    }
}
