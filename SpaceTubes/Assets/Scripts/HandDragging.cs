using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandDragging : MonoBehaviour, IManipulationHandler
{
    [SerializeField]
    float DragSpeed = 1.5f;

    [SerializeField]
    float DragScale = 1.5f;

    [SerializeField]
    float MaxDragDistance = 3f;
        
    Vector3 lastPosition;


    [SerializeField]
    bool draggingEnabled = true;
    public void SetDragging(bool enabled)
    {
        draggingEnabled = enabled;
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        InputManager.Instance.PushModalInputHandler(gameObject);
        lastPosition = transform.position;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        if (draggingEnabled)
        {         
            Drag(eventData.CumulativeDelta);
        }
    }

    public void disableDrag()
    {
        draggingEnabled = false;
    }

    public void enableDrag()
    {
        draggingEnabled = true;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
        
    }

    

    void Drag(Vector3 positon)
    {
        //modifie la position de l'objet en fonction de celle de notre main
        var targetPosition = lastPosition + positon * DragScale;
        if (Vector3.Distance(lastPosition, targetPosition) <= MaxDragDistance)
        {
            transform.parent.transform.position = Vector3.Lerp(transform.position, targetPosition, DragSpeed);
        }
    }
}
