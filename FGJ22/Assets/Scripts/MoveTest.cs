using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var trans = GetComponent<Transform>();
        trans.position += new Vector3(1 * Time.deltaTime, 0, 0);
    }
}