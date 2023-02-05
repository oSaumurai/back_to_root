using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFolder : MonoBehaviour
{
    public List<GameObject> folderLevel;
    public List<GameObject> folderTag;

    private int indexLevel = 0;

    // if player press q key, -1 index from the folderLevel list, open the current index gameobject, close other gameobject.
    // if player press e key, +1 index from the folderLevel list, open the current index gameobject, close other gameobject.
    // if index is 0, close the current index gameobject, open the next index gameobject.
    // if index is 2, close the current index gameobject, open the previous index gameobject.

    void Start()
    {
        openFolder(indexLevel);
        selectTag(indexLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            previousFolder();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            nextFolder();
        }
    }

    public void openFolder(int index)
    {
        for (int i = 0; i < folderLevel.Count; i++)
        {
            if (i == index)
            {
                folderLevel[i].SetActive(true);
            }
            else
            {
                folderLevel[i].SetActive(false);
            }
        }
    }

    public void selectTag(int index)
    {
        for (int i = 0; i < folderTag.Count; i++)
        {
            if (i == index)
            {
                folderTag[i].SetActive(true);
            }
            else
            {
                folderTag[i].SetActive(false);
            }
        }
    }

    // if player press right arrow key
    public void nextFolder()
    {
        if (indexLevel < folderLevel.Count - 1)
        {
            indexLevel++;
            openFolder(indexLevel);
            selectTag(indexLevel);
        }
        else
        {
            indexLevel = 0;
            openFolder(indexLevel);
            selectTag(indexLevel);
        }
    }

    // if player press left arrow key
    public void previousFolder()
    {
        if (indexLevel > 0)
        {
            indexLevel--;
            openFolder(indexLevel);
            selectTag(indexLevel);
        }
        else
        {
            indexLevel = folderLevel.Count - 1;
            openFolder(indexLevel);
            selectTag(indexLevel);
        }
    }
}
