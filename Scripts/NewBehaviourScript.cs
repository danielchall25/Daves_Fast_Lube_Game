using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] shopAdditions;
    public GameObject[] collections;
    private bool buyBay;
    public bool[] openBay = new bool[3];
    public GameObject brokeText;
    public static NewBehaviourScript inst;
    public int shopLevel = 0;


    void Start()
    {
        inst = this;
        openBay[0] = false;
        openBay[1] = false;
        openBay[2] = false;
        buyBay = false;
    }

    void Update()
    {
        if(buyBay)
        {
            openBay[shopLevel - 1] = true;
        }
        buyBay = false;
    }

    //This is a test to link C# to unity to test shop upgrade mechanics
    public void buttonPress()
    {
        if (GameLoop.inst.availableCash >= 1000)
        {
            brokeText.SetActive(false);
            buyBay = true;
            if (shopLevel < 5)
            {
                if (shopLevel < 4)
                {
                    shopAdditions[shopLevel++].SetActive(true);
                    GameLoop.inst.buyBay();
                }
            }
        } else
        {
            brokeText.SetActive(true);
        }
    }

    public IEnumerator showCollect(int num)
    {
        yield return new WaitForSeconds(5f);

        collections[num].SetActive(true);
    }

    public void unshowCollect(int num)
    {
        collections[num].SetActive(false);
    }

    // add each car below as hey are completed
    public void finishVehicleOne()
    {
        if(greenCarScript.inst.stop == true && greenCarScript.inst.bay == 0)
        {
            greenCarScript.inst.carMove();
        }
        if (blueCarScript.inst.stop == true && blueCarScript.inst.bay == 0)
        {
            blueCarScript.inst.carMove();
        }
        if (redCarScript.inst.stop == true && redCarScript.inst.bay == 0)
        {
            redCarScript.inst.carMove();
        }

        //openBay[0] = true;
    }

    public void finishVehicleTwo()
    {
        if (greenCarScript.inst.stop == true && greenCarScript.inst.bay == 1)
        {
            greenCarScript.inst.carMove();
        }
        if (blueCarScript.inst.stop == true && blueCarScript.inst.bay == 1)
        {
            blueCarScript.inst.carMove();
        }
        if (redCarScript.inst.stop == true && redCarScript.inst.bay == 1)
        {
            redCarScript.inst.carMove();
        }
        //openBay[1] = true;
    }

    public void finishVehicleThree()
    {
        if (greenCarScript.inst.stop == true && greenCarScript.inst.bay == 2)
        {
            greenCarScript.inst.carMove();
        }
        if (blueCarScript.inst.stop == true && blueCarScript.inst.bay == 2)
        {
            blueCarScript.inst.carMove();
        }
        if (redCarScript.inst.stop == true && redCarScript.inst.bay == 2)
        {
            redCarScript.inst.carMove();
        }

        //openBay[2] = true;
    }
}
