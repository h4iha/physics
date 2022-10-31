using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleMove : MonoBehaviour
{
    public int index;
    private float speed = 30f;
    private Vector3 point;
    private void Start()
    {
        point = GameManager.instance.positionATransform[index].position;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
        if(transform.position == GameManager.instance.positionATransform[index].position)
            point = GameManager.instance.positionBTransform[index].position;
        if (transform.position == GameManager.instance.positionBTransform[index].position)
            point = GameManager.instance.positionATransform[index].position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.textMessageWinOrLose.gameObject.SetActive(true);
            GameManager.instance.textMessageWinOrLose.color = Color.red;
            GameManager.instance.ContentTextMessageWinOrLose("lose");
            GameManager.instance.ResetGameFunc();
        }
    }
}
