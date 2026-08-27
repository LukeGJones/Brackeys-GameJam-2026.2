using System.Collections;
using UnityEngine;

public class Level9Manager : MonoBehaviour
{
    public GameObject PlatformBlock1;
    public GameObject PlatformBlock2;
    public GameObject PlatformBlock3;
    public GameObject PlatformBlock4;
    public GameObject PlatformBlock5;
    public GameObject Detector1;
    public GameObject Detector2;
    public GameObject Detector3;

    // Update is called once per frame
    void Update()
    {  
        if(Detector1.GetComponent<DetectorScipt>().playerDetected == true){
            StartCoroutine(BlocksFalling());  
        }
        if(Detector2.GetComponent<DetectorScipt>().playerDetected == true){
            StartCoroutine(Plat4Rise());
        }
        if(Detector3.GetComponent<DetectorScipt>().playerDetected == true){ 
            PlatformBlock5.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; 
        }
    }

    public IEnumerator BlocksFalling()
    {
        yield return new WaitForSeconds(0.5f);
        PlatformBlock1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(0.5f);
        PlatformBlock2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;  
        yield return new WaitForSeconds(0.5f);
        PlatformBlock3.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;     
    }

    public IEnumerator Plat4Rise()
    {
        yield return new WaitForSeconds(2f);
        PlatformBlock4.transform.position = Vector2.MoveTowards(PlatformBlock4.transform.position, new Vector3(PlatformBlock4.transform.position.x, -1f), Time.deltaTime * 4f);
    }
}
