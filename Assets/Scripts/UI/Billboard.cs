using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform _camera;

    void FixedUpdate()
    {
        transform.LookAt(transform.position + _camera.position);
    }
}
