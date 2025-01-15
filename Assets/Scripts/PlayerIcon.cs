using UnityEngine;

public class PlayerIcon : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    float rotation;
    float posX;
    float posZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the y-rotation of the playerCam
        rotation = playerCam.transform.eulerAngles.y;
        posX = playerCam.transform.position.x;
        posZ = playerCam.transform.position.z;
        transform.position = new Vector3(posX ,39.8f, posZ);

        // Set the object's rotation to 90 degrees on the x-axis and match the y-axis rotation of the camera
        transform.rotation = Quaternion.Euler(90, rotation - 90, 0);
    }
}
