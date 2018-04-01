using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHP : MonoBehaviour
{
    private int hp;
    public Canvas gg;

	void Start ()
    {
    }
	

	void Update ()
    {
	}

    public void perte(int i)
    {
        hp -= i;
    }
}
