﻿using UnityEngine;

[CreateAssetMenu(fileName = "BoyzRoaminState", menuName = "SO/BoyzRoaminState")]
public class BoyzRoaminState : AUnitState
{
    public const int StateId = 1;

    [SerializeField] private float roamingRadius = 5f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int enviroRays = 36;
    [SerializeField] private LayerMask layerMask;
    [SerializeField, Range(0f, 1f)] private float distanceWeight = 0.8f;

    private Vector3 lastDirection;

    private float usedDistWeight;
    private int usedEnviroRays;
    private float usedSpeed;
    private float usedRoamingRadius;

    public override void EnterState(Unit unit)
    {
        usedDistWeight = Random.Range(distanceWeight - 0.3f, distanceWeight + 0.1f);
        usedEnviroRays = Random.Range(8, usedEnviroRays);
        usedSpeed = Random.Range(speed - 1f, speed + 0.5f);
        usedRoamingRadius = Random.Range(usedRoamingRadius, usedRoamingRadius + 1f);
    }

    public override void FixedUpdateState(Unit unit)
    {
        Vector3 bestDirection = default;
        Vector3 secondBestDirection = default;

        float bestValue = 0f;

        for (int i = 0; i < usedEnviroRays; i++)
        {
            Vector3 checkedDirection = Quaternion.AngleAxis(i * 360f / usedEnviroRays, Vector3.forward) * Vector3.up;
            Vector2 vectorToPlayer = unit.PlayerReference.transform.position - unit.transform.position;
            float playerAdjustedMultiplier = -Vector3.Dot(checkedDirection, vectorToPlayer.normalized) * (usedRoamingRadius - vectorToPlayer.magnitude);
            float movementSmoothnessMultiplier = Vector3.Dot(checkedDirection, lastDirection);
            float enviroAdjustedMultiplier = 0f;

            RaycastHit2D hit = Physics2D.Raycast(unit.transform.position, checkedDirection, 9999f, layerMask);

            if (hit.collider != null)
            {
                enviroAdjustedMultiplier = hit.distance * usedDistWeight;
            }

            if (bestValue < playerAdjustedMultiplier + enviroAdjustedMultiplier + movementSmoothnessMultiplier)
            {
                secondBestDirection = bestDirection;

                bestValue = playerAdjustedMultiplier + enviroAdjustedMultiplier + movementSmoothnessMultiplier;
                bestDirection = checkedDirection;
            }
        }
        lastDirection = bestDirection;
        unit.Rigidbody2D.MovePosition(Vector2.MoveTowards(unit.transform.position, unit.transform.position + (bestDirection + secondBestDirection) / 2f, usedSpeed * Time.fixedDeltaTime));
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
