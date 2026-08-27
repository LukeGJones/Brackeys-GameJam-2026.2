using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBars : MonoBehaviour
{
    public Finish finishScript;
    private RectTransform rectTransform;
    private Image image;

    void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public IEnumerator LevelOverAnim(int index)
    {
        image.enabled = true;
        float duration = 0.5f;
        float elapsed = 0f;

        Vector2 startPosition = new Vector2(-849f - (141.6f * index), rectTransform.anchoredPosition.y);
        rectTransform.anchoredPosition = startPosition;
        Vector2 endPosition = new Vector2(0f, startPosition.y);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        rectTransform.anchoredPosition = endPosition;
    }

    public IEnumerator LevelLoadAnim(int index)
    {
        image.enabled = true;
        float duration = 0.5f;
        float elapsed = 0f;

        Vector2 startPosition = new Vector2(0f, rectTransform.anchoredPosition.y);
        Vector2 endPosition = new Vector2(-849f - (141.6f * (5 - index)), startPosition.y);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        rectTransform.anchoredPosition = endPosition;
    }
}
