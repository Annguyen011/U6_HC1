using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static Color oneColor;
    public GameObject ball;

    private float speed = 100;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HitBall();
        }
    }

    private void HitBall()
    {
        GameObject gameObject = Instantiate<GameObject>(ball, new Vector3(0,0,-8),Quaternion.identity);
        gameObject.GetComponent<MeshRenderer>().material.color = oneColor;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Force);
    }
}
