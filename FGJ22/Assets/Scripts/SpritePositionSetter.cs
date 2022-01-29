using UnityEngine;

public class SpritePositionSetter : MonoBehaviour {

    void Awake () {
        SetPosition();
    }

    void Update () {
        SetPosition();
    }

    void SetPosition () {
        // If you want to change the transform, use this
        Vector3 newPosition = transform.position;
        newPosition.z = transform.position.y;
        transform.position = newPosition;
    }

}