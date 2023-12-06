using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Initializer : MonoBehaviour
{
    public UnityEvent shootEvent = new();
    public Vector2 move;
    public Vector2 look;
    public bool shoot;

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
}
