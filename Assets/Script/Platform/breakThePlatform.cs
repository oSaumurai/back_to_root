using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakThePlatform : MonoBehaviour
{
    // Declare variables
    private breakPlatManager breakPlatManager;
    float breakTimer;

    public List<GameObject> pieces;

    private bool playerOn = false;
    private float colorAlpha = 1;

    // public AudioSource PlatformBreakingSFX;

    // Start is called before the first frame update
    void Start()
    {
        breakPlatManager = GameObject.Find("BreakPlatManager").GetComponent<breakPlatManager>();
        breakTimer = breakPlatManager.breakCD;
    }

    void Update()
    {
        // When player stand on one of the joins, start the join destory
        // count down.
        if (playerOn)
        {
            // Decrease the timer also make the joins slowly 
            // become transparent.
            if (breakTimer > 0)
            {
                breakTimer -= Time.deltaTime;
                colorAlpha -= Time.deltaTime * 0.6f;
                
                // Get gameobject from pieces list and set color
                foreach (GameObject piece in pieces)
                {
                    piece.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, colorAlpha);
                }
            }
            else // When time is up, disconnect the join and explode
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<PolygonCollider2D>().enabled = false;

                // Get gameobject from pieces list and set fixed joint 2d break force and add force
                foreach (GameObject piece in pieces)
                {
                    piece.GetComponent<FixedJoint2D>().breakForce = 0;
                    // first half of the platform will be pushed to the left and the second half to the right and middle will be pushed down, the force is set to 500 at right most and -500 left most, but it will decrease or increase when it goes to the middle

                    if (pieces.IndexOf(piece) < pieces.Count / 2)
                    {
                        piece.GetComponent<Rigidbody2D>().AddForce(transform.right * (pieces.IndexOf(piece) - pieces.Count / 2) * 500, ForceMode2D.Impulse);
                    }
                    else if (pieces.IndexOf(piece) > pieces.Count / 2)
                    {
                        piece.GetComponent<Rigidbody2D>().AddForce(transform.right * (pieces.IndexOf(piece) - pieces.Count / 2) * 500, ForceMode2D.Impulse);
                    }
                    else
                    {
                        piece.GetComponent<Rigidbody2D>().AddForce(transform.up * (pieces.IndexOf(piece) - pieces.Count / 2) * 500, ForceMode2D.Impulse);
                    }
                }

                // Kill the update
                playerOn = false;
                Debug.Log("Respawn Breakable Platform");
                // breakPlatManager.Instance.StartCoroutine("SpawnPlatform",
                //     new Vector2(transform.position.x, transform.position.y),
                //     transform.parent.gameObject);
                breakPlatManager.BreakPlatform(new Vector2(transform.position.x, transform.position.y), transform.parent.gameObject);


                // Destroy the old platform obj
                Destroy(this.gameObject, breakPlatManager.respawnCD);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Start break the platform when player jump on it.
        if (other.gameObject.CompareTag("Player"))
        {
            // plays platform breaking sound effect
            // PlatformBreakingSFX.Play();
            playerOn = true;
        }
    }
}
