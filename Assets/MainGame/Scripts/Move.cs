﻿using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public Vector3 movementSpeed;
    public Space space;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
