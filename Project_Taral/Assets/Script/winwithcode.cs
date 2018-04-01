using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winwithcode : MonoBehaviour
{
    private GameObject player;
    public Canvas gg;
    public Button exit;
    public Transform playerCam;
    public Button main;

    void Start ()
    {
        gg.gameObject.SetActive(false);
    }

	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerControl>().getcode() == 5)
        {
            gg.gameObject.SetActive(true);
            playerCam.GetComponent<Camera>().enabled = false;
            Cursor.visible = true;
        }
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
