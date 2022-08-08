using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderFoodController : MonoBehaviour
{
    public Image foodImage;

    public Image progressImage;
    public RectTransform progressRectTransform;

    public IEnumerator Progress(float _time)
    {
        Vector3 scale = progressRectTransform.localScale;
        float passedTime = 0f;

        while (passedTime < _time)
        {
            yield return null;

            passedTime += Time.deltaTime;

            scale.y = passedTime / _time;
            progressRectTransform.localScale = scale;
        }

        scale.y = 0f;
        progressRectTransform.localScale = scale;
    }
}
