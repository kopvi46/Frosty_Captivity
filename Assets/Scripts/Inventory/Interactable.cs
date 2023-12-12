using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;
    //public Initializer initializer;
    private bool isAction;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        //initializer.actionEvent.AddListener(CursorAt);
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void FixedUpdate()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
        //if (initializer.action && !isAction)
        //{
        //    isAction = true;
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Debug.Log("We hit " + hit.collider.name);
        //    }
        //}
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    //private void CursorAt()
    //{
    //    isAction = false;
    //} 
}