using UnityEngine;

public class IA_Player : MonoBehaviour
{
    public float speed = 3.0f;           
    public float attackSpeed = 4.0f;    
    public float attackDistanceY = 2.5f;  
    public Transform ball;                

    public float defenseY = 3.5f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ball == null) return;

        Vector3 aiPos = transform.position;
        Vector3 targetPos = aiPos;
        
        targetPos.x = ball.position.x;

        if (ball.position.y > 0 && ball.position.y <= aiPos.y + attackDistanceY)
        {
            targetPos.y = ball.position.y;
            MoveToTarget(targetPos, attackSpeed);
        }
        else
        {
            targetPos.y = defenseY;
            MoveToTarget(targetPos, speed);
        }
    }

    void MoveToTarget(Vector3 targetPos, float currentSpeed)
    {
        Vector3 dir = targetPos - transform.position;

        if (dir.magnitude > 0.1f)
        {
            dir.Normalize();
            rb2d.linearVelocity = dir * currentSpeed;
        }
        else
        {
            rb2d.linearVelocity = Vector2.zero;
        }
    }
}
