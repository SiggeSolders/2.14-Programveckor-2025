using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu:MonoBehaviour
{
    [SerializeField] GameObject mainMenueUI;
    [SerializeField] PlayerCamera kamera;
    [SerializeField] PlayerMovement playermovement;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            //opens menu on escape and frezes movment
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
                //closes menu on escape and Unfrezes movment
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
        //close menu and unfreze movment on button click
        mainMenueUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainMenueUI.SetActive(false);
        playermovement.enabled = true;
        kamera.enabled = true;
    }
    public void backToMainMenu()
    {
        //goes back to start screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

}
