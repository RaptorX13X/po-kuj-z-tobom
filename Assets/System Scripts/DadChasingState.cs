using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "DadChasingState", menuName = "SO/DadChasingState")]
public class DadChasingState : AUnitState
{
    public const int StateId = 0;

    [SerializeField] private float speed = 4f;
    [SerializeField] private float knockbackForce = 20f;

    public override void EnterState(Unit unit)
    {
        // Nothing
    }

    public override void FixedUpdateState(Unit unit)
    {
        unit.Rigidbody2D.MovePosition(Vector2.MoveTowards(unit.transform.position, unit.PlayerReference.transform.position, speed * Time.fixedDeltaTime));
    }

    public override void UpdateState(Unit unit)
    {
        // Nothing
    }

    public override void OnCollisionEnterAction(Unit unit, Collision2D collision)
    {
        Vector2 difference = (unit.PlayerReference.transform.position - unit.transform.position).normalized;
        Vector2 force = difference * knockbackForce;
        unit.PlayerReference.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

        unit.SwitchState(DadBeltState.StateId);
    }
}
