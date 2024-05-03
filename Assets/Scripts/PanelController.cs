using System;
using System.Collections;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject Tint;

    [Space]

    [SerializeField] GameObject Starting;
    [SerializeField] GameObject Playing;

    [Space]

    [SerializeField] GameObject Help;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Lost;
    [SerializeField] GameObject Buy;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void OpenTint(int index)
    {
        Tint.SetActive(true);

        if (index == 0)
            Tint.GetComponent<Animator>().SetTrigger("Pause");
        else if(index == 1)
            Tint.GetComponent<Animator>().SetTrigger("End");
        else if (index == 2)
            Tint.GetComponent<Animator>().SetTrigger("Shop");
        else if (index == 3)
            Tint.GetComponent<Animator>().SetTrigger("Help");
    }
    public void gameStarted()
    {
        Starting.SetActive(false);
        Playing.SetActive(true);
    }
    public void CloseTint()
    {
        Tint.SetActive(false);

        Help.SetActive(false);
        Pause.SetActive(false);
        Buy.SetActive(false);
        Lost.SetActive(false);
    }
    public void OpenShopPanels(int index)
    {
        if(index == 0) //Coins
        {
            Buy.transform.GetChild(0).gameObject.SetActive(true);
            Buy.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if(index == 1) //Boosters
        {
            Buy.transform.GetChild(0).gameObject.SetActive(false);
            Buy.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void gamePaused(bool paused)
    {
        if(paused)
            StartCoroutine(pauseTheGame());
        else
            Time.timeScale = 1.0f;
    }
    IEnumerator pauseTheGame()
    {
        yield return new WaitForSeconds(0.25f);
        Time.timeScale = 0.0f;
    }
}
