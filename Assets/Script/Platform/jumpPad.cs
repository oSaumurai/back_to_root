using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    public float bounce;
    public Animator anim;
    // public AudioSource JumpPadSFX;

    public AudioSource JumpPadSFX;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JumpPadSFX.PlayOneShot(JumpPadSFX.clip);
            anim.SetBool("Jump", true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            StartCoroutine(JumpPadWait());
        }
    }

    IEnumerator JumpPadWait()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Jump", false);
    }
}
