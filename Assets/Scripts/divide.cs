using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class divide : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform maincamera;
    public Transform player;
    private Vector3 newpos;

    private Vector3 hitPos;
    private float startpoint;
    private float exitpoint;
    private string condition;
    public GameObject rb;






    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        startpoint = (float)player.position.y;


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "divide")
        {
            exitpoint = (float)player.position.y;

            if (((float)exitpoint - (float)startpoint) > 0f)
            {
                Debug.Log("上升");
                condition = "上升";
                Debug.Log((float)((float)exitpoint - (float)startpoint));
            }
            else
            {
                Debug.Log("下降");
                condition = "下降";
                Debug.Log((float)((float)exitpoint - (float)startpoint));
            }

            if (condition == "上升")
            {
                exitpoint = player.position.y;
                newpos = new Vector3(maincamera.position.x, maincamera.position.y + 18, maincamera.position.z);
                maincamera.position = newpos;
                Debug.Log("up");
                Debug.Log(startpoint);
                Debug.Log(exitpoint);

            }
            else if (condition == "下降")
            {
                exitpoint = player.position.y;
                newpos = new Vector3(maincamera.position.x, maincamera.position.y - 18, maincamera.position.z);
                maincamera.position = newpos;
                Debug.Log("down");
                Debug.Log(startpoint);
                Debug.Log(exitpoint);

            }

        }


    }


}
