using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOverButtonHandler : MonoBehaviour, IPointerEnterHandler
{
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => AudioManager.Instance.PlayClip("HighLight");

}
