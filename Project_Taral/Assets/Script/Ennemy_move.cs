using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy_move : MonoBehaviour {
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start ()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("Faut attacher le navmesh à" + gameObject.name);
        }
        else
        {
            SetDestination();
        }
	}

    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetvector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetvector);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
