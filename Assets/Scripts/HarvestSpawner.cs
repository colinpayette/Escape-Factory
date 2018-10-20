using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestSpawner : MonoBehaviour {

    public GameObject harvesterPrefab;
    private ServerCommands commandManager = null;
    private int numberOfHarvesters = 0;

    public void SetCommandManager(ServerCommands manager)
    {
        commandManager = manager;
    }

    public void OnHarvesterSpawnButtonClicked()
    {
        SpawnHarvester();
    }

    private bool SpawnHarvester()
    {
        if(numberOfHarvesters < 2)
        {
            commandManager.SpawnPlacebable(harvesterPrefab, transform.position);
            numberOfHarvesters++;
            return true;
        }

        return false;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
