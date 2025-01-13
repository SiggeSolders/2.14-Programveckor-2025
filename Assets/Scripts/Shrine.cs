using UnityEngine;

public class Shrine : MonoBehaviour
{
    GoalsScript goalScript;
    SellANimalFFS animalSell;
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
        if(other.gameObject.tag == "Animal" || other.gameObject.tag == "Deer")
        {
            other.transform.parent.gameObject.SetActive(false);
            Destroy(other.gameObject);
            goalScript.souls++;
        }
    }
}
