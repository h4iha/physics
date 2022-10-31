using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class PinkSwim : MonoBehaviour
{
    private bool isWandering = false;
    private bool isSwimming = false;
    private bool isTurnLeft = false;
    private bool isTurnRight = false;

    
    public int index;
    private float maxSpeed;
    private float startSpeed;
    private float swimTime;
    private float rotTime;

    private bool timeWaitBool;
    private float timeWait;
    private void Awake()
    {
        index = transform.GetSiblingIndex();
        startSpeed = GameScarpManager.instance.pinkKois[index].swimSpeed;
        maxSpeed = 3;
        swimTime = 0;
        rotTime = 0;
    }
    void Update()
    {
        Swim();
    }
    public IEnumerator BoostSpeed()
    {
        GameScarpManager.instance.pinkKois[index].swimSpeed = maxSpeed;
        yield return new WaitForSeconds(2f);
        GameScarpManager.instance.pinkKois[index].swimSpeed = startSpeed;
    }

    void Swim()
    {
        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        RaycastHit hit;
        if (isWandering == false)
        {
            isWandering = true;
            isSwimming = true;
        }
        else
        {
            if (isSwimming == true)
            {
                swimTime += Time.deltaTime;
            }
            if (isTurnLeft == true || isTurnRight == true)
            {
                rotTime += Time.deltaTime;
                //Debug.Log(rotTime + "IsTurn" + isTurnRight);
            }
            if (isSwimming == true)
            {
                gameObject.GetComponent<Animator>().SetBool("IsSwimming", true);
                transform.position += transform.forward * GameScarpManager.instance.pinkKois[index].swimSpeed * Time.deltaTime;
                float swimWait = UnityEngine.Random.Range(2, 5);
                Debug.DrawRay(transform.position, transform.forward * 3, Color.green);
                if (Physics.Raycast(transform.position, transform.forward * 3, out hit, 1f, LayerMask.GetMask("Walls")))
                {
                    int rd = UnityEngine.Random.Range(0, 2);
                    if (rd == 0)
                        transform.Rotate(new Vector3(0, UnityEngine.Random.Range(-90, -180), 0));
                    else
                        transform.Rotate(new Vector3(0, UnityEngine.Random.Range(90, 180), 0));
                }
                if (swimTime >= swimWait)
                {
                    swimTime = 0;
                    int rd = UnityEngine.Random.Range(0, 2);
                    if (rd == 0)
                        isTurnRight = true;
                    else
                        isTurnLeft = true;
                }
            }
            TurnLoRFunc();
            OffTurnFunc();
        }

    }

    void TurnLoRFunc()
    {
        if (isTurnRight == true && isTurnLeft == false)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * GameScarpManager.instance.pinkKois[index].rotSpeed);
            //Debug.Log("IsTurn" + isTurnRight);
        }
        if (isTurnRight == false && isTurnLeft == true)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * GameScarpManager.instance.pinkKois[index].rotSpeed);
            //Debug.Log("IsTurn" + isTurnRight);
        }
    }

    void OffTurnFunc()
    {
        if (rotTime > 2)
        {
            isTurnRight = false;
            isTurnLeft = false;
            rotTime = 0;
        }
    }
}
//    IEnumerator Wander()
//    {
//        int rotateTime = Random.Range(1, 3);
//        int rotateWait = Random.Range(1, 2);
//        int rotateLorR = Random.Range(1, 2);
//        int swimmingTime = Random.Range(3, 5);

//        isWandering = true;
//        yield return new WaitForSeconds(.5f);
//        isSwimming = true;
//        yield return new WaitForSeconds(swimmingTime);
//        isSwimming = false;

//        if (rotateLorR == 1)
//        {
//            isTurnLeft = true;
//            yield return new WaitForSeconds(rotateTime);
//            isTurnLeft = false;
//        }
//        if (rotateLorR == 2)
//        {
//            isTurnRight = true;
//            yield return new WaitForSeconds(rotateTime);
//            isTurnRight = false;
//        }
//        isWandering = false;
//    }
