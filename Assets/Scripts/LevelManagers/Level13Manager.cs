using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Level13Manager : MonoBehaviour
{
    public GameObject Spikes;
    public GameObject SpikesDetector;
    public GameObject Floor1;
    public GameObject FloorDetector;
    public GameObject Platform;
    public GameObject PlatformDetector;
    public bool platformdropped = false;

    // Update is called once per frame
    void Update()
    {
        if(SpikesDetector.GetComponent<DetectorScipt>().playerDetected == true){
            Spikes.transform.position = Vector2.Lerp(Spikes.transform.position, new Vector3(Spikes.transform.position.x, -3.25f), 8f * Time.deltaTime);
        }
        if(FloorDetector.GetComponent<DetectorScipt>().playerDetected == true){
            Floor1.transform.position = Vector2.MoveTowards(Floor1.transform.position, new Vector3(-12f ,Floor1.transform.position.y), Time.deltaTime * 17f);
        }
        if(PlatformDetector.GetComponent<DetectorScipt>().playerDetected == true){
            StartCoroutine(PlatformDrop());
        }
    }

    public IEnumerator PlatformDrop()
    {
        if(platformdropped == false){
            Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, new Vector3(Platform.transform.position.x, -8.5f), Time.deltaTime * 17f);
            yield return new WaitForSeconds(1.5f);
            platformdropped = true;
        }
        if(platformdropped == true){
            Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, new Vector3(Platform.transform.position.x, -4f), Time.deltaTime * 7f);        
        }
    }
}
