using System.Collections;
using UnityEngine;

public class TorchMainCore : MonoBehaviour
{
    public float torchMaxHealth;
    public float torchHealth;
    public float torchBurn;
    public float torchBurnInterval;
    public Coroutine torchBurnCoroutine;

    private GameObject _torchObject;
    [SerializeField] private Bars _bars;

    private void Awake()
    {
        _torchObject = GameObject.Find("Torch");
    }

    private void Start()
    {
        _bars.SetMaxTorchHealth(torchMaxHealth);
    }

    private void FixedUpdate()
    {
        if (torchHealth > 0 && _torchObject.activeSelf)
        {
            if (torchBurnCoroutine == null)
            {
                torchBurnCoroutine = StartCoroutine(ApplyTorchBurn());
            }
        } else
        {
            if (_torchObject != null)
            {
                _torchObject.SetActive(false);
            }

            if (torchBurnCoroutine != null)
            {
                StopCoroutine(torchBurnCoroutine);
                torchBurnCoroutine = null;
            }
        }
    }

    private IEnumerator ApplyTorchBurn()
    {
        while (torchHealth > 0)
        {
            torchHealth -= torchBurn;
            _bars.SetTorchHealth(torchHealth);
            yield return new WaitForSeconds(torchBurnInterval);
        }
    }
}
