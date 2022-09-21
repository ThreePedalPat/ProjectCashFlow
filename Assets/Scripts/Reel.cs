using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{

    public int minRandomRange = 1; //chance factor roll minimum 
    public int maxRandomRange = 60; //chance factor roll maximum
    public int bnaChanceMax = 30; // any roll under this will be banana
    public int strawChanceMax = 50; // under this & over banana will be strawberry

    public Transform resetPoint;
    public Transform startingPoint;

    //Min & Max transforms to make sure the reel stops on a symbol
    public Vector3 minStrawPoint;
    public Vector3 maxStrawPoint;
    public Vector3 minBnaPoint;
    public Vector3 maxBnaPoint; 
    public Vector3 minOrangePoint; 
    public Vector3 maxOrangePoint;
    private Vector3 myTransform;

    private bool spinning;

    private float spinTimeLeft;
    public float maxSpinTime = 1;
    public float chanceFactor;

    public Symbol pointScript;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myTransform;


        if (spinTimeLeft > 0)
        {
            DecrementSpinTime();
        }

        //watch for key press and set spin time
        if (Input.GetKeyDown(KeyCode.Space) && spinTimeLeft <= 0 && pointScript.playerScore >= pointScript.betCost)
        {
            pointScript.PayBetCost();
            chanceFactor = Random.Range(minRandomRange, maxRandomRange);
            spinTimeLeft = maxSpinTime;
            spinning = true;
        }

        if(spinning)
        {
            Spin(spinTimeLeft, chanceFactor);
        }
    }

    void Spin(float spinTime, float chanceFactor)
    {
        //Must run out spin time and reel must be at a valid point to stop
        if (chanceFactor <= bnaChanceMax) //Highest chance: Banana
        {
            if (myTransform.y < resetPoint.position.y && spinning)
            {
                myTransform.y += 0.1f;
            }
            else if (myTransform.y >= resetPoint.position.y)
            {
                myTransform.y = startingPoint.position.y;
            }
            if (spinTimeLeft <= 0 && myTransform.y <= maxBnaPoint.y && myTransform.y >= minBnaPoint.y)
            {
                spinning = false;
                pointScript.BnaScoreUpdate();
            }
        }

        if (chanceFactor <= strawChanceMax && chanceFactor > bnaChanceMax + 1) //Medium chance: Strawberry
        {
            if (myTransform.y < resetPoint.position.y && spinning)
            {
                myTransform.y += 0.1f;
            }
            else if (myTransform.y >= resetPoint.position.y)
            {
                myTransform.y = startingPoint.position.y;
            }
            if (spinTimeLeft <= 0 && myTransform.y <= maxStrawPoint.y && myTransform.y >= minStrawPoint.y)
            {
                spinning = false;
                pointScript.StrawScoreUpdate();
            }
        }

        if (chanceFactor <= maxRandomRange && chanceFactor > strawChanceMax + 1) //Lowest chance: Orange
        {
            if (myTransform.y < resetPoint.position.y && spinning)
            {
                myTransform.y += 0.1f;
            }
            else if (myTransform.y >= resetPoint.position.y)
            {
                myTransform.y = startingPoint.position.y;
            }
            if (spinTimeLeft <= 0 && myTransform.y <= maxOrangePoint.y && myTransform.y >= minOrangePoint.y)
            {
                spinning = false;
                pointScript.OrangeScoreUpdate();
            }
        }

    }

    void DecrementSpinTime()
    {
        spinTimeLeft -= Time.deltaTime;
    }
}
