using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder_Mk2 : MonoBehaviour
{
    //Detta skript flyttar kameran till spelaren
    
    public Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
