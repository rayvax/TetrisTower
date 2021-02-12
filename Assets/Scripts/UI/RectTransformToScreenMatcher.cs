using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class RectTransformToScreenMatcher : MonoBehaviour
{
    [SerializeField] private bool _keepConstScale = false;

    private void Awake()
    {
        var rectTransform = GetComponent<RectTransform>();

        Vector2 defaultRectSize = rectTransform.sizeDelta;
        Vector2 matchingScreenRectSize = new Vector2(Screen.width, Screen.height);

        rectTransform.sizeDelta = matchingScreenRectSize;
        if(!_keepConstScale)
        {
            float localScaleMultiplier = defaultRectSize.y / matchingScreenRectSize.y;
            rectTransform.localScale *= localScaleMultiplier;
        }
    }
}
