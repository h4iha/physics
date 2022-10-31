using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player")]
    public GameObject playerGO;
    public float speedPlayer;
    public float distanceRaycastPlayer;
    [Header("Obstacles")]
    public GameObject[] obstaclesGO;
    public Color[] colorsObstacle;

    [Header("Obstacles Position A + B")]
    public Transform[] positionATransform;
    public Transform[] positionBTransform;

    [Header("Main Event")]
    public GameObject spawnPointGO;
    public GameObject keyPointGO;
    public GameObject keyGO;
    public GameObject endPointGO;

    [Header("Text")]
    public Text textMessageWinOrLose;
    public Text textTookKey;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ContentTextMessageWinOrLose(string index)
    {
        if (index == "win")
        {
            textMessageWinOrLose.text = "Win Game";
            textMessageWinOrLose.color = Color.green;
            return;
        }
        if (index == "lose")
        {
            textMessageWinOrLose.text = "Lose Game";
            textMessageWinOrLose.color = Color.red;
            return;
        }
        textMessageWinOrLose.text = "Start Game";
        textMessageWinOrLose.color = Color.white;

    }
    public void ResetGameFunc()
    {
        //Spawn Point
        playerGO.transform.position = new Vector3(spawnPointGO.transform.position.x, 3.1f, spawnPointGO.transform.position.z);
        keyPointGO.GetComponent<KeyPointTrigger>().enabled = true;
        keyPointGO.GetComponent<BoxCollider>().enabled = true;

        //Key Point
        textTookKey.gameObject.SetActive(false);
        keyPointGO.gameObject.GetComponent<Renderer>().material.color = Color.green;
        keyGO.SetActive(true);

        //End Point
        endPointGO.gameObject.SetActive(false);
    }
}
