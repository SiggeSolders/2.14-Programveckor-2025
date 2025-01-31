using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public static float sensitivityX;
    public static float sensitivityY;
    public GameObject startScreanUI;
    public GameObject OptionsUI;
    [SerializeField]private Slider sensetivity;
    [SerializeField] private TextMeshProUGUI sensetivitySliderText;
    int sensetivityNumber;
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        
        OptionsUI.SetActive(false);
        load();
        // makes volume 1 if nobody changed volume
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            load();
            
        }
        else
        {
            load();
        }
        //makes sensitivity 400 if nobody changed sensitivity
        if (!PlayerPrefs.HasKey("sensitivity"))
        {
            PlayerPrefs.SetFloat("sensitivity", 400);
            load();
            
        }
        else
        {
            load();
            
        }
        //sensetivitySliderText.text = "sensitivity (" + sensetivity.value + ")";
        //sensetivityNumber = (int)sensetivity.value;
        //sensetivity.onValueChanged.AddListener((v) =>
        //{
        //  sensetivitySliderText.text = "sensitivity (" + v.ToString("0") + ")";
        //sensetivityNumber = (int)v;
        //});

    }
    private void Update()
    {
        sensitivityX = sensetivityNumber;
        sensitivityY = sensetivityNumber;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void options()
    {
        // showes options ui and hides the other ui
        startScreanUI.SetActive(false);
        OptionsUI.SetActive(true);
    }
    public void Back()
    {
        // hides options ui and shoews the other ui
        OptionsUI.SetActive(false);
        startScreanUI.SetActive(true);
    }

    public void changeSensitivity()
    {
        //changes sensetivity and saves
        sensetivitySliderText.text = "sensitivity" + sensetivity.value + ")";
        sensetivityNumber = (int)sensetivity.value;
        save();
    }
    public void changeVolume()
    {

        AudioListener.volume = volumeSlider.value;
        save();
    }
    private void load()
    {
        //loads volume and sensetivity
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        sensetivity.value = PlayerPrefs.GetFloat("sensitivity");
    }
    private void save()
    {
        //saves volume and sensetivity
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.SetFloat("sensitivity", sensetivity.value);
        
    }
}
