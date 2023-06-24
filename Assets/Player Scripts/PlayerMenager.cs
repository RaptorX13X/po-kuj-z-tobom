using UnityEngine;

public class PlayerMenager : MonoBehaviour
{
    [SerializeField] InputMenager inputMenager;
    [SerializeField] Movemnet movement;
    [SerializeField] Interacter interacter;
    [SerializeField] private Boomerang boomerang;
    [SerializeField] private ShardThrower shart;
    [SerializeField] private KeyboardRotator keyboardRotator;

    private void FixedUpdate()
    {
        movement.Move(inputMenager.input, inputMenager.mousePos);
        if (inputMenager.yeet)
            boomerang.Throw(inputMenager.mousePos);
        if (inputMenager.glassYeet)
            shart.ShardThrow(inputMenager.mousePos);
    }

    private void Update()
    {
        if (inputMenager.interact) interacter.Interact();
        if (inputMenager.keyboard) keyboardRotator.StartAttack();
    }
}
