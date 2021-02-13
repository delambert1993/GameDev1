using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    float nextSpawnTime;
    [SerializeField]
    GameObject player;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnPlayer()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
