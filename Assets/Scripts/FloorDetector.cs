using UnityEngine;

public class FloorDetector : MonoBehaviour
{
    public bool isGrounded;
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
