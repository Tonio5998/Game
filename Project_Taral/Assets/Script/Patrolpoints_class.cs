using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolpoints_class : MonoBehaviour
{
    [SerializeField]

    protected float debugDrawRadius = 1.0F;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }


	
}
