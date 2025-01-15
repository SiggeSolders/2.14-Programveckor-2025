using UnityEngine;

public class Ammo : MonoBehaviour
{
    public void ShowAmmo(int currentAmmo)
    {
        int i = 0;
        foreach (Transform bullet in transform)
        {
            if (i <= currentAmmo)
            {
                bullet.gameObject.SetActive(true);
            }
            else
            {
                bullet.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
