using UnityEngine;

[CreateAssetMenu(fileName = "GrandpaFightingState", menuName = "SO/GrandpaFightingState")]
public class GrandpaFightingState : AUnitState
{
    public const int StateId = 0;

    [SerializeField] private float baseSpeed = 3.5f;
    [SerializeField] private float maxSpeed = 5.5f;

    public override void EnterState(Unit unit)
    {
        GrampsBrain.Instance.SetGrandpa(unit);
        unit.GetComponentInChildren<GrandpaBattingBehaviour>().ResetCooldown();
    }

    public override void FixedUpdateState(Unit unit)
    {
        unit.Rigidbody2D.MovePosition(Vector2.MoveTowards(unit.transform.position, unit.PlayerReference.transform.position, GrampsBrain.Instance.GrandpaScaling(baseSpeed, maxSpeed) * Time.fixedDeltaTime));
    }

    public override void UpdateState(Unit unit)
    {
        // Nothing
    }

    public override void OnCollisionEnterAction(Unit unit, Collision2D collision)
    {
        // Nothing
    }
}
