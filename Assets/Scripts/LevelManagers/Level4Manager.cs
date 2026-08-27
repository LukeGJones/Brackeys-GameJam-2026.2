using System.Collections;
using UnityEngine;

public class Level4Manager : MonoBehaviour
{
    public GameObject Spikes1;
    public GameObject Spikes2;
    public GameObject SpikesDetector1;
    public GameObject SpikesDetector2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(SpikesDetector1.GetComponent<DetectorScipt>().playerDetected == true){
            Spikes1.transform.position = Vector2.MoveTowards(Spikes1.transform.position, new Vector3(-3.5f,Spikes1.transform.position.y), Time.deltaTime * 10f);
        }
        if(SpikesDetector2.GetComponent<DetectorScipt>().playerDetected == true){
            Spikes2.transform.position = Vector2.MoveTowards(Spikes2.transform.position, new Vector3(7.5f,Spikes2.transform.position.y), Time.deltaTime * 10f);
        }
    }

}
