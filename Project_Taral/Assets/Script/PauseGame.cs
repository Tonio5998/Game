using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{

    public Transform PauseMenu;
    public Transform canvas;
    public Transform back;
    public Transform OptionMenu;
    public Transform ControlMenu;
    public Transform player;
    public Texture2D mouse;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 Hospot = Vector2.zero;


    private void Start()
    {
        OptionMenu.gameObject.SetActive(false);
        ControlMenu.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (PauseMenu.gameObject.activeInHierarchy == false && OptionMenu.gameObject.activeInHierarchy == false && ControlMenu.gameObject.activeInHierarchy == false)
        {
            Cursor.visible = false;
        }

    }

    public void Pause()
    {
        Cursor.visible = true;
        if (PauseMenu.gameObject.activeInHierarchy == false)
        {
            PauseMenu.gameObject.SetActive(true);
            OptionMenu.gameObject.SetActive(false);
            ControlMenu.gameObject.SetActive(false);
            back.gameObject.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<Camera>().enabled = false;

        }
        //canvas.gameObject.SetActive(true);
        else
        {
            PauseMenu.gameObject.SetActive(false);
            back.gameObject.SetActive(false);
            Time.timeScale = 1;
            player.GetComponent<Camera>().enabled = true;
        }

    }

    public void ExitPress()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"), 0f);
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }

    public void Option()
    {
        OptionMenu.gameObject.SetActive(true);
        PauseMenu.gameObject.SetActive(false);
    }

    public void Controls()
    {
        ControlMenu.gameObject.SetActive(true);
        OptionMenu.gameObject.SetActive(false);
    }

    public void retrun()
    {
        OptionMenu.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
    }

    public void retrun2()
    {
        ControlMenu.gameObject.SetActive(false);
        OptionMenu.gameObject.SetActive(true);
    }

    public void FullScreen()
    {
        Screen.SetResolution(1366, 1168, true);
    }

    public void Windowed()
    {
        Screen.SetResolution(1366, 1168, false);
    }
}
