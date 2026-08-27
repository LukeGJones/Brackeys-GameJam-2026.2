using System.Collections;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public GameObject Floors;
    public GameObject Detector;

    // Update is called once per frame
    void Update()
    {
        if(Detector.GetComponent<DetectorScipt>().playerDetected == true){
            Floors.transform.position = Vector2.MoveTowards(Floors.transform.position, new Vector3(-7f ,Floors.transform.position.y), Time.deltaTime * 17f);
        }
    }
}
