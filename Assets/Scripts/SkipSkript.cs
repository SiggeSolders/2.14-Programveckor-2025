using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipSkript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SkipCutscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
