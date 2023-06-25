using UnityEngine;

// Singleton class
public sealed class BoyzBrain : MonoBehaviour
{
    private static BoyzBrain Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
