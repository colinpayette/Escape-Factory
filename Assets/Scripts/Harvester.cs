using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Harvester : NetworkBehaviour
{
    public float HARVESTER_SPEED;
    private Transform targetPosition = null;

    public void SetTarget(Transform newTarget)
    {
        targetPosition = newTarget;
    }

	// Use this for initialization
	void Start ()
    {
        // Temporary
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isServer)
            return;

        if(targetPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, HARVESTER_SPEED * Time.deltaTime);
        }
	}
}
