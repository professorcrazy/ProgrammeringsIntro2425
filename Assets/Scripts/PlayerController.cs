using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    float speed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move; 
        move.x = Input.GetAxisRaw("Horizontal") * speed;
        move.y = rb.linearVelocityY;
        anim.SetFloat("Speed", Mathf.Abs(move.x));
        rb.linearVelocity = move;
    }
}
