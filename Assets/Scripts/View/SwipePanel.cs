using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SwipePanel : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    void Start()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Events.Swipe_Call(eventData.delta.x);
    }
}
