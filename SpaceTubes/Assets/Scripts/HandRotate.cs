using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class HandRotate : MonoBehaviour, IManipulationHandler
{
    [SerializeField]
    float RotationDist = 0.07f;

    Vector3 lastRotation;
    Vector3 newRotation;

    [SerializeField]
    bool rotatingEnabled = true;
    public void SetRotating(bool enabled)
    {
        rotatingEnabled = enabled;
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        InputManager.Instance.PushModalInputHandler(gameObject);
        lastRotation = new Vector3(0, 0, 0);
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        if (rotatingEnabled)
        {
           
            float x=0;
            float y=0;
            float z=0;

            
            //check si la distance parcourue par la main est plus grande que la distance nécessaire a une rotattion
            //si c'est le cas on effectue une rotation de 90 degrés sur l'axe demandé
            if(Mathf.Abs(eventData.CumulativeDelta.x)> RotationDist)
            {  
                y=Mathf.Sign(eventData.CumulativeDelta.y) * 90;
            }

            if (Mathf.Abs(eventData.CumulativeDelta.y) > RotationDist)
            {
                if(Camera.main.transform.forward.x>Camera.main.transform.forward.y)
                {
                    x = Mathf.Sign(eventData.CumulativeDelta.y) * 90;
                }
                else
                {
                    z= Mathf.Sign(eventData.CumulativeDelta.y) * 90;
                }
                
            }

            if (Mathf.Abs(eventData.CumulativeDelta.z) > RotationDist)
            {
                y = Mathf.Sign(eventData.CumulativeDelta.y) * 90;
            }

            newRotation = new Vector3(x, y, z);

            if (lastRotation != newRotation)
            {
                Rotate(newRotation);
                lastRotation = newRotation;
            }
            

           
        }
    }

    public void disableRot()
    {
        rotatingEnabled = false;
    }

    public void enableRot()
    {
        rotatingEnabled = true;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
    }
        
    void Rotate(Vector3 rotation)
    {
        transform.parent.transform.Rotate(rotation);
    }
}
