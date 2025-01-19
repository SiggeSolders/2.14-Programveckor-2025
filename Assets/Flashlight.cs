using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private new Light light;

    private void Start()
    {
        
        light = GetComponentInChildren<Light>();
        light.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!light.enabled)
            {
                light.enabled = true;
            }else if (light.enabled)
            {
                light.enabled = false;
            }
        }
    }
}
