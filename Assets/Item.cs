using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : IInteractable 
{
    public override void Interact()
    {
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("item picked up");
        gameObject.SetActive(false);
    }
}
