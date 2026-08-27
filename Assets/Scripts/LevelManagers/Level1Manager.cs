using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject DropAway;
    public GameObject DropAwayDetector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DropAwayDetector.GetComponent<DetectorScipt>().playerDetected == true){
            DropAway.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -7));
        }
    }
}
