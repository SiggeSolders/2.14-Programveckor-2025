using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamminaBar : MonoBehaviour
{
    private StamminaControler _stamminaController;
    private Image StamminaBar;
    // Start is called before the first frame update
    void Start()
    {
        _stamminaController = FindObjectOfType<StamminaControler>();
        StamminaBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        StamminaBar.fillAmount = _stamminaController.playerStammina / _stamminaController.maxStammina;
    }
}
