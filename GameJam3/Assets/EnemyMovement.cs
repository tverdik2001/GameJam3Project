using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    enum BehaviourState { Idle, Attack, Leave}
    BehaviourState State;
    GameObject player;
    public float distance;

    Vector3 targetPosition;

    int velocity = 100;
    
    float angle, angle2;
    Rigidbody rigidbody;
    public float speed = 10;
    public float speedRotation;
    public int RandomMax = 100;
    Coroutine shootCoroutine = null;
    public GameObject shot;
    public GameObject shotPosition;
    public float shotDuration;

    public float HP = 100;
    // Start is called before the first frame update
    void Start()
    {
        State = BehaviourState.Idle;
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Main Camera");
        targetPosition = new Vector3(player.transform.position.x + Random.Range(-distance, distance), player.transform.position.y + Random.Range(-distance, distance), player.transform.position.z + Random.Range(-distance, distance));
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (State == BehaviourState.Attack)
        {
            
            float distance = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
            Debug.Log(distance);
            if (distance < 70)
            {
                State = BehaviourState.Idle;
                speed = 10;
                speedRotation = 0.5f;
                return;
            }

            Vector3 targetDirection = player.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = speedRotation * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            
            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
            rigidbody.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);

            if (shootCoroutine == null)
            {               
                shootCoroutine = StartCoroutine("ShootEffect");
            }

        }
        else
        if (State == BehaviourState.Idle)
        {

            if (Random.Range(0, RandomMax) < 5)
            {
                State = BehaviourState.Attack;
                speed = 10;
                speedRotation = 1;
            }
            else
            if (Random.Range(0, RandomMax) < 1)
            {
                targetPosition = new Vector3(player.transform.position.x + Random.Range(-distance, distance), player.transform.position.y + Random.Range(-distance, distance), player.transform.position.z + Random.Range(-distance, distance));
                //rigidbody.velocity = Vector3.zero;
            }
            //var targetDir = targetPosition - transform.position;
            //var forward = transform.forward;
            //var localTarget = transform.InverseTransformPoint(targetPosition);

            //angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
            //angle2 = Mathf.Atan2(localTarget.x, localTarget.y) * Mathf.Rad2Deg;


            //Vector3 eulerAngleVelocity = new Vector3(angle2, angle, 0);
            //Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
            //rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);


            //var targetRotation = Quaternion.LookRotation((targetPosition - transform.position));
            ////transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedRotation);
            //// The step size is equal to speed times frame time.
            //var step = speed * Time.deltaTime;

            //// Rotate our transform a step closer to the target's.
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

            //var direction = targetPosition - transform.position;
            //rigidbody.AddRelativeForce(direction.normalized * speed, ForceMode.Force);


            Vector3 targetDirection = targetPosition - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = speedRotation * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

         

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
            rigidbody.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);


        }

    }

    private IEnumerator ShootEffect()
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
        //laserLine.enabled = true;
        //yield return shotDuration;
        //laserLine.enabled = false;
        //create ray from camera to mousePosition


       // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Create bullet from the prefab
        ShotMovement newBullet = Instantiate(shot).GetComponent<ShotMovement>();

        //Make the new bullet start at camera
        //newBullet.transform.position = Camera.main.transform.position;
        newBullet.transform.position = shotPosition.transform.position;

        newBullet.transform.Translate(transform.forward * 10);

        //set bullet direction
        newBullet.SetDirection(transform.forward);        
        yield return new WaitForSeconds(shotDuration);
        
        shootCoroutine = null;
    }


}
