using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text title;

    public void OnPointerEnter(PointerEventData eventData)
    {
        title.faceColor = new Color(0.6196f, 0.0313f, 0.0314f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        title.faceColor = new Color(0.7216f, 0.6941f, 0.6941f, 1f);
    }
}

