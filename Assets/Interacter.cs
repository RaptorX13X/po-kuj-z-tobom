using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    private List<IInteractable> interactables = new List<IInteractable>();
    private float go;
    private float cooldown;

    private IInteractable getClosestInteractable()
    {
        if (interactables.Count == 0)
            return null;

        IInteractable closest = null;
        float closestDistance = 10000;
        foreach (IInteractable interactable in interactables)
        {
            var distance = Vector3.Distance(transform.position, interactable.gameObject.transform.position);
            if (distance < closestDistance)
            {
                closest = interactable;
                closestDistance = distance;
            }
        }

        return closest;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactables.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit");
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactables.Remove(interactable);
        }
    }

    public void Interact()
    {
        if (cooldown > 0)
            return;
        var closest = getClosestInteractable();
        if (closest != null)
        {
            closest.Interact();
            cooldown = 1;
        }
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {   
            Interact();
        }

        go = Input.GetAxis("Horizontal");

        cooldown -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * go;
    }
}
