using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallController : MonoBehaviour
{

    [SerializeField] private float speed = 0;
    void Start()
    {
        
    }


    void Update()
    {
        if (GameManager.isGameEnded || !GameManager.isGameStarted)
            return;
        
        
        RotateTheBall();
    }

    private void RotateTheBall()
    {
        transform.Rotate(Vector3.forward, speed);
    }
}