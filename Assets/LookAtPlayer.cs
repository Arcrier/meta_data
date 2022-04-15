using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public Transform target;
    public bool isGrabbed;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;
    }

    public void grab()
    {
        isGrabbed = true;
    }

    public void letGo()
    {
        isGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrabbed)
        {
            //transform.LookAt(target);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, Time.deltaTime);


            //var qTo = Quaternion.LookRotation(target.transform.position - transform.position);
            //qTo = Quaternion.Slerp(transform.rotation, qTo, 10 * Time.deltaTime);
            //GetComponent<Rigidbody>().MoveRotation(qTo);
        }



    }
}
