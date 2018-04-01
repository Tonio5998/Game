using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour
{
    public Canvas Menu;
    public Canvas quitMenu;
    public Canvas optionMenu;
    public Canvas ControlMenu;
    public Button startText;
    public Button optionText;
    public Button exitText;
    public Button fullscreen;
    public Button windowed;
    public Text txt;
    public Image bar;
    public Canvas loading;

    void Start ()
    {
        Menu = Menu.GetComponent<Canvas>();
        optionMenu = optionMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        ControlMenu = ControlMenu.GetComponent<Canvas>();
        loading = loading.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        fullscreen = fullscreen.GetComponent<Button>();
        windowed = windowed.GetComponent<Button>();
        Menu.enabled = true;
        optionMenu.enabled = false;
        quitMenu.enabled = false;
        ControlMenu.enabled = false;
        loading.enabled = false;
    }

    public void ExitPress() //be used on Exit Button
    {
        quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
        startText.enabled = false; //disable the Play and Exit buttons
        optionText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress() //be used for No button
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        optionText.enabled = true;
    }

    public void StartLevel() //this function will be used on our Play button
    {
        Menu.enabled = false;
        loading.enabled = true;
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        AsyncOperation result = SceneManager.LoadSceneAsync("Select");
        while(!result.isDone)
        {
            float progress = Mathf.Clamp01(result.progress/0.9f);
            bar.fillAmount=progress;
            txt.text = "Loading : " + (progress * 100) + "%";
            yield return null;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Option()
    {
        Menu.enabled = false;
        optionMenu.enabled = true;
    }

    public void Back()
    {
        Menu.enabled = true;
        optionMenu.enabled = false;
    }

    public void Back2()
    {
        ControlMenu.enabled = false;
        optionMenu.enabled = true;
    }


    public void Control()
    {
        optionMenu.enabled = false;
        ControlMenu.enabled = true;
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



// Implémenter le menu !
