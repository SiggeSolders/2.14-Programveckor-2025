using UnityEngine;

public class Shrine : MonoBehaviour
{
    GoalsScript goalScript;
    SellANimalFFS animalSell;

    private GameObject objectToSell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalScript = FindObjectOfType<GoalsScript>();
        animalSell = FindObjectOfType<SellANimalFFS>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deer" || other.gameObject.tag == "Sheep")
        {
            if (other.gameObject.tag == "Deer")
            {
                objectToSell = GameObject.Find("holdPos/Deer");
                Destroy(objectToSell.gameObject);
                goalScript.souls++;
            }
            if (other.gameObject.tag == "Sheep")
            {
                objectToSell = GameObject.Find("holdPos/Sheep");
                Destroy(objectToSell.gameObject);
                goalScript.souls++;
            }

        }
    }
}
