using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Pin>())
        {
            Destroy(other.gameObject);
        }
    }
}
