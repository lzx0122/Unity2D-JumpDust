using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bulletgroupCS : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject monsterlist;
    public GameObject monster;
    [SerializeField] GameObject leftBullet;
    [SerializeField] GameObject rightBullet;
    [SerializeField] private float Timevalue = 0f;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        if (Timevalue > 2)
        {
            bulletfun();
            Timevalue = 0;
        }
        else
        {
            Timevalue += 0.1f;
        }
    }
    public void bulletfun()
    {
        int i = Random.Range(0, monsterlist.gameObject.transform.childCount);
        monster = monsterlist.gameObject.transform.GetChild(i).gameObject;
        if (monster.transform.localScale.x < 0)
        {
            Instantiate(leftBullet, monster.transform);
        }
        else if (monster.transform.localScale.x > 0)
        {
            Instantiate(rightBullet, monster.transform);
        }
    }
}
