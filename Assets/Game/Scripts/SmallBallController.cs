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
        
        if(amIBallObject)
            return;
        
        if (Input.GetMouseButton(0))
        {
            SendRay();
        }
    }
    
    

    private void SendRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.green);
            Debug.Log("Did Hit" + hit.transform.name);
        }
        
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.red);
            Debug.Log("Did not Hit");
        }
    }
}
