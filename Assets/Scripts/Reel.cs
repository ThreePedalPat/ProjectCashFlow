using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{

    public Transform resetPoint;
    public Transform startingPoint;
    public Vector3 minStrawPoint;
    public Vector3 maxStrawPoint;
    public Vector3 minBnaPoint;
    public Vector3 maxBnaPoint;
    public Vector3 minOrangePoint;
    public Vector3 maxOrangePoint;
    public Vector3 myTransform;
    public bool spinning;
    public float spinTimeLeft;
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
        if (Input.GetKeyDown(KeyCode.Space) && spinTimeLeft <= 0 && pointScript.playerScore >= 20)
        {
            pointScript.playerScore -= 20;
            chanceFactor = Random.Range(1, 60);
            spinTimeLeft = 1.0f;
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
        if (chanceFactor <= 30) //Highest chance: Banana
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

        if (chanceFactor <= 50 && chanceFactor > 30) //Medium chance: Strawberry
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

        if (chanceFactor <= 60 && chanceFactor > 50) //Lowest chance: Orange
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
