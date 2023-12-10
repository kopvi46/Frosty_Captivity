using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance;
    public float meleeEnemyMaxHealth;
    public float meleeEnemyHealth;

    [SerializeField] private Bars _bars;


    private void Start()
    {
        meleeEnemyHealth = meleeEnemyMaxHealth;
        _bars.SetMaxMeleeEnemyHealth(meleeEnemyMaxHealth);
    }
    void FixedUpdate()
    {
        if ( target != null )
        {
            distance = Vector3.Distance(transform.position, target.position);
        }
    }
}
