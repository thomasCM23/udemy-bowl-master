using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public Ball target;
    private Vector3 offset;
	// Use this for initialization
	void Start ()
    {
        offset = transform.position - target.transform.position;

	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if(target.transform.position.z <= 1850)
        {
            transform.position = target.transform.position + offset;
        }
	
	}
}
