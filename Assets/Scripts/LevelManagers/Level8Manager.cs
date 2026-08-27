using System.Collections;
using UnityEngine;

public class Level8Manager : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlatformBlock1;
    public GameObject PlatformBlocks;
    public GameObject PlatformBlock3;
    public GameObject Detector1;
    public GameObject Detector2;
    public GameObject Detector3;

    // Update is called once per frame
    void Update()
    {  
        if(Detector3.GetComponent<DetectorScipt>().playerDetected == true){ 
            Player.transform.parent = PlatformBlocks.transform;
            PlatformBlocks.transform.position = Vector2.MoveTowards(PlatformBlocks.transform.position, new Vector3(14.73f,PlatformBlocks.transform.position.y), Time.deltaTime * 4f);
        }
        if(Detector1.GetComponent<DetectorScipt>().playerDetected == true){
            PlatformBlock1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;         
        }
        if(Detector2.GetComponent<DetectorScipt>().playerDetected == true){
            PlatformBlock3.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;    
        }
    }
}
