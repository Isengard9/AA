using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SmallBallController : MonoBehaviour
{

    #region Definitions

    public bool amINextBall = false;
    [SerializeField] private bool amIBallObject = false;

    private Transform bigBall;
    private Vector3 ballPosition;

    #endregion

    #region Tools

    [SerializeField] private LineRenderer lineRenderer;

    #endregion

    #region Start

    private void Start()
    {
        if (amIBallObject)
            lineRenderer.enabled = true;

        bigBall = BigBallController.instance.transform;
        ballPosition = BigBallController.instance.ballPosition.position;
    }

    #endregion
    
    #region Update

    private void Update()
    {
        if (GameManager.isGameEnded || !GameManager.isGameStarted)
            return;
        
        if(amIBallObject)
            return;
        
        if(!amINextBall)
            return;
        
        if (Input.GetMouseButton(0))
        {
            SendRay();
        }
    }

    #endregion
    
    #region SendRay

    private void SendRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.green);
            
            MoveToBigBall();
            
            if (hit.transform.CompareTag("BigBall"))
            {
                //success
            }
            else if (hit.transform.CompareTag("SmallBall"))
            {
                //fail
            }
        }
        
    }

    #endregion

    #region MoveToBigBall

    private void MoveToBigBall()
    {
        transform.DOMove(ballPosition, 0.2f)
            .OnComplete(() =>
            {
                transform.LookAt(bigBall);
                lineRenderer.enabled = true;
                SmallBallManager.instance.RemoveFromSmallBallList(this);
            });
        
        transform.parent = bigBall;
        amIBallObject = true;
        
    }

    #endregion

    #region OnTrigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("SmallBall"))
        {
            Debug.Log("test: small ball touch");
            GameManager.instance.OnLevelFailed();
        }
    }

    #endregion
    
}
