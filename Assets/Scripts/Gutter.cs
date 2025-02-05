using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        Debug.Log("Gutter triggered");
        // get rigidbody of ball and store it in local variable
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        // store the velocity magnitude before resetting velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        // need to reset linear AND angular velocity (ball is rotating on ground when moving)
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        Debug.Log(ballRigidBody.linearVelocity);

        // add force in the forward direction of the Gutter
        // use the saved velocity magniture for some realism
        ballRigidBody.AddForce(transform.forward *velocityMagnitude, ForceMode.VelocityChange);
    }
    
}
