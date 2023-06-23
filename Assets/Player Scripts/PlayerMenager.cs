using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenager : MonoBehaviour
{
    [SerializeField] InputMenager inputMenager;
    [SerializeField] Movemnet movement;

    private void FixedUpdate()
    {
        movement.Move(inputMenager.input);
    }
}
