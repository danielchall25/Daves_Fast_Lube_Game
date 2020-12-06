using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{

    public static Calendar inst;

    private string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    private int currentMonth = 0;
    private int day = 0;
    private int year = 2020;
    public string date;
    public float waitTime = .5f;
    float timeToGo;

    private void Start()
    {
        inst = this;
        date = (day + 1) + " " + months[currentMonth] + " " + year; 
        timeToGo = Time.fixedTime + waitTime;
    }

    private void FixedUpdate()
    {
        if(Time.fixedTime >= timeToGo)
        {
            updateDate();
            timeToGo = Time.fixedTime + waitTime;
        }
    }

    public void updateDate()
    {
        day++;
        switch (currentMonth)
        {
            case 1:
                if (day > 28)
                {
                    currentMonth++;
                    day = 1;
                    GameLoop.inst.payRent();
                }
                break;
            case 3:
            case 5:
            case 8:
            case 10:
                if (day > 30)
                {
                    currentMonth++;
                    day = 1;
                    GameLoop.inst.payRent();
                }
                break;
            default:
                if(day > 31)
                {
                    currentMonth++;
                    if(currentMonth > 11)
                    {
                        currentMonth = 0;
                        year++;
                    }
                    day = 1;
                    GameLoop.inst.payRent();
                }
                break;
        }

        date = day + " " + months[currentMonth] + " " + year;
    }
}
