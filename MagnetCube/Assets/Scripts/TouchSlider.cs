using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TouchSlider : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public UnityAction OnPointerDownAction;
    public UnityAction OnPointerUpAction; 
    public UnityAction<float> OnPointerDragAction;
    private Slider uiSlider;
    private void Awake()
    {
        uiSlider = GetComponent<Slider>();
        uiSlider.onValueChanged.AddListener(OnPointerDrag);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(OnPointerDownAction!=null)
            OnPointerDownAction.Invoke();

        if (OnPointerDragAction != null)
            OnPointerDragAction.Invoke(uiSlider.value);
    }
    private void OnPointerDrag(float value)
    {
        if (OnPointerDragAction != null)
            OnPointerDragAction.Invoke(value);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpAction != null)
            OnPointerUpAction.Invoke();

        uiSlider.value = 0f;
    }

    private void OnDestroy()
    {
        uiSlider.onValueChanged.RemoveListener(OnPointerDrag);
    }


}
