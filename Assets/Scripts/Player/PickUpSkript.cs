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
    private bool canDrop = true; //F�r att droppa
    private int LayerNumber; //layer index
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("HoldLayer");
    }
    void Update()
    {
        //Om man inte h�ller i ett vapen och tittar p� n�got man kan plocka upp ska en pop-up s�ga att man kan plocka upp annars st�ngs den av
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

        //Om man inte h�ller i n�got, klickar p� E och tittar p� n�got som har taggen "CanPickUP ska objektet plockas upp
        if (emptyHand.gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (heldObj == null) //om man inte h�ller i n�got
                {
                    //en raycas f�r att se om det finns n�got att plocka upp
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
            if (heldObj != null) //om spelaren h�ller i n�got
            {
                MoveObject();
                //om spelaren klickar p� Mouse0 kastas objectet
                if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true)
                {
                    ThrowObject();
                }

            }
        }
        // om spelaren byter till ett vapen b�r den tappa objectet
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
        if (pickUpObj.GetComponent<Rigidbody>()) //objektet b�r ha en ridgidbody
        {
            heldObj = pickUpObj; //s�tter heald object r�tt s� att vi vet vad vi flyttar p�
            heldObjRb = pickUpObj.transform.GetComponent<Rigidbody>();
            topObject = pickUpObj.transform.root;
            heldObjRb.isKinematic = true; //St�nger av ridgidbody
            topObject.transform.parent = holdPos.transform; //Flyttar objectet r�tt
            heldObj.layer = LayerNumber; //byter layer s� att den inte g�r igenom v�ggar

            //st�nger av collidern med spelaren d� det kan leda till dummheter
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);

            foreach (Transform child in heldObj.GetComponentsInChildren<Transform>(true)) //G�r samma �ndringar f�r alla children (om det �r en ragdoll t.ex)
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
        //s�tter p� collision med spelaren igen
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; //s�tter tillbaka objectet till 0
        heldObjRb.isKinematic = false;
        foreach (Transform child in heldObj.GetComponentsInChildren<Transform>(true))//g�r detsamma f�r alla children
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
        //h�ller kvar objektet 
        heldObj.transform.position = holdPos.transform.position;
    }
    void ThrowObject()
    {
        //Exact samma som Drop() men att man l�gger till en force
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
