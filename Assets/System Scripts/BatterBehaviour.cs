using UnityEngine;

public class BatterBehaviour : MonoBehaviour
{
    [SerializeField] private float cooldown = 2.0f;
    [SerializeField] private float distanceToAttackPlayer = 2.0f;
    [SerializeField] private Unit unit;
    [SerializeField] private KeyboardRotator keyboarder;

    private float activeCooldown = 0f;
    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<PlayerMenager>().transform;
    }

    private void Update()
    {
        activeCooldown -= Time.deltaTime;

        if (activeCooldown <= 0 && Vector2.Distance(target.position, transform.parent.position) <= distanceToAttackPlayer)
        {
            activeCooldown = cooldown;

            keyboarder.StartAttack(target.position);

            unit.SwitchState(BoyzRoaminState.StateId);
        }
    }

    public void ResetCooldown()
    {
        activeCooldown = 0f;
    }
}
