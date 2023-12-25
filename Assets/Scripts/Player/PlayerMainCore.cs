using System.Collections;
using UnityEngine;

public class PlayerMainCore : MonoBehaviour
{
    #region Singleton 
    public static PlayerMainCore instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of FireplaceMainCore found!");
        }
        instance = this;
    }
    #endregion

    public float playerHealth;
    public float playerMaxHealth;
    public float freezeDamage;
    public float freezeDamageInterval;
    [SerializeField] private FireplaceMainCore _fireplaceMainCore;
    [SerializeField] private TorchMainCore _torchMainCore;
    [SerializeField] private Bars _bars;

    public Coroutine freezeDamageCoroutine;
    public Coroutine warmHealCoroutine;

    private void Start()
    {
        playerHealth = playerMaxHealth;
        _bars.SetMaxPlayerHealth(playerMaxHealth);
    }
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

            if (_fireplaceMainCore.distance < 20)
            {
                if (warmHealCoroutine == null)
                {
                    warmHealCoroutine = StartCoroutine(ApplyWarmHeal());
                }
            } else
            {
                if (warmHealCoroutine != null)
                {
                    StopCoroutine(warmHealCoroutine);
                    warmHealCoroutine = null;
                }
            }
        }
    }

    private IEnumerator ApplyFreezeDamage()
    {
        while (playerHealth > 0)
        {
            //Debug.Log("Player health:" + playerHealth);
            playerHealth -= freezeDamage;
            _bars.SetPlayerHealth(playerHealth);
            yield return new WaitForSeconds(freezeDamageInterval);
        }
    }
    private IEnumerator ApplyWarmHeal()
    {
        while (playerHealth < 100)
        {
            playerHealth += freezeDamage;
            _bars.SetPlayerHealth(playerHealth);
            yield return new WaitForSeconds(freezeDamageInterval);
        }
    }
}
