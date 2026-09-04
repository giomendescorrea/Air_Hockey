using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 25.0f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -Camera.main.transform.position.z;
        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // Move o objeto em direção ao mouse através de velocidade (não atravessa paredes)
        Vector2 newPosition = Vector2.MoveTowards(rb2d.position, targetPosition, speed * Time.fixedDeltaTime);
        
        rb2d.MovePosition(newPosition);
    }
}
