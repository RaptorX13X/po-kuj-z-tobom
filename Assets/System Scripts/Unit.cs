using UnityEngine;

public class Unit : MonoBehaviour
{
    private WaveManager waveManager;

    public void Init(WaveManager waveManager)
    {
        this.waveManager = waveManager;
    }

    private void Die()
    {
        waveManager.EnemiesAlive--;
        Destroy(gameObject);
    }
}
