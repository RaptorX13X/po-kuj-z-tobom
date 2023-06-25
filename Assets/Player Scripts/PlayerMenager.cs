using UnityEngine;

public class PlayerMenager : MonoBehaviour
{
    [SerializeField] InputMenager inputMenager;
    [SerializeField] Movemnet movement;
    [SerializeField] Interacter interacter;
    [SerializeField] private Boomerang boomerang;
    [SerializeField] private ShardThrower shart;
    [SerializeField] private ShardThrower pillow;
    [SerializeField] private KeyboardRotator keyboardRotator;
    [SerializeField] private BlankieController blankieController;
    public enum Weapons { Pillow, Shard, Hanger, Blanket, Keyboard, None };
    private Weapons activeWeapon = Weapons.None;
    private float actionCooldown;
    private void FixedUpdate()
    {
        movement.Move(inputMenager.input, inputMenager.mousePos);
        if (inputMenager.action)
        {
            if (actionCooldown > 0) return;
            switch (activeWeapon)
            {
                case Weapons.Pillow:
                    pillow.ShardThrow(inputMenager.mousePos);
                    actionCooldown = 0.3f;
                    break;
                case Weapons.Shard:
                    shart.ShardThrow(inputMenager.mousePos);
                    actionCooldown = 0.3f;
                    break;
                case Weapons.Hanger:
                    boomerang.Throw(inputMenager.mousePos);
                    actionCooldown = 0.3f;
                    break;
            }
        }
    }

    private void Update()
    {
        actionCooldown -= Time.deltaTime;
        if (inputMenager.action && actionCooldown <= 0)
        {
            switch (activeWeapon)
            {
                case Weapons.Blanket:
                    blankieController.StartAttack(inputMenager.mousePos);
                    actionCooldown = 0.3f;
                    break;
                case Weapons.Keyboard:
                    keyboardRotator.StartAttack(inputMenager.mousePos);
                    actionCooldown = 0.3f;
                    break;
                case Weapons.None:
                    interacter.Interact();
                    actionCooldown = 0.3f;
                    break;
            }
        }
    }

    public void SetWeapon(Weapons weapon)
    {
        switch (activeWeapon)
        {
            case Weapons.Shard:
                shart.gameObject.SetActive(false);
                break;
            case Weapons.Pillow:
                pillow.gameObject.SetActive(false);
                break;
            case Weapons.Blanket:
                blankieController.gameObject.SetActive(false);
                break;
            case Weapons.Hanger:
                boomerang.gameObject.SetActive(false);
                break;
            case Weapons.Keyboard:
                keyboardRotator.gameObject.SetActive(false);
                break;
        }

        activeWeapon = weapon;

        switch (activeWeapon)
        {
            case Weapons.Shard:
                shart.gameObject.SetActive(true);
                break;
            case Weapons.Pillow:
                pillow.gameObject.SetActive(true);
                break;
            case Weapons.Blanket:
                blankieController.gameObject.SetActive(true);
                break;
            case Weapons.Hanger:
                boomerang.gameObject.SetActive(true);
                break;
            case Weapons.Keyboard:
                keyboardRotator.gameObject.SetActive(true);
                break;
        }
    }
}
