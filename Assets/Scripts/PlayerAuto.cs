using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAuto : MonoBehaviour
{
    public Vector3 pointTarget;
    private float tempspeed;

    void Start()
    {
        tempspeed = GameManager.instance.speedPlayer;
        pointTarget = RandomPointFunc(UnityEngine.Random.Range(0, 3));
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(pointTarget.x, transform.position.y, pointTarget.z), GameManager.instance.speedPlayer * Time.deltaTime);
        transform.LookAt(new Vector3(0, pointTarget.y, 0));
        if (transform.position == new Vector3(GameManager.instance.spawnPointGO.transform.position.x, 3.1f, GameManager.instance.spawnPointGO.transform.position.z))
        {
            pointTarget = RandomPointFunc(UnityEngine.Random.Range(0, 3));
        }
        if (GameManager.instance.keyGO.activeInHierarchy == false)
        {
            if (Vector3.Distance(pointTarget, transform.position) < 0.5)
            {
                pointTarget = RandomPointFunc(UnityEngine.Random.Range(0, 3));
            }
            if (Vector3.Distance(pointTarget, transform.position) < 10)
            {
                pointTarget = RandomPointFunc(UnityEngine.Random.Range(0, 3));
                pointTarget = new Vector3(GameManager.instance.keyPointGO.transform.position.x, GameManager.instance.playerGO.transform.position.y, GameManager.instance.keyPointGO.transform.position.z);
            }
        }
        if (GameManager.instance.endPointGO.activeInHierarchy == true)
        {
            if (Vector3.Distance(pointTarget, transform.position) < 0.5f)
            {
                pointTarget = RandomPointFunc(UnityEngine.Random.Range(0, 3));
            }
            if (Vector3.Distance(pointTarget, transform.position) < 10)
            {
                pointTarget = RandomPointFunc(UnityEngine.Random.Range(0, 3));
                pointTarget = new Vector3(GameManager.instance.endPointGO.transform.position.x, GameManager.instance.playerGO.transform.position.y, GameManager.instance.endPointGO.transform.position.z);
            }
        }
        MultiRaycastFunc(LayerMask.GetMask("ObstacleOrange"), 10);
        MultiRaycastFunc(LayerMask.GetMask("ObstacleYellow"), 10);

    }
    Vector3 RandomPointFunc(int index)
    {
        if (index == 0)
        {
            if(transform.position.x + 20 > 50)
                return new Vector3(49, transform.position.y, transform.position.z + 0);
            return new Vector3(transform.position.x + 20, transform.position.y, transform.position.z + 0);
        }
        if (index == 1)
        {
            if (transform.position.z + 20 > 50)
                return new Vector3(transform.position.x + 0, transform.position.y, 49);
            return new Vector3(transform.position.x + 0, transform.position.y, transform.position.z + 20);
        }
            
        if (index == 2)
        {
            if (transform.position.x - 20 < -50)
                return new Vector3(-49, transform.position.y, transform.position.z + 0);
            return new Vector3(transform.position.x - 20, transform.position.y, transform.position.z + 0);
        }
        else
        {
            if (transform.position.z - 20 < -50)
                return new Vector3(transform.position.x + 0, transform.position.y, -49);
            return new Vector3(transform.position.x + 0, transform.position.y, transform.position.z - 20);
        }
    }

    void MultiRaycastFunc(LayerMask ignoreObjectMask,float distance)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), this.transform.forward * distance, out hit, distance, ignoreObjectMask))
        {
            GameManager.instance.speedPlayer = 0;
            return;
        }
        GameManager.instance.speedPlayer = tempspeed;
    }
}
