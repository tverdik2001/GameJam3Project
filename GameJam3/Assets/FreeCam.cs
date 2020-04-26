using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
       

        /// <summary>
        /// Sensitivity for free look.
        /// </summary>
        public float freeLookSensitivity = 100f;
        public Transform playerBody;
        private float xRotation = 0f;

        /// <summary>
        /// Set to true when free looking (on right mouse button).
        /// </summary>
    private bool looking = true;

    public static float timeSpeed = 0;
    public GameObject shot;
    public GameObject shotPosition;
    public Animator cannonAnimation;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    private float nextFire; 
    private LineRenderer laserLine;
    public float fireRate = .25f;
    public float weaponRange = 50f;


    void Start()
    {
        StartLooking();
        laserLine = GetComponent<LineRenderer>();
        //Time.timeScale = 0;
    }

    void Update()
    {
        if (looking)
        {
            //float newRotationX = Input.GetAxis("Mouse X") * freeLookSensitivity * Time.deltaTime;
            //float newRotationY = Input.GetAxis("Mouse Y") * freeLookSensitivity * Time.deltaTime;
            //playerBody.Rotate(Vector3.right * mouseY);

            //playerBody.Rotate(Vector3.up * mouseX);
            
            float newRotationX = Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = playerBody.localEulerAngles.x + Input.GetAxis("Mouse Y") * freeLookSensitivity;
            xRotation -= newRotationY;
            xRotation = Mathf.Clamp(xRotation, -11f, 32f);
            
            //transform.localEulerAngles = new Vector3(newRotationY, 0f, 0f);
            //newRotationY = Mathf.Clamp(newRotationY, -1f, 1f);
            Debug.Log(xRotation);
            playerBody.Rotate(Vector3.up * newRotationX);
            transform.localRotation = Quaternion.Euler(xRotation, -90f, 0f);
            //transform.Rotate(Vector3.left * newRotationY);
            //playerBody.Rotate(Vector3.left * newRotationY);
            //timeSpeed = Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"));        
            //Time.timeScale = Mathf.Lerp(Time.timeScale, timeSpeed, 5);           

        }

        if (Input.GetMouseButtonDown(0))
        {

            //create ray from camera to mousePosition
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Create bullet from the prefab
              ShotMovement newBullet = Instantiate(shot).GetComponent<ShotMovement>();

            //Make the new bullet start at camera
            //newBullet.transform.position = Camera.main.transform.position;
            newBullet.transform.position = shotPosition.transform.position;

            //set bullet direction
            newBullet.SetDirection(ray.direction);

        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    laserLine.enabled = true;
        //    GameObject currentShot = Instantiate<GameObject>(shot);
        //    currentShot.transform.parent = shotPosition.transform;
        //    currentShot.transform.localPosition = Vector3.zero;
        //    currentShot.transform.localRotation = Quaternion.identity;
        //    currentShot.transform.parent = null;
        //    //currentShot.transform.Translate(0, -0.5f, -2f);
        //    currentShot.transform.Rotate(90,0 , 0);
        //    cannonAnimation.SetBool("shoot", true);
        //    Destroy(currentShot, 20);
        //}
        //else
        //    cannonAnimation.SetBool("shoot", false);

        //if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        //{

        //    nextFire = Time.time + fireRate;
        //    StartCoroutine(ShotEffect());
        //    Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        //    RaycastHit hit;
        //    laserLine.SetPosition(0, shotPosition.transform.position);
        //    laserLine.enabled = true;
        //    GameObject currentShot = Instantiate<GameObject>(shot);
        //    currentShot.transform.parent = shotPosition.transform;
        //    currentShot.transform.localPosition = Vector3.zero;
        //    //currentShot.transform.localRotation = Quaternion.identity;
        //    currentShot.transform.parent = null;
        //    currentShot.transform.LookAt(Camera.main.transform.forward);
        //    //currentShot.transform.Translate(0, -0.5f, -2f);
        //    //currentShot.transform.Rotate(90, 0, 0);
        //    cannonAnimation.SetBool("shoot", true);
        //    Destroy(currentShot, 20);
        //    //if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, weaponRange))
        //    //{
        //    //    laserLine.SetPosition(1, hit.point);
        //    //}
        //    //else
        //    //{
        //    //    laserLine.SetPosition(1, Camera.main.transform.forward * weaponRange);
        //    //}
        //}




        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    StartLooking();
        //}
        //else if (Input.GetKeyUp(KeyCode.Mouse1))
        //{
        //    StopLooking();
        //}
    }

    private IEnumerator ShotEffect()
    {
        //    laserLine.enabled = true;
            //    GameObject currentShot = Instantiate<GameObject>(shot);
            //    currentShot.transform.parent = shotPosition.transform;
            //    currentShot.transform.localPosition = Vector3.zero;
            //    currentShot.transform.localRotation = Quaternion.identity;
            //    currentShot.transform.parent = null;
            //    //currentShot.transform.Translate(0, -0.5f, -2f);
            //    currentShot.transform.Rotate(90,0 , 0);
            //    cannonAnimation.SetBool("shoot", true);
            //    Destroy(currentShot, 20);
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;


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
