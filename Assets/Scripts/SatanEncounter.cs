using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class SatanEncounter : MonoBehaviour
{
    [SerializeField] GameObject videoObject;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player;
    [SerializeField] GameObject stamminaBar;
    [SerializeField] PlayerCamera playerCamera_;
    [SerializeField] HeadBob headBob_;
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
    //När den nuddar spelaren stänger den av saker för att kunna spela videon utan att man kan röra på sig mm.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bC.enabled = false;
            videoObject.SetActive(true);
            videoPlayer.Play();
            player.SetActive(false);
            canvas.SetActive(false);
            stamminaBar.SetActive(false);
            headBob_.enabled = false;
            playerCamera_.enabled = false;
            StartCoroutine(Timer());
        }
    }

    //Sätter på allt igen
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(21.3f);
        Destroy(videoObject);
        player.SetActive(true);
        canvas.SetActive(true);
        stamminaBar.SetActive(true);
        playerCamera_.enabled = true;
        headBob_.enabled = true;
    }
}
