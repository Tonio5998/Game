using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class select : MonoBehaviour {

    public Button titouan;
	// Use this for initialization
	void Start () {
        titouan = titouan.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
    }
    public void press()
    {
        SceneManager.LoadScene("Taral");
    }
}
