using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
       

        /// <summary>
        /// Sensitivity for free look.
        /// </summary>
        public float freeLookSensitivity = 3f;

       

        /// <summary>
        /// Set to true when free looking (on right mouse button).
        /// </summary>
    private bool looking = true;

    public static float timeSpeed = 0;
    public GameObject shot;
    public GameObject shotPosition;
    public Animator cannonAnimation;

    void Start()
    {
        StartLooking();
        //Time.timeScale = 0;
    }

    void Update()
    {
        if (looking)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            //Debug.Log(newRotationY);
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
            //timeSpeed = Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"));        
            //Time.timeScale = Mathf.Lerp(Time.timeScale, timeSpeed, 5);           
          
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentShot = Instantiate<GameObject>(shot);
            currentShot.transform.parent = shotPosition.transform;
            currentShot.transform.localPosition = Vector3.zero;
            currentShot.transform.localRotation = Quaternion.identity;
            currentShot.transform.parent = null;
            //currentShot.transform.Translate(0, -0.5f, -2f);
            currentShot.transform.Rotate(0, 0, 90);
            cannonAnimation.SetBool("shoot", true);
            Destroy(currentShot, 20);
        }
        else
            cannonAnimation.SetBool("shoot", false);




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
