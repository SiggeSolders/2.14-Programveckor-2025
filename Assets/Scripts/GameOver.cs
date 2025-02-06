using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject returnButton;
    [SerializeField] VideoPlayer money;
    [SerializeField] VideoPlayer souls;
    day_night dayNight;

    private void Awake()
    {
        dayNight = FindAnyObjectByType<day_night>();
        StartCoroutine(Debug());

    }
    private void Update()
    {
        print(dayNight.money);
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
    IEnumerator Debug()
    {
        yield return new WaitForSeconds(0.2f);
        if (dayNight.money == true)
        {
            print("CASH");
            money.Play();
            souls.Stop();
            StartCoroutine(ShowButtonsAfterDelayMoney());
        }
        if (dayNight.money == false)
        {
            print("slous");
            souls.Play();
            money.Stop();
            StartCoroutine(ShowButtonsAfterDelaySoul());
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


}

