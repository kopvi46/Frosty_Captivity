using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Initializer : MonoBehaviour
{
    public UnityEvent shootEvent = new();
    public UnityEvent actionEvent = new();
    public UnityEvent escapeEvent = new();
    public Vector2 move;
    public Vector2 look;
    public bool shoot;
    public bool action;
    public bool escape;

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }
    public void OnShoot(InputValue value)
    {
        shoot = value.isPressed;
        shootEvent?.Invoke();
    }
    public void OnAction(InputValue value)
    {
        action = value.isPressed;
        actionEvent?.Invoke();
    }

    public void OnEscape(InputValue value)
    {
        escape = value.isPressed;
        escapeEvent?.Invoke();
    }
}
