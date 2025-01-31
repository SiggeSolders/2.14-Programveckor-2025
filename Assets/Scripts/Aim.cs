using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] GameObject aimPos; //Var vapnet �r nar man siktar
    private Transform gunPos; //Var vapnet �r plasert n�r man inte siktar
    public Camera camera;

    void Start()
    {
        gunPos = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       //Checkar om man h�ller ner knappen f�r att sikta
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
        //Flyttar vapnet till aimPos och �ndrar FOV s� att man zoomar lite
        camera.fieldOfView -= 10.0f;
        transform.position = aimPos.transform.position;
    }
    void StopAim()
    {
        //Flyttar tillbaka vapnet och resettar FOV-effecten
        transform.localPosition = Vector3.zero;
        camera.fieldOfView += 10.0f;
    }
}
