using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject escmanu;
    private bool isEscape = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Escape)){
           
            if (Time.timeScale == 1){
                Time.timeScale = 0;
                escmanu.SetActive(true);
                isEscape = true;
            }else{
                Time.timeScale = 1;
                escmanu.SetActive(false);
                isEscape = false;
            };         
        }     
    }
    public void continuebutton(){
        isEscape = false;
        escmanu.SetActive(false);
        if (Time.timeScale == 1){
            Time.timeScale = 0;
            escmanu.SetActive(true);
            isEscape = true;
        }else{
            Time.timeScale = 1;
            escmanu.SetActive(false);
            isEscape = false;
        };
    }
}
