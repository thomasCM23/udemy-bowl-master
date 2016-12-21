using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private List<int> bowls = new List<int>();
    private ScoreDisplay scoreDisplay;
    private PinSetter pinSetter;
    private Ball ball;
	// Use this for initialization
	void Start ()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void Bowl(int pinFall)
    {
        try
        {
            bowls.Add(pinFall);
            ball.Reset();
            pinSetter.PreformAction(ActionMaster.NextAction(bowls));
        }
        catch
        {
            Debug.LogWarning("Something when wrong in Game Manager Bowl()");
        }
        try
        {
            scoreDisplay.FillRollCard(bowls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(bowls));
        }
        catch
        {
            Debug.LogWarning("fill roll card failed ");
        }
    }
}
