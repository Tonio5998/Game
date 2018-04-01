using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;
    private Transform Look;
    private Transform Poslook;
    private Transform mytrans;
    float speed;

	void Start ()
    {
        mytrans = GetComponent<Transform>();
    }

	void Update ()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            mytrans = GetComponent<Transform>();
        }
        speed = Input.GetAxis("Mouse Y") * Time.deltaTime;
        if (Look.position.y < 1.45f && speed < 0)
        {
            speed = 0;
        }
        if (Look.position.y > 1.95f && speed > 0)
        {
            speed = 0;
        }
        Look.transform.Translate(0, speed, 0);
	}

    void LateUpdate()
    {
        if (Look == null)
        {
            Look = Player.transform.GetChild(0);
            Poslook = Player.transform.GetChild(1);
        }
        mytrans.position = Poslook.position;
        mytrans.LookAt(Look);
    }
}
