using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator ClickTOStartAnim;
    public Animator BG_artAnim;
    public Animator LeftGrayAnim;
    public Animator RightGrayAnim;
    public Animator EnterToCreditsAnim;
    public Animator EnterToCreditsBGAnim;
    public Animator LeaveToCreditsAnim;
    public Animator LeaveToCreditsBGAnim;
    public GameObject FirstLayer;
    public GameObject SecondLayer;
    public GameObject ThirdLayer;
    bool startTransition = false;

    void Start()
    {
        SecondLayer.SetActive(false);
    }

    public void ClickToPlay()
    {
        ClickTOStartAnim.SetTrigger("Clicked");
        StartCoroutine(MainMenuTransition());
    }

    IEnumerator MainMenuTransition()
    {
        yield return new WaitForSeconds(1f);
        LeftGrayAnim.SetTrigger("StartShift");
        RightGrayAnim.SetTrigger("StartShift");
        startTransition = true;
        yield return new WaitForSeconds(1f);
        SecondLayer.SetActive(true);
    }

    public void PlayGame()
    {
        //load the next scene
        StartCoroutine(GameStartTransition());
    }

    IEnumerator GameStartTransition()
    {
        EnterToCreditsBGAnim.SetTrigger("ToCredit");
        yield return new WaitForSeconds(0.3f);
        EnterToCreditsAnim.SetTrigger("NextMenu");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnterToCredits()
    {
        StartCoroutine(EnterToCreditsTransition());
    }

    IEnumerator EnterToCreditsTransition()
    {
        EnterToCreditsBGAnim.SetTrigger("ToCredit");
        yield return new WaitForSeconds(0.3f);
        EnterToCreditsAnim.SetTrigger("NextMenu");
        yield return new WaitForSeconds(1f);
        SecondLayer.SetActive(false);
        ThirdLayer.SetActive(true);
    }

    public void LeaveToCredits()
    {
        StartCoroutine(LeaveToCreditsTransition());
    }

    IEnumerator LeaveToCreditsTransition()
    {
        LeaveToCreditsBGAnim.SetTrigger("LeaveCredit");
        yield return new WaitForSeconds(0.3f);
        LeaveToCreditsAnim.SetTrigger("NextMenu");
        yield return new WaitForSeconds(1f);
        ThirdLayer.SetActive(false);
        SecondLayer.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    void Update()
    {
        // press escape to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        if (startTransition)
        {
            BG_artAnim.SetTrigger("start");
            // if FirstLayer canvas group alpha is bigger than 0, minus 0.01f
            if (FirstLayer.GetComponent<CanvasGroup>().alpha > 0)
            {
                FirstLayer.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            }
            else
            {
                FirstLayer.SetActive(false);
            }
        }
    }
}
