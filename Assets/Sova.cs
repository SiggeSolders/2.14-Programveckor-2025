using Unity.VisualScripting;
using UnityEngine;

public class Sova : MonoBehaviour
{
    public day_night day_Night_;
    private float range = 100f;
    [SerializeField] GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("E");
            //en raycas för att se om det finns något att plocka upp
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
            {
                print("hit");
                //make sure pickup tag is attached
                if (hit.transform.gameObject.tag == "Bed")
                {
                    print("Säng");
                    HandleSleep();
                }
            }
        }
    }
    private void HandleSleep()
    {
        day_Night_.totalRotation = 360f;
    }
}
