using Game.Entitys.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coolider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == ("Player"))
        {
            var player = other.GetComponent<PlayerController>();
            player.charac.TakeDamage(10);
            Debug.Log("Player find it");
        }
        else
        {
            Debug.Log("Player not find it");
        }
    }
}
