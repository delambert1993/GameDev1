﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{
    public static AnimationsPlayer instance;
    public bool canReceiveInput;
    public bool inputReceived;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if(Input.GetKey(KeyCode.R))
        {
            if (canReceiveInput)
            {
                Debug.Log("R pressed.");
                inputReceived = true;
                canReceiveInput = false;
            }
            else
            {
                return;
            }
        }
    }

    public void InputManager()
    {
        if(!canReceiveInput)
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;    
        }

    }
}
