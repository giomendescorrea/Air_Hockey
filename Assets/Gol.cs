using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isBlueGoalPoint;
    public AudioSource source;

    private GameManager gameManager;

    void Start()
    {
        source = GetComponent<AudioSource>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Funciona com Colliders marcados como 'Is Trigger'
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            gameManager.ScorePoint(isBlueGoalPoint);
            source.Play();
        }
    }
}