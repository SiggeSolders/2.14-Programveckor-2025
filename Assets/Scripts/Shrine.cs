using UnityEngine;

public class Shrine : MonoBehaviour
{
    GoalsScript goalScript;

    private GameObject objectToSell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalScript = FindObjectOfType<GoalsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Kollar om det är ett djur och offrar det och ökar själar
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deer" || other.gameObject.tag == "Sheep" || other.gameObject.tag == "Wolf")
        {
            if (other.gameObject.tag == "Deer")
            {
                objectToSell = GameObject.Find("holdPos/Deer(Clone)");
                Destroy(objectToSell.gameObject);
                goalScript.souls++;
            }
            if (other.gameObject.tag == "Sheep")
            {
                objectToSell = GameObject.Find("holdPos/Sheep(Clone)");
                Destroy(objectToSell.gameObject);
                goalScript.souls++;
            }
            if (other.gameObject.tag == "Wolf")
            {
                objectToSell = GameObject.Find("holdPos/Wolf(Clone)");
                Destroy(objectToSell.gameObject);
                goalScript.souls++;
            }

        }
    }
}
