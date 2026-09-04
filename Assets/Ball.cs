using UnityEngine;

public class Ball : MonoBehaviour

{
    private Rigidbody2D rb2d;
    public AudioSource source;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        source = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);
            rb2d.linearVelocity = vel;
        }
        source.Play();
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rb2d.linearVelocity = Vector2.zero;
        rb2d.angularVelocity = 0f;
    }
}
