using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FreeCam.timeSpeed > 0)
        if (Random.Range(0,1000) < 1)
        {
            GameObject current = Instantiate<GameObject>(enemy);
            current.transform.position = new Vector3(transform.position.x + Random.Range(-100, 100), transform.position.y + Random.Range(-100, 100), transform.position.z + Random.Range(-100, 100));
            //Destroy(current, 20);
        }

    }
}
