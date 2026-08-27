using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class KillZone : MonoBehaviour
{
    public GameObject levelCompleteBars;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<player>().isDead = true;
            for(int i = 0; i < 6; i++){
                Transform bar = levelCompleteBars.transform.GetChild(i);
                StartCoroutine(bar.GetComponent<LoadingBars>().LevelOverAnim(i));
                StartCoroutine(WaitPointFive());
            }
        }
    }
    public IEnumerator WaitPointFive()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
