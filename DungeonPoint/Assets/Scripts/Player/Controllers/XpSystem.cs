using Game;
using Game.Entitys.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpSystem : MonoBehaviour
{
    public static XpSystem instance;
    public float currentXP;
    public float targetXP;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddXP(float XP)
    {
        currentXP += XP;
        Debug.Log("The amount xp is : " + currentXP);
    }
    public void GetXP()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            FindObjectOfType<PlayerController>().lvl.UpdateXp(currentXP);
        }
    }
    
}
