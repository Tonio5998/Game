using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject ball;
    private GameObject _Firehead;
    private float speed = 1000f;

    private AudioSource soundShot;
    

    void Start ()
    {
        _Firehead = GameObject.Find("Firehead");
        GameObject[] bruitages;
        bruitages = GameObject.FindGameObjectsWithTag("Bruitage");
        foreach (var bruit in bruitages)
        {
            if (bruit.name == "FlingueSong")
                soundShot =  bruit.GetComponent<AudioSource>();
        }
    }
	
	void Update ()
    {
        
	}

    public void fire()
    {
        soundShot.Play();
        GameObject boulette = PhotonNetwork.Instantiate("Prefabs/" + ball.name, _Firehead.transform.position, Quaternion.identity, 0);
        Rigidbody body = boulette.GetComponent<Rigidbody>();
        body.AddForce(_Firehead.transform.forward * speed);
    }
}
