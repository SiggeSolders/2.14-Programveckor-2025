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
    [SerializeField] GameObject globalVolume;
    day_night dayNight;

    private void Awake()
    {
        dayNight = FindAnyObjectByType<day_night>();
        StartCoroutine(Debug());
        globalVolume.SetActive(false);

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
        // v�ntar i 8.2 sekunder 
        yield return new WaitForSeconds(8.2f);

        // Aktiverar knapparna
        restartButton.SetActive(true);
        returnButton.SetActive(true);
    }

    //av n�gon anledning ville skiten inte funka innan jag lade till en liten delay. Det funkar nu.
    IEnumerator Debug()
    {
        yield return new WaitForSeconds(0.2f);

        //Spelar r�tt video beroende p� vad man f�rlorade av. Mycket buggar. D�rf�r lade jag till att den st�nger av den andra videon
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

