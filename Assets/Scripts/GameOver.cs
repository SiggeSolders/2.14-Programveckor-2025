using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject returnButton;
    day_night dayNight;

    private void Awake()
    {
        if (dayNight.money)
        {
            StartCoroutine(ShowButtonsAfterDelayMoney());
        }
        else
        {
            StartCoroutine(ShowButtonsAfterDelaySoul());
        }

    }
    private void Update()
    {

    }


    IEnumerator ShowButtonsAfterDelayMoney()
    {
        // väntar i 22 sekunder
        yield return new WaitForSeconds(22f);

        // Aktiverar knapparna
        restartButton.SetActive(true);
        returnButton.SetActive(true);
    }
    IEnumerator ShowButtonsAfterDelaySoul()
    {
        // väntar i 22 sekunder
        yield return new WaitForSeconds(8.2f);

        // Aktiverar knapparna
        restartButton.SetActive(true);
        returnButton.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }


}

