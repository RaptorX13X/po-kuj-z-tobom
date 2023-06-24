using UnityEngine;

public abstract class AUnitState : ScriptableObject
{
    public abstract void EnterState(Unit unit);
    public abstract void UpdateState(Unit unit);
    public abstract void FixedUpdateState(Unit unit);
    public abstract void OnCollisionEnterAction(Unit unit, Collision2D collision); // to akurat taki syf na szybko ¿eby knocback starego zrobiæ sprawnie
}
