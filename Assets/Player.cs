using UnityEngine;

public class Player : MonoBehaviour

{
    public float speed = 70.0f;             // Define a velocidade da raquete
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float clampedX = Mathf.Clamp(mousePos.x, -4.5f, 4.1f); 
        float clampedY = Mathf.Clamp(mousePos.y, -8.0f, -0.5f); 

        rb2d.MovePosition(new Vector2(clampedX, clampedY));
    }
}
