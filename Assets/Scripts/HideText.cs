using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideText : MonoBehaviour
{
    [SerializeField] float timedelay = 1.5f;
    void Update()
    {
        if (gameObject.activeInHierarchy == true)
        {
            StartCoroutine(HideTextFunc());
        }

    }
    public IEnumerator HideTextFunc()
    {
        yield return new WaitForSeconds(timedelay);
        gameObject.SetActive(false);
        GameManager.instance.ContentTextMessageWinOrLose(null);
    }
}
