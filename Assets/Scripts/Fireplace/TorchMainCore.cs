using System.Collections;
using UnityEngine;

public class TorchMainCore : MonoBehaviour
{
    public float torchHealth;
    public float torchBurn;
    public float torchBurnInterval;

    private Coroutine torchBurnCoroutine;
    private GameObject _torchObject;

    private void Awake()
    {
        _torchObject = GameObject.Find("Torch");
    }

    private void FixedUpdate()
    {
        if (torchHealth > 0)
        {
            if (_torchObject != null)
            {
                _torchObject.SetActive(true);
            }

            if (torchBurnCoroutine == null)
            {
                torchBurnCoroutine = StartCoroutine(ApplyTorchBurn());
            }
        }
        else
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

        Debug.Log("Torch health:" + torchHealth);
    }

    private IEnumerator ApplyTorchBurn()
    {
        while (torchHealth > 0)
        {
            yield return new WaitForSeconds(torchBurnInterval);
            torchHealth -= torchBurn;
        }
    }
}
