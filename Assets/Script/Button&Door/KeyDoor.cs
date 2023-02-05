using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject folderBlock;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.keyCount > 0)
            {
                GameManager.keyCount--;
                Destroy(folderBlock);
                Destroy(this.gameObject);
            }
        }
    }
}
