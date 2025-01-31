using TMPro;
using UnityEngine;

public class PickUpSkript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    public GameObject pickUpText;
    public GameObject emptyHand;

    public float throwForce = 500f; 
    public float pickUpRange = 100f; 
    private GameObject heldObj; //objektet som flyttas
    private Transform topObject; //objektet som flyttas (om vi tar en ragdoll)
    private Rigidbody heldObjRb; 
    private bool canDrop = true; //För att droppa
    private int LayerNumber; //layer index
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("HoldLayer");
    }
    void Update()
    {
        //Om man inte håller i ett vapen och tittar på något man kan plocka upp ska en pop-up säga att man kan plocka upp annars stängs den av
        if (emptyHand.gameObject.activeSelf == true)
        {
            RaycastHit obj;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out obj, pickUpRange))
            {
                if (obj.transform.gameObject.tag == "CanPickUp")
                {
                    if(heldObj == null)
                    {
                        pickUpText.SetActive(true);
                    }
                    else
                    {
                        pickUpText.SetActive(false);
                    }
                }
                else
                {
                    pickUpText.SetActive(false);
                }
            }
            else
            {
                pickUpText.SetActive(false);
            }
        }
        else
        {
            pickUpText.SetActive(false);
        }

        //Om man inte håller i något, klickar på E och tittar på något som har taggen "CanPickUP ska objektet plockas upp
        if (emptyHand.gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (heldObj == null) //om man inte håller i något
                {
                    //en raycas för att se om det finns något att plocka upp
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                    {
                        //make sure pickup tag is attached
                        if (hit.transform.gameObject.tag == "CanPickUp")
                        {
                            PickUpObject(hit.transform.gameObject);
                        }
                    }
                }
                else
                {
                    if (canDrop == true)
                    {
                        DropObject();
                    }
                }
            }
            if (heldObj != null) //om spelaren håller i något
            {
                MoveObject();
                //om spelaren klickar på Mouse0 kastas objectet
                if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true)
                {
                    ThrowObject();
                }

            }
        }
        // om spelaren byter till ett vapen bör den tappa objectet
        if (emptyHand.gameObject.activeSelf == false)
        {
            if(heldObj != null)
            {
                DropObject();
            }
        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //objektet bör ha en ridgidbody
        {
            heldObj = pickUpObj; //sätter heald object rätt så att vi vet vad vi flyttar på
            heldObjRb = pickUpObj.transform.GetComponent<Rigidbody>();
            topObject = pickUpObj.transform.root;
            heldObjRb.isKinematic = true; //Stänger av ridgidbody
            topObject.transform.parent = holdPos.transform; //Flyttar objectet rätt
            heldObj.layer = LayerNumber; //byter layer så att den inte går igenom väggar

            //stänger av collidern med spelaren då det kan leda till dummheter
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);

            foreach (Transform child in heldObj.GetComponentsInChildren<Transform>(true)) //Gör samma ändringar för alla children (om det är en ragdoll t.ex)
            {
                child.gameObject.layer = LayerNumber;
                if (child.GetComponent<Collider>() != null)
                {
                    Physics.IgnoreCollision(child.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
                }
            }
        }
    }
    void DropObject()
    {
        //sätter på collision med spelaren igen
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; //sätter tillbaka objectet till 0
        heldObjRb.isKinematic = false;
        foreach (Transform child in heldObj.GetComponentsInChildren<Transform>(true))//gör detsamma för alla children
        {
            child.gameObject.layer = 0;
            if (child.GetComponent<Collider>() != null)
            {
                Physics.IgnoreCollision(child.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            }
        }
        topObject.transform.parent = null; //unparent objekt
        heldObj = null; //resettar heldObj

    }
    void MoveObject()
    {
        //håller kvar objektet 
        heldObj.transform.position = holdPos.transform.position;
    }
    void ThrowObject()
    {
        //Exact samma som Drop() men att man lägger till en force
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        foreach (Transform child in heldObj.GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.layer = 0;
        }
        topObject.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }
}
