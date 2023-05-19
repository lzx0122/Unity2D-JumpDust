using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class rightbullet : MonoBehaviour
{
    private GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(transform.position.x + 3f * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x > 9)
        {
            Destroy(gameObject);
        }
    }
}
