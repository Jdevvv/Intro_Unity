﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{

    public GameObject Target;

    public Vector2 DeadWindow;
    public int FollowSpeed = 1;
    private Rect _rect;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_rect.center, _rect.size);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        _rect = new Rect((Vector2)transform.position - DeadWindow * 0.5f, DeadWindow);
        if (!_rect.Contains(Target.transform.position))
        {
            var z = transform.position.z;
            var nextPos = Vector3.Lerp(transform.position, Target.transform.position, 0.02f);
            nextPos.z = z;
            transform.position = nextPos;
        }
    }
}
