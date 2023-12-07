using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    [SerializeField] private Initializer _initializer;
    public Gun _gun;

    private void Awake()
    {
        _initializer.shootEvent.AddListener(OnShoot);
    }

    private void OnShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_gun.transform.position, _gun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //Why dont work???
            //if (hit.rigidbody != null)
            //{
            //    hit.rigidbody.AddForce(-hit.normal * target.damageForcePush);
            //}
        }
    }
}
