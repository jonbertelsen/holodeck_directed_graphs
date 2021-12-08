using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidBodyFreeze : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Vector3 m_YAxis;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set up vector for moving the Rigidbody in the y axis
        m_YAxis = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //Press space to add constraints on the RigidBody (Freezing the position)
        if (Keyboard.current.spaceKey.isPressed)
        {
            //Freeze all positions
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }

        //Press the up arrow key to move positively in the y axis if the constraints are removed
        if (Keyboard.current.upArrowKey.isPressed)
        {
            //If the constraints are removed, the Rigidbody moves along the y axis
            //If the constraints are there, no movement occurs
            m_Rigidbody.velocity = m_YAxis;
        }

        //Press the down arrow key to move negatively in the y axis if the constraints are removed
        if (Keyboard.current.downArrowKey.isPressed)
        {
            m_Rigidbody.velocity = -m_YAxis;
        }

    }
}
