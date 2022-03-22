using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class camera : MonoBehaviour
{
    // Start is called before the first frame update


    public float baseWidth = 1024;
    public float baseHeight = 768;
    public float baseOrthographicSize = 5;
    public Camera cr;

    void Awake()
    {
        //  float newOrthographicSize = (float)Screen.height / (float)Screen.width * this.baseWidth / this.baseHeight * this.baseOrthographicSize;
        // cr.orthographicSize = Mathf.Max(newOrthographicSize, this.baseOrthographicSize);

    }



    void Start()
    {
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        Screen.fullScreen = true;
        float newOrthographicSize = (float)Screen.height / (float)Screen.width * this.baseWidth / this.baseHeight * this.baseOrthographicSize;
        cr.orthographicSize = Mathf.Max(newOrthographicSize, this.baseOrthographicSize);
    }
}
