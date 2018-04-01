using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject obj;
    public int i;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(obj, 0f);
            other.gameObject.GetComponent<PlayerControl>().add(i);
        }
    }
}
