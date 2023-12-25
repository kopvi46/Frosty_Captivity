using System.Collections;
using UnityEngine;

public class FireplaceMainCore : MonoBehaviour
{
    #region Singleton 
    public static FireplaceMainCore instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of FireplaceMainCore found!");
        }
        instance = this;
    }
    #endregion

    public Transform player;
    public float fireplaceMaxHealth;
    public float fireplaceHealth;
    public float fireplaceBurn;
    public float fireplaceBurnInterval;
    public float distance;
    public Coroutine fireplaceBurnCoroutine;

    [SerializeField] private Bars _bars;

    private void Start()
    {
        fireplaceHealth = fireplaceMaxHealth;
        _bars.SetFireplaceHealth(fireplaceMaxHealth);
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            distance = Vector3.Distance(transform.position, player.position);
        }
        if (fireplaceHealth > 0)
        {
            if( fireplaceBurnCoroutine == null )
            {
                fireplaceBurnCoroutine = StartCoroutine(ApplyFireplaceBurn());
            }
        } else
        {
            if (fireplaceBurnCoroutine != null)
            {
                StopCoroutine(fireplaceBurnCoroutine);
                fireplaceBurnCoroutine = null;
            }
        }
    }

    private IEnumerator ApplyFireplaceBurn()
    {
        while (fireplaceHealth > 0)
        {
            fireplaceHealth -= fireplaceBurn;
            _bars.SetFireplaceHealth(fireplaceHealth);
            yield return new WaitForSeconds(fireplaceBurnInterval);
        }
    }
}
