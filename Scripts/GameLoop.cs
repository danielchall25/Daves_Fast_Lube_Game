using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public static GameLoop inst;
    public int startingCash = 3000;
    public int availableCash;
    private int newFunds;
    public int changeInFunds;
    private int rent = 750;
    public int consumables = 0;

    // Start is called before the first frame update
    void Start()
    {
        inst = this;
        availableCash = startingCash;
        newFunds = availableCash;
    }

    // Update is called once per frame
    void Update()
    {
        updateRent();
        if(availableCash != newFunds)
        {
            changeInFunds = (availableCash - newFunds);
            UIMGR.inst.showFundsChange();
            newFunds = availableCash;
        }
    }

    public void getMoney()
    {
        availableCash += 500;
        consumables--;
    }

    public void payRent() {
        availableCash -= rent;
    }

    public void updateRent()
    {
        if (NewBehaviourScript.inst.shopLevel > 0)
        {
            rent = 750 + (250 * (NewBehaviourScript.inst.shopLevel - 1));
        }
    }

    public void buyBay()
    {
        availableCash -= (NewBehaviourScript.inst.shopLevel - 1) * 250 + 750;
    }

    public void buyConsumables()
    {
        consumables += 5;
        availableCash -= 250;
    }
}
    