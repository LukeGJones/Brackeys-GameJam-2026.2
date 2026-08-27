using System.Collections;
using UnityEngine;

public class Level7Manager : MonoBehaviour
{
    public GameObject SpikeWall;

    // Update is called once per frame
    void Update()
    {
        SpikeWall.transform.position = Vector2.MoveTowards(SpikeWall.transform.position, new Vector3(0.36f ,SpikeWall.transform.position.y, 0), Time.deltaTime * 6.8f);
    }
}
