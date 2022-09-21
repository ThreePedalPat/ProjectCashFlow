using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    public int playerScore;
    public int bnaScore = 10;
    public int strawScore = 20;
    public int orangeScore = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 100; // for test purposes ONLY! Would correlate to money put into the game. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BnaScoreUpdate()
    {
        playerScore += bnaScore;
    }
    public void StrawScoreUpdate()
    {
        playerScore += strawScore;
    }
    public void OrangeScoreUpdate()
    {
        playerScore += orangeScore;
    }
    public void PayBetCost()
    {
        playerScore -= 20;
    }
}
