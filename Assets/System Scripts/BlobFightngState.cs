using UnityEngine;

[CreateAssetMenu(fileName = "BlobFightngState", menuName = "SO/BlobFightngState")]
public class BlobFightngState : AUnitState
{
    public const int StateId = 0;

    [SerializeField] private float jumpDistance = 2f;
    [SerializeField] private float jumpSpeed = 10f;

    private Vector2 targetPosition;

    public override void EnterState(Unit unit)
    {
        if (Vector2.Distance(unit.transform.position, unit.PlayerReference.transform.position) > jumpDistance)
            targetPosition = unit.transform.position + (unit.PlayerReference.transform.position - unit.transform.position).normalized * jumpDistance;
        else
            targetPosition = unit.PlayerReference.transform.position;
    }

    public override void FixedUpdateState(Unit unit)
    {
        unit.Rigidbody2D.MovePosition(Vector2.MoveTowards(unit.transform.position, targetPosition, jumpSpeed * Time.deltaTime));

        if (Vector2.Distance(unit.transform.position, targetPosition) <= 0.01f)
            unit.SwitchState(BlobChillingState.StateId);
    }

    public override void UpdateState(Unit unit)
    {
        // Nothing
    }
}
