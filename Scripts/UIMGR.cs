using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMGR : MonoBehaviour
{
    //Text objects for UI updates
    public Text availableCash;
    public Text availableConsumables;
    public Text date;
    public Text shopLevel;
    public Text fundsChange;
    public static UIMGR inst;
    private float timeToGo;

    //Mause menu
    public GameObject pauseMenu;
    public GameObject fundsChangeButtton;
    

    // Start is called before the first frame update
    void Start()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameLoop.inst.changeInFunds > 0)
        {
            fundsChange.color = Color.green;
        } else
        {
            fundsChange.color = Color.red;
        }
        availableCash.text = GameLoop.inst.availableCash.ToString();
        availableConsumables.text = GameLoop.inst.consumables.ToString();
        shopLevel.text = NewBehaviourScript.inst.shopLevel.ToString();
        fundsChange.text = GameLoop.inst.changeInFunds.ToString();
        date.text = Calendar.inst.date.ToString();

        if (Time.fixedTime >= timeToGo)
        {
            fundsChangeButtton.SetActive(false);
        }
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void showFundsChange()
    {
        timeToGo = Time.fixedTime + 1.5f;
        fundsChangeButtton.SetActive(true);
    }
}
