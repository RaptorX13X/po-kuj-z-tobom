using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemnet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    public void Move(Vector2 input)
    {
        rb.velocity = input.normalized * speed;
    }
}
