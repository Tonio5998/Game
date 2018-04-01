using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    private GameObject player;
    public GameObject spawn;
    public Canvas mort;
    public Text life;
    public Button Quit1full;
    public Button quit;
    public Transform playerCam;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mort.gameObject.SetActive(false);
        quit = quit.GetComponent<Button>();
        Quit1full = Quit1full.GetComponent<Button>();
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player.GetComponent<PlayerControl>().gethp() <= 0 && player.GetComponent<PlayerControl>().getlife() > 0)
        {
            player.GetComponent<PlayerControl>().resetlife(spawn.transform.position);
        }
        else if (player.GetComponent<PlayerControl>().getlife() <= 0)
        {
            Destroy(player, 0f);
            mort.gameObject.SetActive(true);
            playerCam.GetComponent<Camera>().enabled = false;
            Cursor.visible = true;
        }
        life.text =Convert.ToString(player.GetComponent<PlayerControl>().getlife());
    }

    public Vector3 dead()
    {
        return spawn.transform.position;
    }

    public void menuPress()
    {
        SceneManager.LoadScene("Interface");
    }

    public void exitPress()
    {
        Application.Quit();
    }
}
