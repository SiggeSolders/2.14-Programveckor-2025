using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choosebuttons : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] chose chooseScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (chooseScript.isSatan)
        {
            StartCoroutine(ShowButtonsAfterDelaySoul());
        }
        else
        {
            StartCoroutine(ShowButtonsAfterDelayHillbilly());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    IEnumerator ShowButtonsAfterDelaySoul()
    {
        // v�ntar i 8.2 sekunder 
        yield return new WaitForSeconds(8.2f);

        // Aktiverar knapparna
        restartButton.SetActive(true);
        menuButton.SetActive(true);
    }
    IEnumerator ShowButtonsAfterDelayHillbilly()
    {
        // v�ntar i 8.2 sekunder 
        yield return new WaitForSeconds(9);

        // Aktiverar knapparna
        restartButton.SetActive(true);
        menuButton.SetActive(true);
    }
}
