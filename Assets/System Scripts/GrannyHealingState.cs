using UnityEngine;

[CreateAssetMenu(fileName = "GrannyHealingState", menuName = "SO/GrannyHealingState")]
public class GrannyHealingState : AUnitState
{
    public const int StateId = 1;

    [SerializeField] private int healingValue = 4;
    [SerializeField] private int selfHealingValue = 2;

    public override void EnterState(Unit unit)
    {
        var gran = GrampsBrain.Instance.Grandpa;
        if (gran != null)
        {
            gran.GetComponent<Health>().Heal(healingValue);
        }

        unit.GetComponent<Health>().Heal(selfHealingValue);

        unit.SwitchState(GrannyWaitState.StateId);
    }

    public override void FixedUpdateState(Unit unit)
    {
        // Nothing
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