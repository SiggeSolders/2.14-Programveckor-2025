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
    int sensetivityNumber = 400;
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        
        OptionsUI.SetActive(false);
        sensetivity.onValueChanged.AddListener((v) =>
        {
            sensetivitySliderText.text = "sensitivity (" + v.ToString("0")+")";
            sensetivityNumber = (int)v;
        });
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            load();
        }
        else
        {
            load();
        }
        
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
        startScreanUI.SetActive(false);
        OptionsUI.SetActive(true);
    }
    public void Back()
    {
        OptionsUI.SetActive(false);
        startScreanUI.SetActive(true);
    }
    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }
    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    private void save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
