using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    private int numberShows;
    //void Start()
    //{
    //    coroutineAllowed = true;
    //    numberShows = 5;
    //}

    //private void OnMouseDown()
    //{
    //    if (coroutineAllowed)
    //    {
    //        StartCoroutine("RotateWheel");
    //    }
    //}
    //private IEnumerator RotateWheel()
    //{
    //    coroutineAllowed = false;
    //    for (int i = 0; i <= 11; i++)
    //    {
    //        transform.Rotate(0f, 0f, -3f);
    //        yield return new WaitForSeconds(0.001f);
    //    }
    //    coroutineAllowed= true;
    //    numberShows += 1;
    //    if (numberShows>9)
    //    {
    //        numberShows = 0;
    //    }
    //    Rotated(name, numberShows);
    //}
}
