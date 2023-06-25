﻿using UnityEngine;

public class GrandpaBattingBehaviour : MonoBehaviour
{
    [SerializeField] private float cooldown = 2.0f;
    [SerializeField] private float minCooldown = 0.25f;
    [SerializeField] private float distanceToAttackPlayer = 2.5f;
    [SerializeField] private Unit unit;
    [SerializeField] private KeyboardRotator keyboarder;

    private float activeCooldown = 999f;
    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<PlayerMenager>().transform;
    }

    private void Update()
    {
        activeCooldown += Time.deltaTime;

        if (activeCooldown >= GrampsBrain.Instance.GrandpaScaling(cooldown, minCooldown) && Vector2.Distance(target.position, transform.parent.position) <= distanceToAttackPlayer)
        {
            activeCooldown = 0f;

            keyboarder.StartAttack(target.position);

            unit.SwitchState(GrandpaWaitState.StateId);
        }
    }

    public void ResetCooldown()
    {
        activeCooldown = 999f;
    }
}
