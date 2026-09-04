using UnityEngine;

public class IA_Player : MonoBehaviour
{
    public float speed = 10.0f;           
    public float attackSpeed = 12.0f;    
    public float attackDistanceY = 2.5f;  
    public Transform ball;                
    public float defenseY = 3.5f;

    [Header("Limites de Movimentação da IA")]
    public float minX = -3f; // Ajuste conforme a largura do seu campo
    public float maxX = 3f;  // Ajuste conforme a largura do seu campo

    private Rigidbody2D rb2d;
    private Vector3 targetPos;
    private float currentSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ball == null) return;

        // 1. Define a posição base
        targetPos = transform.position;

        // 2. Trava o X da IA dentro dos limites jogáveis para evitar colisão contínua com a parede
        targetPos.x = Mathf.Clamp(ball.position.x, minX, maxX);

        // 3. Define a lógica de ataque ou defesa
        if (ball.position.y > 0 && ball.position.y <= transform.position.y + attackDistanceY)
        {
            targetPos.y = ball.position.y;
            currentSpeed = attackSpeed;
        }
        else
        {
            targetPos.y = defenseY;
            currentSpeed = speed;
        }
    }

    void FixedUpdate()
    {
        if (ball == null) return;

        // Aplica o movimento físico no tempo certo da física do Unity
        MoveToTarget(targetPos, currentSpeed);
    }

    void MoveToTarget(Vector3 target, float speedToUse)
    {
        Vector2 difference = (Vector2)target - rb2d.position;

        // Só move se a distância for relevante para evitar trepidação (jitter)
        if (difference.magnitude > 0.1f)
        {
            rb2d.linearVelocity = difference.normalized * speedToUse;
        }
        else
        {
            rb2d.linearVelocity = Vector2.zero;
        }
    }
}