using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float NowTime;
    public bool isTiming= false;
    public Text timetext;

    

    // public float stoptime;
    // private bool isStoptime = false;



    void Start()
    {
        NowTime = 0f;
        isTiming = false;
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            isTiming = true;
            
        }
        // if (Input.GetKeyDown(KeyCode.Escape)){
        //     if(isStoptime == false ){
        //         stoptime = NowTime;
        //         isStoptime = true;
        //     }else{
        //         NowTime = stoptime;
        //         isStoptime = false;
        //     }
         
            

        // }
    }
    private string timebox;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(isTiming == true){

        
            NowTime+=Time.fixedDeltaTime;
        
            timebox = strtime(NowTime);
            if(timebox != ""){
                timetext.text = (string)timebox;
            }

        }
    }
    private string strtime(float a){
        int ms = (int)((a % 1f )*100);
        int TotleTime = (int) a / 1;
        int minute;
        int second;
        minute = TotleTime /60;
        second = TotleTime % 60;
        if (minute>=1){
            return minute.ToString().PadLeft(2,'0')+":"+second.ToString().PadLeft(2,'0')+":"+ms.ToString().PadLeft(2,'0');
        }else if(second>=1){
            return second.ToString().PadLeft(2,'0')+":"+ ms.ToString().PadLeft(2,'0');
        }else{
            return "00:"+ms.ToString().PadLeft(2,'0');
        }
        

    }
}
