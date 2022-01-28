using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WarpDisableTrigger : MonoBehaviour
{
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
