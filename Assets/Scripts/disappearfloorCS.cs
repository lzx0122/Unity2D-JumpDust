using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class disappearfloorCS : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject floorList;
    private int floorListCount;
    private int index = 0;
    [SerializeField] int ontime = 3;
    [SerializeField] int offtime = 2;
    private float timeBox;
    private bool isRefloor = false;
    void Start()
    {
        floorListCount = floorList.transform.childCount;
    }
    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        if (timeBox >= ontime)
        {
            onFloor();
            timeBox = 0;
        }
        else
        {
            timeBox += 0.02f;
        }
    }
    void onFloor()
    {
        floorList.transform.GetChild(index).gameObject.SetActive(true);
        Invoke("offFloor", offtime);
    }
    void offFloor()
    {
        if (isRefloor == false)
        {
            if (index == 0)
            {
                floorList.transform.GetChild(floorListCount - 1).gameObject.SetActive(false);
            }
            else
            {
                floorList.transform.GetChild(index - 1).gameObject.SetActive(false);
            }
            if (index == (floorListCount - 1))
            {
                index = 0;
            }
            else
            {
                index += 1;
            }
        }
        else
        {
            isRefloor = false;
            index = 0;
            timeBox = 0;
        }
    }
    public void refloor()
    {
        index = 0;
        timeBox = 0;
        isRefloor = true;
        for (int i = 0; i <= floorListCount - 1; i++)
        {
            floorList.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
