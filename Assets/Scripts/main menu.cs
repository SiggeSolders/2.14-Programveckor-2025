using UnityEngine;

public class mainmenu:MonoBehaviour
{
    [SerializeField] GameObject mainMenueUI;
    [SerializeField] PlayerCamera kamera;
    [SerializeField] PlayerMovement playermovement;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            
            if (mainMenueUI.active)
            {
                mainMenueUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                mainMenueUI.SetActive(false);
                playermovement.enabled = true;
                kamera.enabled = true;
            }else
            {
                mainMenueUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                mainMenueUI.SetActive(true);
                playermovement.enabled = false;
                kamera.enabled = false;
            }

        }



    }
    public void closeMenu()
    {
        mainMenueUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainMenueUI.SetActive(false);
        playermovement.enabled = true;
        kamera.enabled = true;
    }

}
