using UnityEngine;

public class DetectorScipt : MonoBehaviour
{
    public bool playerDetected;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }
}
