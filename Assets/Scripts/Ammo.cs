using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    private CanvasGroup canvasGroup;
    private Gun gun_; //Vapnet vars skott man h�mtar

    private bool previousState;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        gun_ = Gun.GetComponent<Gun>();
        // Spara det ursprungliga tillst�ndet av parent-object
        previousState = Gun.transform.parent.gameObject.activeSelf;
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
        //Anv�der antalet skott kvar f�r att r�kna ut hur m�nga skott som ska visas
        int i = 0;
        foreach (Transform bullet in transform)
        {
            bullet.gameObject.SetActive(i < currentAmmo);
            i++;
        }
    }
}
