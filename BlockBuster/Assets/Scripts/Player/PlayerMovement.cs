using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;

    // Adding a Rigidbody component to an object will put its motion under the control of Unity's physics engine.
    // // Even without adding any code, a Rigidbody object will be pulled downward by gravity and
    // // will react to collisions with incoming objects if the right Collider component is also present.
    private Rigidbody rigidBody;

    // Enum. Key codes returned by Event.keyCode. These map directly to a physical key on the keyboard.
    private KeyCode[] inputKeys;
    private Vector3[] directionsForKeys;

    // Start is called before the first frame update
    void Start()
    {
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
        rigidBody = GetComponent<Rigidbody>();
    }

    // FixedUpdate is frame rate independent and should be used when working with Rigidbodies.
    // method will be fired at a constant interval
    void FixedUpdate()
    {
        // loop checks to see if any of the input keys were pressed.
        for (int i = 0; i < inputKeys.Length; i++)
        {
            var key = inputKeys[i];

            // 2
            if (Input.GetKey(key))
            {
                // 3
                Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
            }
        }

    }
}
