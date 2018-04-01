using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Death : MonoBehaviour
{
    public GameObject Balle;
    public int dmg;

    void Start()
    {
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "map")
        {
            Destroy(Balle, 0f);
        }
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerControl>().pertehp(dmg);
            Destroy(Balle, 0f);
        }
        if (other.gameObject.tag == "Alien")
        {
            other.gameObject.GetComponent<AlienHP>().perte(dmg);
            Destroy(Balle, 0f);
        }
        Destroy(Balle, 10f);
    }
}
