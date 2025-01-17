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

    private void Awake()
    {
        volume.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
        mM.SetActive(false);
        ammo.SetActive(false);
    }
    private void Update()
    {

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
