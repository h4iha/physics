using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPointTrigger : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.endPointGO.gameObject.SetActive(false);
        GameManager.instance.textTookKey.gameObject.SetActive(false);
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        GameManager.instance.keyGO.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.textTookKey.gameObject.SetActive(true);
            GameManager.instance.endPointGO.SetActive(true);
            GameManager.instance.keyGO.gameObject.SetActive(false);
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
            this.gameObject.GetComponent<KeyPointTrigger>().enabled = false;
        }
    }
}