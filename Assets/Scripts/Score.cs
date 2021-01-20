using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public GameObject orange_girl;
    public GameObject blue_girl;
    public GameObject ballPrefab;
    public Vector3 orignal_pos_orange_girl;
    public Vector3 orignal_pos_blue_girl;
    public Vector3 orignal_pos_ballPrefab;

    void Start()
    {
        orange_girl = GameObject.Find("girl-2_0");
        blue_girl = GameObject.Find("girl-2_0_2");
        ballPrefab = GameObject.Find("ballPrefab");
        orignal_pos_ballPrefab = new Vector3(ballPrefab.transform.position.x, ballPrefab.transform.position.y, ballPrefab.transform.position.z);
        orignal_pos_orange_girl = new Vector3(orange_girl.transform.position.x, orange_girl.transform.position.y, orange_girl.transform.position.z);
        orignal_pos_blue_girl = new Vector3(blue_girl.transform.position.x, blue_girl.transform.position.y, blue_girl.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "ballPrefab")
        {
            if (gameObject.name == "Left Goal" || gameObject.name == "Right Goal") {
                orange_girl.transform.position = orignal_pos_orange_girl;
                blue_girl.transform.position = orignal_pos_blue_girl;
                ballPrefab.transform.position = orignal_pos_ballPrefab;
            }
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