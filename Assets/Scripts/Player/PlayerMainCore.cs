using System.Collections;
using UnityEngine;

public class PlayerMainCore : MonoBehaviour
{
    public float playerHealth;
    public float freezeDamage;
    public float freezeDamageInterval;
    [SerializeField] private FireplaceMainCore _fireplaceMainCore;
    [SerializeField] private TorchMainCore _torchMainCore;

    private Coroutine freezeDamageCoroutine;

    private void FixedUpdate()
    {
        if ( _fireplaceMainCore != null)
        {
            if (_fireplaceMainCore.distance > 20 && _torchMainCore.torchHealth <= 0)
            {
                if (freezeDamageCoroutine == null)
                {
                    freezeDamageCoroutine = StartCoroutine(ApplyFreezeDamage());
                }
            }
            else
            {
                if (freezeDamageCoroutine != null)
                {
                    StopCoroutine(freezeDamageCoroutine);
                    freezeDamageCoroutine = null;
                }
            }
        }

        Debug.Log("Player health:" + playerHealth);
    }

    private IEnumerator ApplyFreezeDamage()
    {
        while (playerHealth > 0)
        {
            playerHealth -= freezeDamage;
            yield return new WaitForSeconds(freezeDamageInterval);
        }
    }
}
