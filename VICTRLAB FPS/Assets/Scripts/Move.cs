using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour {

    [SerializeField]
    Transform destination;

    NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component isn't attached");
        }
        else
        {
            SetDestination();
        }
	}
	
    private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
