using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject volume;
    [SerializeField] GameObject mM;
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject ammo;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject returnButton;

    private void Awake()
    {
        volume.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
        mM.SetActive(false);
        ammo.SetActive(false);
        restartButton.SetActive(false);
        returnButton.SetActive(false);

        StartCoroutine(ShowButtonsAfterDelay());
    }
    private void Update()
    {

    }


    IEnumerator ShowButtonsAfterDelay()
    {
        // Wait for 22 seconds
        yield return new WaitForSeconds(22f);

        // Activate the buttons
        restartButton.SetActive(true);
        returnButton.SetActive(true);
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

