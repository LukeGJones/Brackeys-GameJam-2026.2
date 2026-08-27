using System.Collections;
using UnityEngine;

public class Level6Manager : MonoBehaviour
{
    public GameObject Spikes;
    public GameObject SpikeWall;
    public GameObject SpikesDetector;
    public bool spikeSequenceDone = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpikeWall.transform.position = Vector2.MoveTowards(SpikeWall.transform.position, new Vector3(14.5f ,SpikeWall.transform.position.y), Time.deltaTime * 6.8f);
        if(SpikesDetector.GetComponent<DetectorScipt>().playerDetected == true && spikeSequenceDone == false){
            StartCoroutine(SpikeSequence());
        }
    }

    public IEnumerator SpikeSequence()
    {
        Spikes.transform.position = Vector2.MoveTowards(Spikes.transform.position, new Vector3(Spikes.transform.position.x, -3.25f), Time.deltaTime * 20f);
        yield return new WaitForSeconds(2);
        Spikes.transform.position = Vector2.MoveTowards(Spikes.transform.position, new Vector3(Spikes.transform.position.x, -5.45f), Time.deltaTime * 20f);
        spikeSequenceDone = true;
    }
}
