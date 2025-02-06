using UnityEngine;

public class Gutter : MonoBehaviour
{
    //private bool isColliding;
    private void OnTriggerEnter(Collider triggeredBody)
    { 
        /*
        if(isColliding) return;
        isColliding=true;
        */
        Debug.Log("Gutter triggered");
        // get rigidbody of ball and store it in local variable
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        // store the velocity magnitude before resetting velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
        Debug.Log(velocityMagnitude);

        // need to reset linear AND angular velocity (ball is rotating on ground when moving)
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        Debug.Log(ballRigidBody.linearVelocity);

        // add force in the forward direction of the Gutter
        // use the saved velocity magniture for some realism
        ballRigidBody.AddForce(transform.up * velocityMagnitude, ForceMode.VelocityChange);
        //Debug.Log(ballRigidBody.linearVelocity.magnitude);
    }
    /*
    void Update()
    {
        isColliding = false;
    }
    */
}
