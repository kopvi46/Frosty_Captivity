using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Initializer _initializer;
    [SerializeField] private float _speed;
    [SerializeField] private float _mouseSens;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        OnMove();
        LookAtCursor();
    }

    private void OnMove()
    {
        float moveHorizontal = _initializer.move.x;
        float moveVertical = _initializer.move.y;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * _speed * Time.deltaTime;
        transform.position += movement;
    }

    private void LookAtCursor()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(cameraRay, out hit))
        {
            Vector3 cursorDirection = hit.point - transform.position;
            cursorDirection.y = 0f;

            if (cursorDirection.magnitude > 0.1f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(cursorDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _mouseSens * Time.deltaTime);
            }
        }
    }
}
