using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public Transform _target;
    public float _speed;
    public float _distance;

    void FixedUpdate()
    {
        if ( _target != null )
        {
            _distance = Vector3.Distance(transform.position, _target.position);
        }
    }
}
