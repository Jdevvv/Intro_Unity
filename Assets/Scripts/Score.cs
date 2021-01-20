using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject score;
    public Text left;
    public Text right;
    private int left_score;
    private int right_score;

    public GameObject orange_girl;
    public GameObject blue_girl;
    public GameObject ballPrefab;
    public Vector3 orignal_pos_orange_girl;
    public Vector3 orignal_pos_blue_girl;
    public Vector3 orignal_pos_ballPrefab;

    public RigidbodyType2D bodyType;

    void Start()
    {
        score = GameObject.Find("Score");
        score.transform.position = new Vector3(10f / (float)Screen.width, 10f / (float)Screen.height, 0f);

        left = GameObject.Find("Left").GetComponent<Text>();
        left.text = "" + 0;
        right = GameObject.Find("Right").GetComponent<Text>();
        right.text = "" + 0;

        orange_girl = GameObject.Find("girl-2_0");
        blue_girl = GameObject.Find("girl-2_0_2");
        ballPrefab = GameObject.Find("ballPrefab");

        orignal_pos_ballPrefab = new Vector3(ballPrefab.transform.position.x, ballPrefab.transform.position.y, ballPrefab.transform.position.z);
        orignal_pos_orange_girl = new Vector3(orange_girl.transform.position.x, orange_girl.transform.position.y, orange_girl.transform.position.z);
        orignal_pos_blue_girl = new Vector3(blue_girl.transform.position.x, blue_girl.transform.position.y, blue_girl.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Left Goal" || col.gameObject.name == "Right Goal") {
            orange_girl.transform.position = orignal_pos_orange_girl;
            blue_girl.transform.position = orignal_pos_blue_girl;
            ballPrefab.transform.position = orignal_pos_ballPrefab;
            StartCoroutine(StopBallCoroutine(ballPrefab));
        }
        if (col.gameObject.name == "Left Goal")
        {
            left_score = left_score + 1;
            SetScoreText();
        }
        if (col.gameObject.name == "Right Goal")
        {
            right_score = right_score + 1;
            SetScoreText();
        }
    }

    void SetScoreText() {
        left.text= "" + left_score;
        right.text= "" + right_score;
    }

    IEnumerator StopBallCoroutine(GameObject ballPrefab)
    {
        ballPrefab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(2);   
        ballPrefab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}