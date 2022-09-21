using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Symbol pointScript;
    
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(pointScript.playerScore.ToString());
    }
}
