using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Har scenen aktiv i 16.3 sekunder för att visa introt innan den byter till spelet.
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(16.3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
