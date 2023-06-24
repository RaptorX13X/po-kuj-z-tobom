using UnityEngine;

public class PlayerMenager : MonoBehaviour
{
    [SerializeField] InputMenager inputMenager;
    [SerializeField] Movemnet movement;
    [SerializeField] Interacter interacter;
    [SerializeField] private Boomerang boomerang;

    private void FixedUpdate()
    {
        movement.Move(inputMenager.input, inputMenager.mousePos);
        if (inputMenager.yeet)
            boomerang.Throw(inputMenager.mousePos);
    }

    private void Update()
    {
        if (inputMenager.interact) interacter.Interact();
    }
}
