using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    
    public GameObject startScreanUI;
    public GameObject OptionsUI;
    [SerializeField]private Slider sensetivity;
    [SerializeField] private TextMeshProUGUI sensetivitySliderText;

    void Start()
    {
        OptionsUI.SetActive(false);
        sensetivity.onValueChanged.AddListener((v) =>
        {
            sensetivitySliderText.text = "sensitivity (" + v.ToString("0")+")";
        });
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
