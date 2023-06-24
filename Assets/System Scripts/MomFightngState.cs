using UnityEngine;

[CreateAssetMenu(fileName = "MomFightngState", menuName = "SO/MomFightngState")]
public class MomFightngState : AUnitState
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int enviroRays = 36;
    [SerializeField] private LayerMask layerMask;
    [SerializeField, Range(0f, 1f)] private float distanceWeight = 0.4f;

    private Vector3 lastDirection;

    public override void EnterState(Unit unit)
    {
        // Nothing
    }

    public override void FixedUpdateState(Unit unit)
    {
        Vector3 bestDirection = default;
        Vector3 secondBestDirection = default;

        float bestValue = 0f;

        for (int i = 0; i < enviroRays; i++)
        {
            Vector3 checkedDirection = Quaternion.AngleAxis(i * 360f/ enviroRays, Vector3.forward) * Vector3.up;
            Vector2 vectorToPlayer = unit.PlayerReference.transform.position - unit.transform.position;
            float playerAdjustedMultiplier = -Vector3.Dot(checkedDirection, vectorToPlayer.normalized) * (5f - vectorToPlayer.magnitude);
            float movementSmoothnessMultiplier = Vector3.Dot(checkedDirection, lastDirection);
            float enviroAdjustedMultiplier = 0f;

            RaycastHit2D hit = Physics2D.Raycast(unit.transform.position, checkedDirection, 9999f, layerMask);

            if (hit.collider != null)
            {
                enviroAdjustedMultiplier = hit.distance * distanceWeight;
            }

            if (bestValue < playerAdjustedMultiplier + enviroAdjustedMultiplier + movementSmoothnessMultiplier)
            {
                secondBestDirection = bestDirection;

                bestValue = playerAdjustedMultiplier + enviroAdjustedMultiplier + movementSmoothnessMultiplier;
                bestDirection = checkedDirection;
            }
        }
        lastDirection = bestDirection;
        unit.Rigidbody2D.MovePosition(Vector2.MoveTowards(unit.transform.position, unit.transform.position + (bestDirection + secondBestDirection) / 2f, speed * Time.fixedDeltaTime));
    }
    public override void UpdateState(Unit unit)
    {
        // Throwing
    }
}
