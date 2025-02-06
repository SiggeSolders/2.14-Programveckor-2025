using UnityEngine;

public class chose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject WinScreen;

    private void Awake()
    {
        WinScreen.SetActive(false);
    }
    //tar fram game over screen
    public void faceTheDevil()
    {
        gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        Destroy(gameObject);
    }

    // tar fram winscreen
    public void Sacrafice()
    {
        WinScreen.SetActive(true);
        Destroy(gameObject);

    }
}
