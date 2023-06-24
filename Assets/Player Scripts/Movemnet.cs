using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemnet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    public void Move(Vector2 input, Vector3 mousePos)
    {
        rb.velocity = input.normalized * speed;
        var dir = (mousePos - transform.position).normalized;
        rb.rotation = Vector3.SignedAngle(Vector3.up, dir, Vector3.forward);
    }
}
