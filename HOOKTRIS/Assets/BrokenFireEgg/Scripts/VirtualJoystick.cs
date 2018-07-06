using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image bgimg;
    private Image joystickimg;
    private Vector3 inputVector;

    private void Start()
    {
        bgimg = GetComponent<Image>();
        joystickimg = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgimg.rectTransform,
            ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgimg.rectTransform.sizeDelta.x );
            pos.y = (pos.y / bgimg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            Debug.Log(inputVector);

            joystickimg.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (bgimg.rectTransform.sizeDelta.x / 2)
                            , inputVector.z * (bgimg.rectTransform.sizeDelta.y / 2));
        }

    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {

    }

}
