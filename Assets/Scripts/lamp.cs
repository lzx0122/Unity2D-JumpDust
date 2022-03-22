using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] GameObject lamp1;
    private float maxNum = 2;

    private float j;
    public int i;
    private float a;
    [SerializeField] GameObject lampList;
    private int count;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (a > j)
        {

            lampfun();
            a = 0;
            j = Random.Range(0, 3);
        }
        else
        {
            a += 0.1f;

        }


    }
    void lampfun()
    {
        i = Random.Range(0, 4);
        count = Random.Range(0, lampList.gameObject.transform.childCount);

        if (i == 1 || i == 2 || i == 0)
        {

            lampList.gameObject.transform.GetChild(count).gameObject.SetActive(true);


        }
        else
        {
            lampList.gameObject.transform.GetChild(count).gameObject.SetActive(false);


        }
    }
}
