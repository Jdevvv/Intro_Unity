using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addBall : MonoBehaviour
{
    public GameObject ballPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var instance = Instantiate(ballPrefab);
            instance.transform.position = Vector3.zero;
            instance.GetComponent<AnimatedBall>().Speed = Random.Range(0.2f, 5f);
        }
    }
}
