using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    Rigidbody rb;
    public float bulletForce;
    bool firstTime = false;
    Vector3 direction;
    public GameObject hitEffect;
    public GameObject destroyEffect;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("shoot")) return;

        if (collision.gameObject.tag.Contains("Enemy"))
        {
            GameObject current = collision.gameObject;
            while (current.tag != "Enemy")
            {
                current = current.transform.parent.gameObject;
            }
            EnemyMovement enemy = current.GetComponent<EnemyMovement>();
            Debug.Log(enemy.HP);
            enemy.HP -= Random.Range(20, 60);
            if (enemy.HP <= 0)
            {
                GameObject destroy = Instantiate<GameObject>(destroyEffect);
                destroy.transform.position = current.transform.position;
                Destroy(destroy, 4);
                Destroy(enemy.gameObject);
            }
        }

        GameObject hit = Instantiate<GameObject>(hitEffect);
        hit.transform.position = transform.position;
        Destroy(hit, 4);

        Destroy(gameObject);

        //  if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    Destroy(collision.gameObject);
        //}
        //Destroy(this.gameObject);
        Debug.Log("hit");
    }
}
