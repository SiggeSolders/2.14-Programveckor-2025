using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    private CanvasGroup canvasGroup;
    private Gun gun_;

    private bool previousState;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        gun_ = Gun.GetComponent<Gun>();
        // Spara det ursprungliga tillst�ndet av parent-object
        previousState = Gun.transform.parent.gameObject.activeSelf;

        // S�tt Ammo-objektets tillst�nd baserat p� parent
        //gameObject.SetActive(previousState);
    }

    private void Update()
    {
        // Kontrollera endast om parentens tillst�nd har �ndrats
        bool currentState = Gun.transform.parent.gameObject.activeSelf;
        if(currentState == true)
        {
            canvasGroup.alpha = 1;
        }
        else
        {
            canvasGroup.alpha = 0;
        }
        ShowAmmo(gun_.currentAmmo);
    }

    public void ShowAmmo(int currentAmmo)
    {
        int i = 0;
        foreach (Transform bullet in transform)
        {
            bullet.gameObject.SetActive(i < currentAmmo);
            i++;
        }
    }
}
