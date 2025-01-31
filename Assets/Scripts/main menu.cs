using UnityEngine;

public class mainmenu:MonoBehaviour
{
    [SerializeField] GameObject mainMenueUI;
    [SerializeField] PlayerCamera kamera;
    [SerializeField] PlayerMovement playermovement;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (mainMenueUI.active == false)
            {
                mainMenueUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                mainMenueUI.SetActive(true);
                playermovement.enabled = false;
                kamera.enabled = false;
            }
            
            if (mainMenueUI.active == true)
            {
                mainMenueUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                mainMenueUI.SetActive(false);
                playermovement.enabled = true;
                kamera.enabled = true;
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
