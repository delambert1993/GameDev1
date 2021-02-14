using Assets.Scripts.UI_FX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField]
    GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.transform.FindChild("UIInteract").GetComponentInChildren<LookToCamara>().gameObject;
        txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txt.SetActive(true);
            Debug.Log("Npc proximity");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txt.SetActive(false);
            Debug.Log("Npc not aprox");
        }
    }
}
