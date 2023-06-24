using UnityEngine;

public abstract class AUnitState : ScriptableObject
{
    public abstract void EnterState(Unit unit);
    public abstract void UpdateState(Unit unit);
    public abstract void FixedUpdateState(Unit unit);
}
