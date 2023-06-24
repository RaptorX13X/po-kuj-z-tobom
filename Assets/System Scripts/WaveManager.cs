using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform enemiesParent;
    [SerializeField] private Transform enemiesSpawnPoint;
    [SerializeField] private PlayerMenager player;

    private int currentWave = -1;

    public int EnemiesAlive { get; set; }
    public Transform EnemiesParent => enemiesParent;
    public Vector2 EnemiesSpawnPoint => enemiesSpawnPoint.position;
    public PlayerMenager Player => player;

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
    }
}
