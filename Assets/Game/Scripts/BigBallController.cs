using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BigBallRotationModifier
{
    [SerializeField] public float speed;
    [SerializeField] public float time;
}

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

    [SerializeField] private List<BigBallRotationModifier> rotModifiers;
    
    [SerializeField] private float speed = 0;
    [SerializeField] private float time = 0;

    #endregion

    #region Fields

    public Transform ballPosition;

    #endregion

    #region LevelProcess

    public void SetLevel(List<BigBallRotationModifier> modifier)
    {
        rotModifiers = modifier;
    }

    #endregion

    #region Update

    private void Update()
    {
        if (GameManager.isGameEnded || !GameManager.isGameStarted)
            return;
        
        
        RotateTheBall();
    }


    #endregion

    #region RotateTheBall

    private void RotateTheBall()
    {
        transform.Rotate(Vector3.up, speed);
    }

    public void StartRotationMove()
    {
        StartCoroutine(RotationMove());
    }

    private int index = 0;
    private IEnumerator RotationMove()
    {
        while (true)
        {
            if (rotModifiers[index].time == 0)
            {
                while (true)
                {
                    speed = rotModifiers[index].speed;
                    yield return null;
                }
            }
            else
            {
                speed = rotModifiers[index].speed;
                yield return new WaitForSeconds(rotModifiers[index].time);
            }
            index += 1;
            
            if (index >= rotModifiers.Count)
            {
                index = 0;
            }
        }
    }

    #endregion
   
}
