using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Initializer _initializer;
    [SerializeField] private float _speed;
    [SerializeField] private float _mouseSens;

    private Rigidbody _rigidbody;
    private Camera _camera;

    private float _yRotation = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;

        _initializer.shootEvent.AddListener(OnShoot);
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
        _yRotation += _initializer.look.x;

        transform.rotation = Quaternion.Euler(0, _yRotation, 0).normalized;
    }

    private void OnShoot()
    {
        Debug.Log("Fire");
    }
}
