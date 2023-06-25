using UnityEngine;

[CreateAssetMenu(fileName = "GrandpaWaitState", menuName = "SO/GrandpaWaitState")]
public class GrandpaWaitState : AUnitState
{
    public const int StateId = 1;

    [SerializeField] private float waitingTime = 1.5f;
    [SerializeField] private float minWaitingTime = 0.25f;
    private float alreadyWaited;

    public override void EnterState(Unit unit)
    {
        alreadyWaited = 0f;
    }

    public override void FixedUpdateState(Unit unit)
    {
        // Nothing
    }

    public override void UpdateState(Unit unit)
    {
        alreadyWaited += Time.deltaTime;

        if (alreadyWaited >= GrampsBrain.Instance.GrandpaScaling(waitingTime, minWaitingTime))
        {
            unit.SwitchState(GrandpaFightingState.StateId);
        }
    }

    public override void OnCollisionEnterAction(Unit unit, Collision2D collision)
    {
        // Nothing
    }
}

[CreateAssetMenu(fileName = "GrannyWaitState", menuName = "SO/GrannyWaitState")]
public class GrannyWaitState : AUnitState
{
    public const int StateId = 0;

    [SerializeField] private float waitingTime = 5f;
    private float alreadyWaited;

    public override void EnterState(Unit unit)
    {
        GrampsBrain.Instance.SetGranny(unit);

        alreadyWaited = 0f;
    }

    public override void FixedUpdateState(Unit unit)
    {
        // Nothing
    }

    public override void UpdateState(Unit unit)
    {
        alreadyWaited += Time.deltaTime;

        if (alreadyWaited >= waitingTime)
        {
            unit.SwitchState(GrannyHealingState.StateId);
        }
    }

    public override void OnCollisionEnterAction(Unit unit, Collision2D collision)
    {
        // Nothing
    }
}

[CreateAssetMenu(fileName = "GrannyHealingState", menuName = "SO/GrannyHealingState")]
public class GrannyHealingState : AUnitState
{
    public const int StateId = 1;

    [SerializeField] private float healingValue = 4f;

    public override void EnterState(Unit unit)
    {
        var gran = GrampsBrain.Instance.Grandpa;
        if (gran.gameObject != null)
        {
            gran.GetComponent<Health>().Heal(healingValue);
        }

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