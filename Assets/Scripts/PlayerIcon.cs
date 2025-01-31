using UnityEngine;

public class PlayerIcon : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    float rotation;
    float posX;
    float posZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Får rotationen och positionen av playercam och roterar och flyttar kameran rätt för minimapen
        rotation = playerCam.transform.eulerAngles.y;
        posX = playerCam.transform.position.x;
        posZ = playerCam.transform.position.z;
        transform.position = new Vector3(posX ,39.8f, posZ);
        transform.rotation = Quaternion.Euler(90, rotation - 90, 0);
    }
}
