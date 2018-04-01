using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCursor : MonoBehaviour {

    // Use this for initialization
    public Texture2D mouse;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 Hospot = Vector2.zero;

    void Start () {
        Cursor.SetCursor(mouse, Hospot, cursorMode);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
