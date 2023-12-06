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
    }

    private void OnMove()
    {

        Vector3 movement = new Vector3(_initializer.move.x, 0, _initializer.move.y) * _speed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + transform.TransformDirection(movement));
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
