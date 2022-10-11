using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SmallBallManager : MonoBehaviour
{
    
    #region Instance

    public static SmallBallManager instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #endregion

    #region Lists

    [SerializeField] private List<Vector3> smallBallPositions = new List<Vector3>();
    [SerializeField] private List<SmallBallController> smallBalls = new List<SmallBallController>();

    #endregion

    #region Definitions

    [SerializeField] private SmallBallController smallBallController;
    [SerializeField] private GameObject smallBall;
    [SerializeField] private GameObject smallBallPrefab;

    #endregion
    
    void Start()
    {
        CreateSmallBalls();
    }


    void Update()
    {
        
    }

    private void CreateSmallBalls()
    {
        for (int i = 0; i < smallBallPositions.Count; i++)
        {
            smallBall = Instantiate(smallBallPrefab, transform);
            smallBall.transform.localPosition = smallBallPositions[i];
            smallBallController = smallBall.GetComponent<SmallBallController>();
            AddToSmallBallList(smallBallController);
        }

        SetSmallBall();
    }

    private void SetSmallBall()
    {
        smallBall = smallBalls[0].gameObject;
        
        smallBallController = smallBalls[0];
        
        smallBallController.amINextBall = true;
    }

    private void SortTheBalls()
    {
        for (int i = 0; i < smallBalls.Count; i++)
        {
            smallBalls[i].transform.localPosition = smallBallPositions[i];
        }
        
    }

    #region Add/Remove List

    private void AddToSmallBallList(SmallBallController ball)
    {
        smallBalls.Add(ball);
    }
    
    public void RemoveFromSmallBallList(SmallBallController ball)
    {
        smallBalls.Remove(ball);
        SortTheBalls();
        SetSmallBall();
    }

    #endregion

    
}
