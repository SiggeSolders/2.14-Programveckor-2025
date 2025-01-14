using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] GameObject aimPos;
    private Transform gunPos;
    public Camera camera;

    void Start()
    {
        gunPos = GetComponentInParent<Transform>();
        Debug.Log(gunPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartAim();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopAim();
        }
    }
    void StartAim()
    {
        camera.fieldOfView -= 10.0f;
        transform.position = aimPos.transform.position;
    }
    void StopAim()
    {
        transform.localPosition = Vector3.zero;
        camera.fieldOfView += 10.0f;
    }
}
