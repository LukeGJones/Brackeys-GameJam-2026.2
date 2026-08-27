using System.Collections;
using UnityEngine;

public class Level5Manager : MonoBehaviour
{
    public GameObject SpikeWall;

    // Update is called once per frame
    void Update()
    {
        SpikeWall.transform.position = Vector2.MoveTowards(SpikeWall.transform.position, new Vector3(25f ,SpikeWall.transform.position.y), Time.deltaTime * 6.8f);
    }
}
