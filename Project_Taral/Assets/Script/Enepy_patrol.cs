using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enepy_patrol : MonoBehaviour
{
    [SerializeField]
    bool _PatrolWaiting;

    [SerializeField]
    float _TotalWaitTime = 3f;

    [SerializeField]
    float _switchProbability = 0.2f;

    [SerializeField]
    List<Patrolpoints_class> _patrolPoints;

    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitimer;




	// Use this for initialization
	void Start ()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.LogError("attache le navmesh au" + gameObject.name);
        }

        else
        {
            if(_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                _currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("All your base are belong to us but there aren't enough");
            }
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _travelling = false;

            if(_PatrolWaiting)
            {
                _waiting = true;
                _waitimer = 0f;
            }

            else
            {
                ChangePatrolPoint();
                SetDestination();
            }

        }

        if(_waiting)
        {
            _waitimer += Time.deltaTime;
            if(_waitimer >= _TotalWaitTime)
            {
                _waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
       
		
	}

    private void SetDestination()
    {
        if (_patrolPoints != null)
        {
            Vector3 targetvector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetvector);
            _travelling = true;
        }
    }

    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= _switchProbability)
        {
            _patrolForward = !_patrolForward;
        }

        if(_patrolForward)
        {
            _currentPatrolIndex = (_currentPatrolIndex - 1) % _patrolPoints.Count;
        }

        else
        {
            if (--_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
    }
}
