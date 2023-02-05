using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject folderBlock;
    GameObject lockObj;
    public Sprite WayPoint;
    public GameObject path;

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
                GameManager.keyCount--;
                Destroy(folderBlock);
                path.SetActive(true);
                lockObj.GetComponent<SpriteRenderer>().sprite = WayPoint;
            }
        }
    }
}
