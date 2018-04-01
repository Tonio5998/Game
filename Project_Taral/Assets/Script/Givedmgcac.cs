using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givedmgcac : MonoBehaviour
{
    public int dmg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerControl>().pertehp(dmg);
        }
        if (other.gameObject.tag == "Alien")
        {
            other.gameObject.GetComponent<AlienHP>().perte(dmg);
        }
    }
}
