using UnityEngine;

public class PlayerMenager : MonoBehaviour
{
    [SerializeField] InputMenager inputMenager;
    [SerializeField] Movemnet movement;
    [SerializeField] Interacter interacter;

    private void FixedUpdate()
    {
        movement.Move(inputMenager.input);
    }

    private void Update()
    {
        if (inputMenager.interact) interacter.Interact();
    }
}
