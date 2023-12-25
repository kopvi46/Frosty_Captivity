using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchGenerator : Interactable
{
    public GameObject torchObject;
    public TorchMainCore torchMainCore;
    public FireplaceMainCore fireplaceMainCore;

    public override void Interact()
    {
        base.Interact();

        if (torchObject != null && !torchObject.activeSelf)
        {
            torchObject.SetActive(true);
            torchMainCore.torchHealth = 10;
            fireplaceMainCore.fireplaceHealth -= 100;
        }
    }
}
