using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Vector2 spawnPoint;

    // public AudioSource RockPushedSFX;
    // public AudioSource RockLandedSFX;

    // bool singleton_check = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = this.transform.position;
    }

    // Reset the box to its spawn point
    public void respawn()
    {
        this.transform.position = spawnPoint;
        this.transform.parent = null;
        // singleton_check = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // RockPushedSFX.Play();
        }
        // if (other.gameObject.CompareTag("Rock_Destroyer"))
        // {
        //     respawn();
        //     // Debug.Log("Rock stuck at corner... It is respawned.");
        // }
        // if (other.gameObject.CompareTag("Rock_Landed"))
        // {
        //     // play sound effect only once.
        //     if (!singleton_check)
        //     {
        //         RockLandedSFX.Play();
        //         singleton_check = true;
        //     }
        // }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player Exist!");
            // Rock being pushed sfx stops 
            // RockPushedSFX.Stop();
            other.gameObject.transform.parent = null;
        }
        // Reset's singleton check if rock leaves the ground
        // if (other.gameObject.CompareTag("Rock_Landed"))
        // {
        //     singleton_check = false;
        // }
        // When box leave other boxes, move freely
        if (other.gameObject.CompareTag("Box"))
        {
            if (other.transform.position.y > this.transform.position.y)
            {
                other.gameObject.transform.parent = null;
                if (other.gameObject.transform.position.x > this.gameObject.transform.position.x)
                {
                    other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x + 0.1f, other.gameObject.transform.position.y);
                }
                if (other.gameObject.transform.position.x < this.gameObject.transform.position.x)
                {
                    other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x - 0.1f, other.gameObject.transform.position.y);
                }
            }
            else if (other.transform.position.y < this.transform.position.y)
            {
                this.gameObject.transform.parent = null;
            }
        }
    }

    public void SetBoxDynamic()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public void SetBoxKinematic()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
