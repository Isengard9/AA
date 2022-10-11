using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallController : MonoBehaviour
{

    #region Instance

    public static BigBallController instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #endregion

    #region BaseStats

    [SerializeField] private float speed = 0;

    #endregion

    #region Fields

    public Transform ballPosition;

    #endregion
    
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
        transform.Rotate(Vector3.up, speed);
    }
}
