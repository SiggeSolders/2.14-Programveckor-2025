using System.Collections;
using UnityEngine;

public class PipelSound : MonoBehaviour
{
    [SerializeField] AudioSource Pipe;

    private void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        Pipe.volume = 0;
        yield return new WaitForSeconds(3);
        Pipe.volume = 0.5f;
    }
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
