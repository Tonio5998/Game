using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private CharacterController cc;

	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(cc.isGrounded && cc.velocity.magnitude>1f && GetComponent<AudioSource>().isPlaying==false && !Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<AudioSource>().volume = Random.Range(0.6f, 0.8f);
            GetComponent<AudioSource>().pitch = Random.Range(1f, 1.1f);
            GetComponent<AudioSource>().Play();
        }
        if (cc.isGrounded && cc.velocity.magnitude > 1f && GetComponent<AudioSource>().isPlaying == false && Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<AudioSource>().volume = Random.Range(0.6f, 0.8f);
            GetComponent<AudioSource>().pitch = Random.Range(1.4f, 1.5f);
            GetComponent<AudioSource>().Play();
        }
    }
}
