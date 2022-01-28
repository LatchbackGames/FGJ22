using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorld : MonoBehaviour
{
    private Vector3 changeWorld = new Vector3(0, 0, 100);
    public GameObject Char1;
    public GameObject Char2;
    public GameObject World1;
    public GameObject World2;
    //[HideInInspector]
    public bool CanWarp;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<Transform>().position);
        CanWarp = true;
        Char2.GetComponent<BoxCollider2D>().enabled = false;
        World2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Tab))
            return;
        if (!CanWarp)
        {
            Debug.Log("Can't warp!");
            return;
        }
        var trans = GetComponent<Transform>();
        var char1Coll = Char1.GetComponent<BoxCollider2D>();
        var char2Coll = Char2.GetComponent<BoxCollider2D>();
        Char2.GetComponent<BoxCollider2D>().enabled = true;
        
        if (trans.position.z == 0)
        {
            trans.position += changeWorld;
            SwitchWorld(World1, World2, char1Coll, char2Coll);
            Debug.Log("switch from 1 to 2");
        }
        else
        {
            trans.position -= changeWorld;
            SwitchWorld(World2, World1, char2Coll, char1Coll);
            Debug.Log("switch from 2 to 1");
            
        }

        void SwitchWorld(GameObject from, GameObject to, BoxCollider2D fromChar, BoxCollider2D toChar)
        {
            from.SetActive(false);
            to.SetActive(true);
            fromChar.enabled = false;
            toChar.enabled = true;
        }
    }
}
