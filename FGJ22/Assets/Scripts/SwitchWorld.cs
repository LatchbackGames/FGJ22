using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorld : MonoBehaviour
{
    private Vector3 changeWorld = new Vector3(0, 0, 100);
    public BoxCollider2D Char1;
    public BoxCollider2D Char2;

    // Start is called before the first frame update
    void Start()
    {
        Char2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Tab))
            return;
        var trans = GetComponent<Transform>();
        
        if (trans.position.z == 0)
        {
            trans.position += changeWorld;
            Char1.enabled = false;
            Char2.enabled = true;
        }
        else
        {
            trans.position -= changeWorld;
            Char1.enabled = true;
            Char2.enabled = false;
            
        }
    }
}
