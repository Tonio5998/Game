using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindsScript : MonoBehaviour {

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text up, left, down, right, jump, shoot,interact;

    private Color32 normal = new Color32(255,255,255,0);
    private Color32 normal2 = new Color32(211,211,211,100);

    private GameObject currentKey;
	// Use this for initialization
	void Start ()
    {
        keys.Add("Up",(KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up","Z")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "Q")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        keys.Add("Shoot", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Shoot", "Mouse0")));
        keys.Add("Interact", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E")));

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        jump.text = keys["Jump"].ToString();
        shoot.text = keys["Shoot"].ToString();
        interact.text = keys["Interact"].ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(keys["Up"]))
        {
            Debug.Log("up");
        }
        if (Input.GetKeyDown(keys["Down"]))
        {
            Debug.Log("down");

        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            Debug.Log("left");
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            Debug.Log("right");
        }
        if (Input.GetKeyDown(keys["Jump"]))
        {
            Debug.Log("jump");
        }
        if (Input.GetKeyDown(keys["Shoot"]))
        {
            Debug.Log("shoot");
        }
        if (Input.GetKeyDown(keys["Interact"]))
        {
            Debug.Log("interact");
        }
    }

    void OnGUI()
    {
        if(currentKey!=null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = normal2;
    }

    public void saveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}
