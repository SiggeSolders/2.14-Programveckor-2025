using UnityEngine;

public class chose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject mM;
    [SerializeField] GameObject goal1;
    [SerializeField] GameObject goal2;
    [SerializeField] GameObject ammo;

    private void Awake()
    {
        WinScreen.SetActive(false);
    }
    public void faceTheDevil()
    {
        gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        Destroy(gameObject);
    }
    public void Sacrafice()
    {
        WinScreen.SetActive(true);
        goal1.SetActive(false);
        goal2.SetActive(false);
        mM.SetActive(false);
        ammo.SetActive(false);
        Destroy(gameObject);

    }
}
