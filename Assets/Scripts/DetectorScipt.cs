using UnityEngine;

public class DetectorScipt : MonoBehaviour
{
    public bool playerDetected;
    private bool audioPlayed;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = true;
            if(audioPlayed == false){
                audioSource.PlayOneShot(audioSource.clip, ButtonManager.sfxVolume);
                audioPlayed = true;
            }
        }
    }
}
