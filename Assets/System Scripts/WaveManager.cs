using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform enemiesParent;
    [SerializeField] private Transform enemiesSpawnPoint;
    [SerializeField] private PlayerMenager player;
    [SerializeField] private GameUIManager gameUIManager;
    [SerializeField] private AudioClip doorSound;

    private int currentWave = -1;
    private bool gameFinished = false;

    public int EnemiesAlive { get; set; }
    public Transform EnemiesParent => enemiesParent;
    public Vector2 EnemiesSpawnPoint => enemiesSpawnPoint.position;
    public PlayerMenager Player => player;

    public bool GameStarted;

    private void Start()
    {
        player.GetComponent<Health>().OnDeath += DisplayLoseScreen;
    }

    private void Update()
    {
        if (!GameStarted) return;

        if (EnemiesAlive == 0)
        {
            player.SetWeapon(PlayerMenager.Weapons.None);
        }
    }

    public void NextWave()
    {
        if (gameFinished)
            return;

        AudioManager.instance.PlaySound(doorSound);
        currentWave++;
        if (currentWave < waves.Length)
        {
            CleanRoom();
            waves[currentWave].StartWave(this);
        }
        else
        {
            DisplayWinScreen();
            gameFinished = true;
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
