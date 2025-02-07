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
    [SerializeField] GameObject player;
    [SerializeField] GameObject stamminaBar;
    [SerializeField] PlayerCamera playerCamera_;
    [SerializeField] HeadBob headBob_;
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
        // v�ntar i 22 sekunder
        yield return new WaitForSeconds(22f);

        // Aktiverar knapparna
        restartButton.SetActive(true);
        returnButton.SetActive(true);
    }
    IEnumerator ShowButtonsAfterDelaySoul()
    {
        // v�ntar i 22 sekunder
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
            player.SetActive(false);
            stamminaBar.SetActive(false);
            headBob_.enabled = false;
            playerCamera_.enabled = false;
            print("CASH");
            money.Play();
            souls.Stop();
            StartCoroutine(ShowButtonsAfterDelayMoney());
        }
        if (dayNight.money == false)
        {
            player.SetActive(false);
            stamminaBar.SetActive(false);
            headBob_.enabled = false;
            playerCamera_.enabled = false;
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

