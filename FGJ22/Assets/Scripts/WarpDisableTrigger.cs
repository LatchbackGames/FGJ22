using System;
using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Entered Trigger");
        switchWorld.CanWarp = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited Trigger");
        switchWorld.CanWarp = true;
    }
}
