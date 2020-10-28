using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public GameObject orange_girl;
    public GameObject blue_girl;

    // Start is called before the first frame update
    void Start()
    {
        orange_girl = GameObject.Find("girl-2_0");
        blue_girl = GameObject.Find("girl-2_0_2");
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "ballPrefab")
        {
            if (gameObject.name == "Left Goal")
            {
                Debug.Log("Left goal");

            }
            if (gameObject.name == "Right Goal")
            {
                Debug.Log("Right goal");
            }
        }
        Debug.Log(col.gameObject.name + " : " + gameObject.name);
    }

}