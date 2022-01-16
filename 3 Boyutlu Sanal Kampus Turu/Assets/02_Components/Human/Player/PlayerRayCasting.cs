using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour
{
    private IInteractable currentTarget;
    [SerializeField] private float maxDistance=10000f;


    private void Awake()
    {
        
    }
    private void Update()
    {
        if(GameState.Instance.curState==States.Player)
        {
            RaycastForInteractable();

            if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
            {
                currentTarget.OnInteract();
            }
        }
       
    }

    private void RaycastForInteractable()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position+new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward),out hit,maxDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward)*hit.distance,Color.black);
            if (interactable != null)
            {
                if (hit.distance <= interactable.MaxRange)
                {
                    if (interactable == currentTarget)
                    {
                        return;
                    }
                    else if (currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                }
                else

                if (currentTarget != null)
                {
                    currentTarget.OnEndHover();
                    currentTarget = null;
                    return;
                }

            }
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.OnEndHover();
                    currentTarget = null;
                    return;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnEndHover();
                currentTarget = null;
                return;
            }

        }
    }
}
