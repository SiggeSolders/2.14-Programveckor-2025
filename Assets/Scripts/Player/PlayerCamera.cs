using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    

    public Transform oriantation;

    float Xrotation;
    float Yrotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * ButtonScript.sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ButtonScript.sensitivityY;

        Yrotation += mouseX;
        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90, 90);

        transform.rotation = Quaternion.Euler(Xrotation, Yrotation, 0);
        oriantation.rotation = Quaternion.Euler(0, Yrotation, 0);

    }
}
