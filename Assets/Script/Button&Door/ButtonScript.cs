using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private bool pressed;
    private SpriteRenderer SR;
    [SerializeField] private Sprite up;
    [SerializeField] private Sprite down;
    [SerializeField] private GameObject upLock;

    [SerializeField] private bool inverse;
    [SerializeField] private bool secritFolder;
    ChangeFolder changeFolder;


    [SerializeField] private int signal = 0;
    private List<GameObject> recievers;

    // public AudioSource PathUnlockedSFX;

    void Awake()
    {
        recievers = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (secritFolder)
        {
            changeFolder = GameObject.FindWithTag("Folder").GetComponent<ChangeFolder>();
        }

        SR = this.GetComponent<SpriteRenderer>();
        pressed = false;
        SR.sprite = up;

        StartCoroutine(SetTheWait());
    }

    IEnumerator SetTheWait()
    {
        yield return new WaitForSeconds(0.1f);
        if (secritFolder)
        {
            changeFolder.DecreaseCount();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!pressed)
            {
                press();
            }
            pressed = true;
            // set the object transform y lower
            SR.sprite = down;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            if (!pressed)
            {
                press();
                // PathUnlockedSFX.Play();
            }
            pressed = true;
            SR.sprite = down;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Player"))
        {
            if (pressed)
            {
                release();
            }
            pressed = false;
            SR.sprite = up;
        }
    }

    public void press()
    {
        if (secritFolder)
        {
            changeFolder.IncreaseCount();
        }

        // downunLock.SetActive(true);
        if (inverse)
        {
            upLock.SetActive(true);
        }
        else
        {
            upLock.SetActive(false);
        }
        GameManager.isUnlock = true;

        // foreach (GameObject GO in recievers)
        // {
        //     Debug.Log("PressingDoor" + GO.GetComponent<DoorScript>().getSignal());
        //     Debug.Log("PressingReciever" + GO.GetComponent<RecieverScript>().getSignal());
        //     GO.GetComponent<RecieverScript>().triggerPress();
        // }
    }

    public void release()
    {
        if (secritFolder)
        {
            changeFolder.DecreaseCount();
        }

        // downunLock.SetActive(false);
        if (inverse)
        {
            upLock.SetActive(false);
        }
        else
        {
            upLock.SetActive(true);
        }
        GameManager.isUnlock = false;

        // foreach (GameObject GO in recievers)
        // {
        //     Debug.Log("RealisingDoor" + GO.GetComponent<DoorScript>().getSignal());
        //     Debug.Log("RealisingReciever" + GO.GetComponent<RecieverScript>().getSignal());
        //     GO.GetComponent<RecieverScript>().triggerRelease();
        // }
    }

    public int getSignal()
    {
        return signal;
    }

    public void addItem(GameObject reciever)
    {
        recievers.Add(reciever);
        Debug.Log("adding Reciever");
    }
}
