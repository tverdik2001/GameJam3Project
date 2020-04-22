using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
       

        /// <summary>
        /// Sensitivity for free look.
        /// </summary>
        public float freeLookSensitivity = 100f;

        float xRotation = 0f;

        public Transform playerBody;

        /// <summary>
        /// Set to true when free looking (on right mouse button).
        /// </summary>
    private bool looking = true;

    public static float timeSpeed = 0f;
    public GameObject shot;

   

    void Start()
    {
        StartLooking();
        Time.timeScale = 1;
    }

    void Update()
    {
        if (looking)
        {
            float newRotationX = Input.GetAxis("Mouse X") * freeLookSensitivity * Time.deltaTime;
            float newRotationY = Input.GetAxis("Mouse Y") * freeLookSensitivity * Time.deltaTime;
            xRotation -= newRotationY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * newRotationX);


            //Time
            
           timeSpeed = Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"));

            //enemies wont die unless time > 0 so I added this
            if(timeSpeed<=0)
            {
                timeSpeed = .2f;
            }
            Time.timeScale = Mathf.Lerp(Time.timeScale, timeSpeed, 5);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentShot = Instantiate<GameObject>(shot);
            currentShot.transform.position = transform.position;
            currentShot.transform.rotation = transform.rotation;
            currentShot.transform.Translate(0, 0f, -2f);
            Destroy(currentShot, 20);
        }


        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    StartLooking();
        //}
        //else if (Input.GetKeyUp(KeyCode.Mouse1))
        //{
        //    StopLooking();
        //}
    }

        void OnDisable()
        {
            StopLooking();
        }

        /// <summary>
        /// Enable free looking.
        /// </summary>
        public void StartLooking()
        {
            looking = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        /// <summary>
        /// Disable free looking.
        /// </summary>
        public void StopLooking()
        {
            looking = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
