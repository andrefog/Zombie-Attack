using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject goPlayer;
    private Vector3 distance;

    void Start()
    {
        distance = transform.position - goPlayer.transform.position;
    }

    void Update()
    {
        transform.position = goPlayer.transform.position + distance;
    }
}
