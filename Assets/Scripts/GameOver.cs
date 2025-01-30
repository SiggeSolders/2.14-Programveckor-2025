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
        StartCoroutine(ShowButtonsAfterDelay());
    }
    private void Update()
    {

    }


    IEnumerator ShowButtonsAfterDelay()
    {
        // väntar i 22 sekunder
        yield return new WaitForSeconds(22f);

        // Aktiverar knapparna
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

