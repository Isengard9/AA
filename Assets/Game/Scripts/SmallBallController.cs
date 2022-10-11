using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBallController : MonoBehaviour
{

    #region Definitions

    [SerializeField] private bool amIBallObject = false;

    #endregion

    #region Tools

    [SerializeField] private LineRenderer lineRenderer;

    #endregion
    
    void Start()
    {
        if (amIBallObject)
            lineRenderer.enabled = true;
    }


    void Update()
    {
        if (GameManager.isGameEnded || !GameManager.isGameStarted)
            return;
        
        
    }
    
    

    private void SetLineOnTrack()
    {
        
    }
}
