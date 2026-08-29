using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public GameObject Spikes;
    public GameObject SpikesDetector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SpikesDetector.GetComponent<DetectorScipt>().playerDetected == true){
            Spikes.transform.position = Vector2.Lerp(Spikes.transform.position, new Vector3(Spikes.transform.position.x, -3.25f), 8f * Time.deltaTime);
        }
    }
}
