using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class SatanEncounter : MonoBehaviour
{
    [SerializeField] GameObject videoObject;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player;
    BoxCollider bC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bC = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bC.enabled = false;
            videoObject.SetActive(true);
            videoPlayer.Play();
            player.SetActive(false);
            canvas.SetActive(false);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(21.3f);
        Destroy(videoObject);
        player.SetActive(true);
        canvas.SetActive(true);
    }
}
