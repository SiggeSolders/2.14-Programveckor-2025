using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    

    public Transform oriantation;

    float Xrotation;
    float Yrotation;

    public float shake = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (ButtonScript.sensitivityX == 0)
        {
            ButtonScript.sensitivityX += 400;
            ButtonScript.sensitivityY += 400;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * ButtonScript.sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ButtonScript.sensitivityY;

        Yrotation += mouseX;
        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90, 90);

        transform.rotation = Quaternion.Euler(Xrotation+Random.Range(-shake,shake), Yrotation + Random.Range(-shake, shake), 0);
        oriantation.rotation = Quaternion.Euler(0, Yrotation, 0);

        shake -= 10f * Time.deltaTime;
        shake = Mathf.Clamp(shake, 0, 10);
    }
}
