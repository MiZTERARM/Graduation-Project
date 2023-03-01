using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform Button;
    void Start()
    {
        Button.GetComponent<Animator>().Play("Hover Off");
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("Hover On");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("Hover Off");
    }

}
