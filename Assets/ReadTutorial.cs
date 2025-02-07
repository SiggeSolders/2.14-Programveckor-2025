using UnityEngine;

public class ReadTutorial : MonoBehaviour
{
    private float range = 25f;
    private PlayerCamera playerCamera_;
    private HeadBob bob_;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Interact;
    [SerializeField] GameObject tutorial;
    [SerializeField] PlayerMovement playerMovement_;

    private void Start()
    {
        tutorial.SetActive(false);
        playerCamera_ = GetComponent<PlayerCamera>();
        bob_ = GetComponent<HeadBob>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //en raycas för att se om det finns något att interagera med
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
            {
                //make sure the right tag is attached
                if (hit.transform.gameObject.tag == "Tutorial")
                {
                    PopUp();
                }
            }
        }
        RaycastHit obj;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out obj, range))
        {
            if (obj.transform.gameObject.tag == "Tutorial")
            {
                Interact.SetActive(true);
            }
            else
            {
                Interact.SetActive(false);
            }
        }
        else
        {
            Interact.SetActive(false);
        }
    }
    private void PopUp()
    {
        tutorial.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerCamera_.enabled = false;
        playerMovement_.enabled = false;
        bob_.enabled = false;
    }
    public void Back()
    {
        tutorial.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerCamera_.enabled = true;
        playerMovement_.enabled = true;
        bob_.enabled = true;
    }
}
