using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    Rigidbody rb;
    public float bulletForce;
    bool firstTime = false;
    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        //transform.Rotate(0, 0, 90);
    }


    public void SetDirection(Vector3 dir)
    {
        direction = dir;
       transform.rotation = Quaternion.LookRotation(direction);
        firstTime = true;
    }

    void OnCollisionEnter()
    {
        //code for when bullet hits something
    }

    void FixedUpdate()
    {
        if (firstTime)
        {
          
            rb.AddForce(direction * bulletForce);
            firstTime = false;
        }
    }

    //Rigidbody rb;
    //public float speed = 20;
    //Vector3 target;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    //target = new Vector3(target.x, target.y, target.z + 1000);
    //    target = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //rb.AddForce(Vector3.forward * speed);
    //    //transform.Translate(0, 0, 1);

    //    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //    Destroy(this.gameObject);
    //}
}
