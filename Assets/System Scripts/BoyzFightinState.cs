using UnityEngine;

[CreateAssetMenu(fileName = "BoyzFightinState", menuName = "SO/BoyzFightinState")]
public class BoyzFightinState : AUnitState
{
    public const int StateId = 2;

    [SerializeField] private float speed = 3.5f;

    public override void EnterState(Unit unit)
    {
        unit.SpriteRenderer.sprite = stateSprite;
        unit.GetComponentInChildren<BatterBehaviour>().ResetCooldown();
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
        // Nothing
    }
}
