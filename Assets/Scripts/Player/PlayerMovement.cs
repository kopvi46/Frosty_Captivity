using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Initializer _initializer;
    [SerializeField] private float _speed;
    [SerializeField] private float _mouseSens;

    private Rigidbody _rigidbody;

    private float _yRotation = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
                 
    void FixedUpdate()
    {
        OnMove();
        OnLook();
    }

    private void OnMove()
    {
        float moveHorizontal = _initializer.move.x;
        float moveVertical = _initializer.move.y;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * _speed * Time.deltaTime;
        _rigidbody.AddForce(transform.TransformDirection(movement), ForceMode.VelocityChange);
    }
private void OnLook()
    {
        if (_initializer.look.x != 0)
        {
            _yRotation += _initializer.look.x;
            transform.rotation = Quaternion.Euler(0, _yRotation, 0).normalized;
        }
    }
    
}
