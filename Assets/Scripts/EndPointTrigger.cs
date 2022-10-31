using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrigger : MonoBehaviour
{
    [SerializeField] Text textMessage;
    [SerializeField] GameObject keyPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            GameManager.instance.textMessageWinOrLose.gameObject.SetActive(true);
            GameManager.instance.textMessageWinOrLose.color = Color.green;
            GameManager.instance.ContentTextMessageWinOrLose("win");
            GameManager.instance.ResetGameFunc();
        }
    }
}
