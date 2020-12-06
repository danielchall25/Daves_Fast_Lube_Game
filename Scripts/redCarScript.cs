using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCarScript : MonoBehaviour
{

    // put the points from unity interface
    public Transform[] wayPointList;
    public Transform[] trip = new Transform[8];
    public GameObject[] skins;
    public bool stop = false;
    public static redCarScript inst;
    public bool turnFlag = false;
    public int bay;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 2f;
    void Start()
    {
        inst = this;
        trip[0] = wayPointList[0];
        trip[1] = wayPointList[1];
        trip[2] = wayPointList[8];
        trip[3] = wayPointList[9];
        trip[4] = wayPointList[8];
        trip[5] = wayPointList[9];
        trip[6] = wayPointList[10];
        trip[7] = wayPointList[10];
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == trip[0].position)
        {
            Debug.Log("One");
            if (NewBehaviourScript.inst.openBay[0])
            {
                DockBayOne();
            }
            else if (NewBehaviourScript.inst.openBay[1])
            {
                DockBayTwo();
            }
            else if (NewBehaviourScript.inst.openBay[2])
            {
                DockBayThree();
            }
            else
            {
                ResetRoute();
            }
        }

        if (transform.position == wayPointList[6].position || transform.position == wayPointList[4].position || transform.position == wayPointList[2].position)
        {
            turn();
        }

        if (transform.position == trip[4].position)
        {
            if (turnFlag)
            {
                straight();
            }
            turnFlag = !turnFlag;
        }



        // check if we have somewere to walk
        if (currentWayPoint < this.trip.Length && !stop)
        {
            if (targetWayPoint == null)
                targetWayPoint = trip[currentWayPoint];
            walk();
        }
        if (currentWayPoint == this.trip.Length - 1)
        {
            currentWayPoint = -1;
        }


        if (transform.position == wayPointList[7].position || transform.position == wayPointList[5].position || transform.position == wayPointList[3].position)
        {
            if (!stop)
            {
                carStop();
                StartCoroutine(NewBehaviourScript.inst.showCollect(bay));
            }
        }
    }

    void walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            targetWayPoint = trip[currentWayPoint];
        }
    }

    public void carStop()
    {
        stop = true;
    }
    public void carMove()
    {
        if (GameLoop.inst.consumables >= 1)
        {
            stop = false;
            GameLoop.inst.getMoney();
            NewBehaviourScript.inst.unshowCollect(bay);
            NewBehaviourScript.inst.openBay[bay] = true;
        }

    }

    public void DockBayOne()
    {
        NewBehaviourScript.inst.openBay[0] = false;
        bay = 0;
        trip[2] = wayPointList[2];
        trip[3] = wayPointList[3];
        trip[4] = wayPointList[2];
        trip[5] = wayPointList[8];
        trip[6] = wayPointList[9];
        trip[7] = wayPointList[10];
    }

    public void DockBayTwo()
    {
        NewBehaviourScript.inst.openBay[1] = false;
        bay = 1;
        trip[2] = wayPointList[4];
        trip[3] = wayPointList[5];
        trip[4] = wayPointList[4];
        trip[5] = wayPointList[8];
        trip[6] = wayPointList[9];
        trip[7] = wayPointList[10];
    }

    public void DockBayThree()
    {
        NewBehaviourScript.inst.openBay[2] = false;
        bay = 2;
        trip[2] = wayPointList[6];
        trip[3] = wayPointList[7];
        trip[4] = wayPointList[6];
        trip[5] = wayPointList[8];
        trip[6] = wayPointList[9];
        trip[7] = wayPointList[10];
    }

    public void ResetRoute()
    {
        trip[0] = wayPointList[0];
        trip[1] = wayPointList[1];
        trip[2] = wayPointList[8];
        trip[3] = wayPointList[9];
        trip[4] = wayPointList[8];
        trip[5] = wayPointList[9];
        trip[6] = wayPointList[10];
        trip[7] = wayPointList[10];
    }

    public void turn()
    {
        skins[0].SetActive(false);
        skins[1].SetActive(true);
    }

    public void straight()
    {
        skins[0].SetActive(true);
        skins[1].SetActive(false);
    }
}

