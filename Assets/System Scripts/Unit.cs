using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Unit : MonoBehaviour
{
    [SerializeField] private AUnitState[] possibleStates;

    private AUnitState currentState;
    private WaveManager waveManager;
    private Rigidbody2D rb;

    public PlayerMenager PlayerReference => waveManager.Player;
    public Rigidbody2D Rigidbody2D => rb;

    public void Init(WaveManager waveManager)
    {
        this.waveManager = waveManager;
    }

    private void Start()
    {
        for (int i = 0; i < possibleStates.Length; i++)
        {
            possibleStates[i] = Instantiate(possibleStates[i]);
        }

        GetComponent<Health>().OnDeath += Die;

        rb = GetComponent<Rigidbody2D>();

        SwitchState(0);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    public void SwitchState(int newStateId)
    {
        currentState = possibleStates[newStateId];
        currentState.EnterState(this);
    }

    private void Die()
    {
        waveManager.EnemiesAlive--;
        Destroy(gameObject);
    }
}
