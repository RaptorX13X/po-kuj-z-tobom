using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform enemiesParent;
    [SerializeField] private Transform enemiesSpawnPoint;
    [SerializeField] private PlayerMenager player;
    [SerializeField] private GameUIManager gameUIManager;

    private int currentWave = -1;

    public int EnemiesAlive { get; set; }
    public Transform EnemiesParent => enemiesParent;
    public Vector2 EnemiesSpawnPoint => enemiesSpawnPoint.position;
    public PlayerMenager Player => player;


    private void Start()
    {
        player.GetComponent<Health>().OnDeath += DisplayLoseScreen;
    }

    private void Update()
    {
        if (EnemiesAlive == 0)
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        currentWave++;
        player.SetWeapon(PlayerMenager.Weapons.None);
        if (currentWave < waves.Length)
        {
            CleanRoom();
            waves[currentWave].StartWave(this);
        }
        else
        {
            DisplayWinScreen();
        }
    }

    private void CleanRoom()
    {
        Debug.Log("Room cleaning after battle");
    }

    private void DisplayWinScreen()
    {
        Debug.Log("You won!!");
        gameUIManager.DisplayVictoryScreen();
    }

    private void DisplayLoseScreen()
    {
        Debug.Log("You lost!!");
        gameUIManager.DisplayLoseScreen();
    }
}
