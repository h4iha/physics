using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComeTarget : MonoBehaviour
{
    public Vector3 pointTarget;
    private float tempspeed;

    void Start()
    {
        tempspeed = GameManager.instance.speedPlayer;
        pointTarget = new Vector3(GameManager.instance.keyPointGO.transform.position.x, GameManager.instance.playerGO.transform.position.y, GameManager.instance.keyPointGO.transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointTarget, GameManager.instance.speedPlayer * Time.deltaTime);
        if (GameManager.instance.keyGO.activeInHierarchy == true)
        {
            pointTarget = new Vector3(GameManager.instance.keyPointGO.transform.position.x, GameManager.instance.playerGO.transform.position.y, GameManager.instance.keyPointGO.transform.position.z);
            MultiRaycast(true, LayerMask.GetMask("ObstacleOrange"));
        }
        if (GameManager.instance.endPointGO.activeInHierarchy == true)
        {
            pointTarget = new Vector3(GameManager.instance.endPointGO.transform.position.x, GameManager.instance.playerGO.transform.position.y, GameManager.instance.endPointGO.transform.position.z);
            MultiRaycast(false, LayerMask.GetMask("ObstacleYellow"));
        }
    }

    void MultiRaycast(bool isXminus, LayerMask ignoreObjectMask)
    {
        RaycastHit hit;
        float x;
        for (float z = - GameManager.instance.distanceRaycastPlayer / 5 * 4; z <= GameManager.instance.distanceRaycastPlayer / 5 * 4; z += GameManager.instance.distanceRaycastPlayer / 4)
        {
            x = (float)Math.Sqrt(GameManager.instance.distanceRaycastPlayer * GameManager.instance.distanceRaycastPlayer - z * z);
            Vector3 dir = isXminus ? XMinus(x, z) : ZMinus(x, z);
            Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), dir, Color.green);
            if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), dir, out hit, GameManager.instance.distanceRaycastPlayer, ignoreObjectMask))
            {
                GameManager.instance.speedPlayer = 0;
                return;
            }
        }
        GameManager.instance.speedPlayer = tempspeed;
    }

    #region Z, X Vector
    Vector3 XMinus(float a, float b)
    {
        return new Vector3(-a, 0, b);
    }
    Vector3 ZMinus(float a, float b)
    {
        return new Vector3(b, 0, -a);
    }
    Vector3 XPlus(float a, float b)
    {
        return new Vector3(a, 0, b);
    }
    Vector3 ZPlus(float a, float b)
    {
        return new Vector3(b, 0, a);
    }
    #endregion
}
