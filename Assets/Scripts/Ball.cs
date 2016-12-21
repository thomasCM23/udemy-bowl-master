using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    Rigidbody rb;
    AudioSource audio;
    public Vector3 launchVelocity;
    public bool inPlay = false;
    private Vector3 startPosition;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        rb.useGravity = false;
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {

	
	}
    public void Launch(Vector3 velocity)
    {
        if (!inPlay)
        {
            inPlay = true;
            rb.useGravity = true;
            rb.velocity = velocity;
            audio.Play();
        }
    }
    public void Reset()
    {
        inPlay = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
    }


}
