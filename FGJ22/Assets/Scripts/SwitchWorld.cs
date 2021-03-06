using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorld : MonoBehaviour
{
    public GameObject World1;
    public GameObject World2;
    [HideInInspector]
    public bool CanWarp;

    // Start is called before the first frame update
    void Start()
    {
        CanWarp = true;
        World2.SetActive(false);
        World1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Tab)){
            
            return;
        }
        if (!CanWarp)
        {
            Debug.Log("Can't warp!");
            return;
        }
        if(World1.activeSelf){
            SwitchWorld(World1, World2);
            FindObjectOfType<AudioManager>().Play("Warp");
        }
        else{
            SwitchWorld(World2, World1);
            FindObjectOfType<AudioManager>().Play("Warp");
        }
        void SwitchWorld(GameObject from, GameObject to)
        {
            from.SetActive(false);
            to.SetActive(true);
        }
    }
}
