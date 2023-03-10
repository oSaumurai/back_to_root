using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionCam : MonoBehaviour
{
    public GameObject virtualCam;
    public int leftOrRight;
    public Transform bg;
    // public GameObject sectionRespawnPoint;
    // Vector2 Respawnposition;
    // public Respawn resp;

    void Start()
    {
        // resp = GameObject.Find("Pink").GetComponent<Respawn>();
        // Respawnposition = new Vector2 (sectionRespawnPoint.transform.position.x, sectionRespawnPoint.transform.position.y);
    }

    // open the cam when player eneter
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            if (leftOrRight == 1)
            {
                bg.position = new Vector2(0f, bg.position.y);
            }
            else if (leftOrRight == 2)
            {
                bg.position = new Vector2(24.05f, bg.position.y);
            }

            virtualCam.SetActive(true);
            // resp.setRespawn(Respawnposition);
        }
    }

    // close the cam when player leave
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
}
