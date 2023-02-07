using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject folderBlock;
    GameObject lockObj;
    public Sprite WayPoint;
    public GameObject path;

    public AudioSource audioSource;

    void Start()
    {
        lockObj = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.keyCount > 0)
            {
                audioSource.PlayOneShot(audioSource.clip);
                GameManager.keyCount--;
                Destroy(folderBlock);
                path.SetActive(true);
                lockObj.GetComponent<SpriteRenderer>().sprite = WayPoint;
            }
        }
    }
}
