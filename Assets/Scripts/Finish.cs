using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Finish : MonoBehaviour
{
    public bool reachedGoal;
    public static int furthestLevel = 1;
    public GameObject levelCompleteBars;
    public GameObject levelManager;
    void Start()
    {
        levelManager.SetActive(false);
        for(int i = 0; i < 6; i++){
            Transform bar = levelCompleteBars.transform.GetChild(i);
            StartCoroutine(bar.GetComponent<LoadingBars>().LevelLoadAnim(i));
        }
        StartCoroutine(StartLevel());
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<player>().enabled = false;
            if(SceneManager.GetActiveScene().name == "14")
            {
                collision.GetComponent<player>().isDead = true;
                furthestLevel = -1;
            }
            furthestLevel += 1;
            reachedGoal = true;
            for(int i = 0; i < 6; i++){
                Transform bar = levelCompleteBars.transform.GetChild(i);
                StartCoroutine(bar.GetComponent<LoadingBars>().LevelOverAnim(i));
            }
            StartCoroutine(WaitPointFive());
        }
    }

    public IEnumerator WaitPointFive()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(furthestLevel.ToString());
    }

    public IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(0.5f);
        levelManager.SetActive(true);
    }
}
