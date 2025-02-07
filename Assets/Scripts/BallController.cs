using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform launchIndicator;

    private Rigidbody ballRB;

    private bool isBallLaunched;

    
    void Start()
    {
        // getting reference to rigid body
        ballRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        
        // add a listener to OnSpacePressed Events
        // when space key is pressed, the LaunchBall method will be called
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        // reset the state
        ResetBall();

        /*
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        */
    }

    public void ResetBall()
    {
        /*
        isBallLaunched = false;
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        */
        isBallLaunched = false;
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
    }

    private void LaunchBall()
    {
        // if the ball is launched, don't do anything
        if(isBallLaunched) return;
        // when ball is not launched, set it to true and launch ball
        isBallLaunched = true;

        // remove ball from player anchor 
        transform.parent = null;

        ballRB.isKinematic = false;
        //launchIndicator.gameObject.SetActive(false);

        //add force to ball
        //ballRB.AddForce(transform.forward * force, ForceMode.Impulse);

         //using angle of arrow to launch ball
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }
}
