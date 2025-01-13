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

    void Start()
    {
        
        OptionsUI.SetActive(false);
        sensetivity.onValueChanged.AddListener((v) =>
        {
            sensetivitySliderText.text = "sensitivity (" + v.ToString("0")+")";
            sensetivityNumber = (int)v;
        });
        
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
    
}
