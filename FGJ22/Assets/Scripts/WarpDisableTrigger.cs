using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WarpDisableTrigger : MonoBehaviour
{
    
    //HOWTO Add all objects to both worlds, then copy those objects to other world under the WarpBlockers parent
    //Add this script to all objects, remove sprites from the objects and mark them as triggers
    private SwitchWorld switchWorld;

    private void Start()
    {
        switchWorld = GameObject.FindWithTag("MainCamera").GetComponent<SwitchWorld>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            switchWorld.CanWarp = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            switchWorld.CanWarp = true;
    }
}
