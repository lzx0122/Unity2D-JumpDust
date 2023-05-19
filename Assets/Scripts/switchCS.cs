using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class switchCS : MonoBehaviour
{
    [SerializeField] GameObject disFloor;
    [SerializeField] GameObject switchGO;
    private bool isSwitch = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (isSwitch == true)
        {
            switchGO.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("switch/switchdown");
        }
        else
        {
            switchGO.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("switch/switchup");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "switch")
        {
            Debug.Log("switch true");
            if (isSwitch == false)
            {
                disFloor.SetActive(true);
                GameObject.Find("disappearfloorGroup").GetComponent<disappearfloorCS>().refloor();
                isSwitch = true;
                Invoke("offSwitch", 0);
            }
        }
    }
    void offSwitch()
    {
        disFloor.gameObject.SetActive(false);
        Invoke("onSwitch", 1);
    }
    void onSwitch()
    {
        disFloor.gameObject.SetActive(true);
        Invoke("isSwitchfun", 2);
    }
    void isSwitchfun()
    {
        isSwitch = false;
    }
}
