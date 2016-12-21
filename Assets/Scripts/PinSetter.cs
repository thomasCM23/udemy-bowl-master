using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    
    
    public GameObject newPins;
    
    
    private Animator anim;
    private PinCounter pinCounter;
    void Start()
    {
        anim = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }
	// Update is called once per frame
	void Update ()
    {
	}
    
    public void RaisePins()
    {
        foreach(Pin i in GameObject.FindObjectsOfType<Pin>())
        {
            i.Raise();
        }
    }
    
    public void LowerPins()
    {
        foreach (Pin i in GameObject.FindObjectsOfType<Pin>())
        {
            i.Lower();
        }
    }
    public void RenewPins()
    {
        GameObject pins = Instantiate(newPins, new Vector3(0.0f, 10f, 1850.0f), Quaternion.identity) as GameObject;

    }
    public void PreformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.EndTurn)
        {
            pinCounter.Reset();
            anim.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.Tidy)
        {
            anim.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.Reset)
        {
            pinCounter.Reset();
            anim.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Do not know how to do endgame yet");
        }
    }
    
}
