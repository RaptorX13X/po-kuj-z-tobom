using UnityEngine;

[CreateAssetMenu(fileName = "BlobChillingState", menuName = "SO/BlobChillingState")]
public class BlobChillingState : AUnitState
{
    public const int StateId = 1;

    [SerializeField] private float chilinTime = 2f;
    [SerializeField] private float chilinTimeVariety = 0.25f;

    private float remainingChillingTime;

    public override void EnterState(Unit unit)
    {
        remainingChillingTime = Random.Range(chilinTime - chilinTimeVariety, chilinTime + chilinTimeVariety);
    }

    public override void FixedUpdateState(Unit unit)
    {
        // Nothing
    }

    public override void UpdateState(Unit unit)
    {
        remainingChillingTime -= Time.deltaTime;

        if (remainingChillingTime <= 0)
        {
            unit.SwitchState(BlobFightngState.StateId);
        }
    }
}
