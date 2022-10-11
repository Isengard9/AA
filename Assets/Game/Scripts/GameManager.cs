using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Instance

    public static GameManager instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #endregion

    #region Bools

    public static bool isGameStarted = false;
    public static bool isGameEnded = false;

    #endregion
   
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
