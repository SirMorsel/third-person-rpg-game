using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radiusToInteract = 3f;
    public Transform interactionPoint;

    bool isFocused = false;
    bool hasInteracted = false;
    Transform player;

    void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionPoint.position);
            if (distance <= radiusToInteract)
            {
                interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void interact()
    {
        Debug.Log("Interact with: " + transform.name);
    }

    public void onFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void onDefocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionPoint == null)
        {
            interactionPoint = transform;
        }
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(interactionPoint.position, radiusToInteract);

    }
}
