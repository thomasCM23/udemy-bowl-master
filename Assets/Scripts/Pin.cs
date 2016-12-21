using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    bool isStanding = true;
    Rigidbody rb;

    public float distanceToRaise = 40f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public bool IsStanding()
    {
        return isStanding;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "StandingChecker")
        {
            isStanding = true;
        }


    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "StandingChecker")
        {
            isStanding = false;
        }
    }
    public void Raise()
    {
        if (isStanding)
        {
            transform.rotation = Quaternion.Euler(new Vector3(270f, 0f, 0f));
            rb.isKinematic = true;
            transform.Translate(new Vector3(0.0f, distanceToRaise, 0.0f), Space.World);
        }
    }
    public void Lower()
    {
        rb.isKinematic = false;
        transform.Translate(new Vector3(0.0f, -distanceToRaise, 0.0f), Space.World);

    }

}
