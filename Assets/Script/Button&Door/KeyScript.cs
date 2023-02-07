using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    bool singleton_check = false;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !singleton_check)
        {
            singleton_check = true;
        
            GameManager.keyCount++;
            gameManager.PlayKeySound();

            Destroy(this.gameObject);
        }
    }
}
