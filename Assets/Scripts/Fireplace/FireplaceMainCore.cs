using System.Collections;
using UnityEngine;

public class FireplaceMainCore : MonoBehaviour
{
    public Transform player;
    public float fireplaceHealth;
    public float fireplaceBurn;
    public float fireplaceBurnInterval;
    public float distance;

    private Coroutine fireplaceBurnCoroutine;

    private void FixedUpdate()
    {
        if (player != null)
        {
            distance = Vector3.Distance(transform.position, player.position);
        }
        if (fireplaceHealth > 0)
        {
            if( fireplaceBurnCoroutine != null )
            {
                fireplaceBurnCoroutine = StartCoroutine(ApplyFireplaceBurn());
            }
        }
        else
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
            yield return new WaitForSeconds(fireplaceBurnInterval);
        }
    }
}
