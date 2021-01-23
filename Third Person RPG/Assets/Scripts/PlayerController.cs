using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public Interactable focus;
    Camera cam;
    PlayerMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                movement.moveToPoint(hit.point);
                removeFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
               Interactable interactableObject = hit.collider.GetComponent<Interactable>();
                if (interactableObject != null)
                {
                    setFocus(interactableObject);
                }
            }
        }
    }

    void setFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.onDefocused();
            }
            focus = newFocus;
            newFocus.onFocused(transform);
        }

        movement.followTarget(newFocus);
    }

    void removeFocus()
    {
        if (focus != null)
        {
            focus.onDefocused();
        }
        focus = null;
        movement.stopFollowingTarget();
    }
}
