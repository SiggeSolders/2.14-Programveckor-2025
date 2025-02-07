using Unity.VisualScripting;
using UnityEngine;

public class Sova : MonoBehaviour
{
    public day_night day_Night_;
    private float range = 100f;
    private PlayerCamera playerCamera_;
    private HeadBob bob_;
    [SerializeField] GameObject player;
    [SerializeField] GameObject SleepTip;
    [SerializeField] GameObject SleepWarning;
    [SerializeField] PlayerMovement playerMovement_;

    private void Start()
    {
        SleepWarning.SetActive(false);
        playerCamera_ = GetComponent<PlayerCamera>();
        bob_ = GetComponent<HeadBob>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //en raycas för att se om det finns något att plocka upp
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
            {
                //make sure pickup tag is attached
                if (hit.transform.gameObject.tag == "Bed")
                {
                    PopUp();
                }
            }
        }
        RaycastHit obj;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out obj, range))
        {
            if (obj.transform.gameObject.tag == "Bed")
            {
                SleepTip.SetActive(true);
            }
            else
            {
                SleepTip.SetActive(false);
            }
        }
        else
        {
            SleepTip.SetActive(false);
        }
    }
    private void PopUp()
    {
        SleepWarning.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerCamera_.enabled = false;
        playerMovement_.enabled = false;
        bob_.enabled = false;
    }
    public void HandleSleep()
    {
        SleepWarning.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerCamera_.enabled = true;
        playerMovement_.enabled = true;
        bob_.enabled = true;
        day_Night_.totalRotation = 360f;
    }
    public void Back()
    {
        SleepWarning.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerCamera_.enabled = true;
        playerMovement_.enabled = true;
        bob_.enabled = true;
    }
}
