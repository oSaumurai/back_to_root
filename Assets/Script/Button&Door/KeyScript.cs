using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    bool singleton_check = false;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !singleton_check)
        {
            singleton_check = true;
        
            GameManager.keyCount++;

            Destroy(this.gameObject);
        }
    }
}
