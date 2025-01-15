using UnityEngine;

public class chose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject ChoseScreen;
    public void faceTheDevil()
    {
        ChoseScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
    public void Sacrafice()
    {
        ChoseScreen.SetActive(false);
        
    }
}
