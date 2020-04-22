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
    void Update()
    {
        if (FreeCam.timeSpeed > 0)
        if (Random.Range(0,100) < 5)
        {
            GameObject current = Instantiate<GameObject>(enemy);
            current.transform.position = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z);
            Destroy(current, 20);
        }

    }
}
