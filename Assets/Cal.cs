using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Cal : MonoBehaviour
{
    public int n;
    public List<int> indexs = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        n = 1300470;
        indexs.Clear();
        Debug.Log(n);
    }
    public void calLeft()
    {
        //Left
        indexs.Clear();
        getIndexLeft();
        foreach (int i in indexs)
        {
            Debug.Log(i);
        }
    }
    public void calRight()
    {
        //Right
        indexs.Clear();
        getIndexRight();
        foreach (int i in indexs)
        {
            Debug.Log(i);
        }
    }
    #region Left
        private void getIndexLeft()
        {
            int count = (int) Math.Floor(Math.Log10(n));
            indexs.Clear();
            do
            {
                indexs.Add(n / (int)Math.Pow(10, count));
                if (count == (int) Math.Floor(Math.Log10(n)))
                {
                    n = n % (int)Math.Pow(10, count);
                }
                count--;
            }
            while (count > -1);
        }
    #endregion
    #region Right

    private void getIndexRight()
    {
        indexs.Clear();
        do
        {
            n /= 10;
            indexs.Add(n % 10);
        }
        while (n > 0);
    }
    #endregion
}
