using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOver : MonoBehaviour
{
    [SerializeField] VideoPlayer vP;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject returnButton;

    private void Start()
    {
        if(gameObject.tag == "Win")
        {
            restartButton.SetActive(false);
            returnButton.SetActive(false);
        }
    }
    private void Update()
    {
        if(gameObject.tag == "Win")
        {
            if(vP.isPlaying == false)
            {
                restartButton.SetActive(true);
                returnButton.SetActive(true);
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    
}
