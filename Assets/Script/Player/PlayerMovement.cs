using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 12f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    NextLevel nextLevel;

    public AudioSource audioSource;

    void Start()
    {
        GameManager.isUnlock = true;
        nextLevel = GetComponent<NextLevel>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            audioSource.PlayOneShot(audioSource.clip);
            rb.AddForce(Vector2.up * jumpingPower, ForceMode2D.Impulse);
        }

        Flip();
    }

    public void hasButton()
    {
        GameManager.isUnlock = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Goal") && GameManager.isUnlock)
        {
            speed = 0;
            jumpingPower = 0;
            nextLevel.NextScene();
        }

        if (other.gameObject.CompareTag("movingPlatform"))
        {
            this.gameObject.transform.parent = other.gameObject.transform;
        }

        if (other.gameObject.CompareTag("Death"))
        {
            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("movingPlatform"))
        {
            this.gameObject.transform.parent = null;
        }
    }
}
