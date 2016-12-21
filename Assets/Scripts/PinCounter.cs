using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private bool ballEnteredBox = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private GameManager gameManager;
    // Use this for initialization
    void Start ()
    {
        standingDisplay.color = Color.green;
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        standingDisplay.text = CountingStanding().ToString();
        if (ballEnteredBox)
        {
            CheckStanding();
            standingDisplay.color = Color.red;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Ball")
        {
            ballEnteredBox = true;
        }
    }
    void CheckStanding()
    {
        int currentStanding = CountingStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }
    void PinsHaveSettled()
    {

        int standing = CountingStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        gameManager.Bowl(pinFall);
        standingDisplay.color = Color.green;
        lastStandingCount = -1;
        ballEnteredBox = false;
    }
    public void Reset()
    {
        lastSettledCount = 10;
    }
    
    public int CountingStanding()
    {
        int numberofStandingPins = 0;
        foreach (Pin i in GameObject.FindObjectsOfType<Pin>())
        {
            if (i.IsStanding())
            {
                numberofStandingPins++;
            }
        }
        return numberofStandingPins;
    }


    
}
