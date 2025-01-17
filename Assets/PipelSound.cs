using UnityEngine;

public class PipelSound : MonoBehaviour
{
    [SerializeField] AudioSource Pipe;
    private void OnCollisionEnter(Collision collision)
    {
        if (Pipe.isPlaying)
        {
            return;
        }
        else
        {
            Pipe.Play();
        }
    }
}
