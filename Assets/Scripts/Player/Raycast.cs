using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Initializer initializer;
    public Interactable focus;

    private bool isAction;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        initializer.actionEvent.AddListener(CursorAt);
    }

    void FixedUpdate()
    {
        if (initializer.action && !isAction)
        {
            isAction = true;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

        if (initializer.move.x != 0 || initializer.move.y != 0)
        {
            RemoveFocus();
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
    private void CursorAt()
    {
        isAction = false;
    }
}
