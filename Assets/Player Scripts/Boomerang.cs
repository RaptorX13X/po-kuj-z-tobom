using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Collider2D collider;
    private bool ready = true;
    [SerializeField]private float velocity;
    [SerializeField] private Rigidbody2D player;
    [SerializeField]private float returnAcceleration;
    [SerializeField] private float distance;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float freeFlightDuration;
    private float flightTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.TryGetComponent(out PlayerMenager playerMenager))
        {
            Debug.Log("returned");
            collider.enabled = false;
            ready = true;
            body.velocity = Vector2.zero;
        }
        else
        {
            Debug.Log("Damage dealt");
        }
    }

    public void Throw (Vector3 mousePos)
    {
        if (!ready)
            return;
        body.position = player.position + new Vector2(player.transform.up.x, player.transform.up.y) * distance;
        body.rotation = player.rotation;
        ready = false;
        var dir = transform.up;
        body.velocity = new Vector2(dir.x, dir.y) * velocity;
        collider.enabled = true;
        flightTimer = 0;
    }

    private void FixedUpdate()
    {
        if (!ready)
        {
            flightTimer += Time.fixedDeltaTime;
            var effectiveReturnVel = returnAcceleration * flightTimer / freeFlightDuration;
            var playerDir = (player.position - body.position).normalized;
            body.velocity = flightTimer > freeFlightDuration
                ? playerDir * velocity
                : body.velocity + effectiveReturnVel * Time.fixedDeltaTime * playerDir;
            body.angularVelocity = rotationSpeed;
        }
        else
        {
            body.rotation = player.rotation;
            body.position = player.position + new Vector2(player.transform.up.x, player.transform.up.y) * distance;
            body.angularVelocity = 0;
        }
    }
}
