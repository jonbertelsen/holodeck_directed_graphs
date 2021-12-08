using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Holodeck
{
    public class PlayerController : MonoBehaviour
    {

        private PlayerControls playerControls;

        private void Awake()
        {
            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
            playerControls.Demo.Freeze.performed -= freeze;
        }

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Player Controls Activated");

            playerControls.Demo.Freeze.performed += freeze;
        }

        public void freeze(InputAction.CallbackContext context)
        {
            Debug.Log("Freeze pressed");
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("node");
            foreach (GameObject go in gameObjects)
            {
                //    Debug.Log("Freeze this sphere" + go.gameObject.name);

                RigidbodyConstraints rbc = go.GetComponent<Rigidbody>().constraints;
                if (rbc == RigidbodyConstraints.FreezeAll)
                {
                    go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation ;
                }
                else {
                    go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
                
            }
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}
