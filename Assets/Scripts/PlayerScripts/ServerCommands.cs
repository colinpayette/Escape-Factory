using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerCommands : NetworkBehaviour
{
    private List<GameObject> networkPrefabs;

    public void SpawnPlacebable(GameObject prefabToSpawn, Vector3 position)
    {
        var networkPrefabs = NetworkManager.singleton.spawnPrefabs;
        int prefabIndex = networkPrefabs.FindIndex(currentPrefab => currentPrefab == prefabToSpawn);
        CmdSpawnPlaceable(prefabIndex, position);
    }

    [Command]
    private void CmdSpawnPlaceable(int prefabIndex, Vector3 position)
    {
        GameObject go = Instantiate(networkPrefabs[prefabIndex], position, Quaternion.identity);
        NetworkServer.Spawn(go);
    }

    // Use this for initialization
    void Start()
    {
        networkPrefabs = NetworkManager.singleton.spawnPrefabs;
        GameObject.FindGameObjectWithTag("PlacingHandler").GetComponent<PlacingHandler>().SetCommandManager(this);
        GameObject.FindGameObjectWithTag("HarvesterSpawner").GetComponent<HarvestSpawner>().SetCommandManager(this);
    }
}
