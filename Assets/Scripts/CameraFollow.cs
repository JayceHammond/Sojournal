using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
    }
}
