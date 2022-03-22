using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class end : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] GameObject endUI;
    [SerializeField] PlayerData data;
    [SerializeField] Text timetxt;
    [SerializeField] string timebox;
    [SerializeField] GameObject princeBackground;
    [SerializeField] GameObject addRank;
    [SerializeField] Text addPlayerName;

    public Text rankTimeText;
    private string[] dataTextList;
    string fileName = "rankdata.txt";
    string Path;




    void Start()
    {

        Path = Application.dataPath;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "end")
        {

            Debug.Log("end");
            endUI.SetActive(true);
            Time.timeScale = 0;







        }






    }


    public void rkfun()
    {

        princeBackground.SetActive(false);
        addRank.SetActive(true);
        rankTimeText.text = timetxt.text;






    }

    public void rkaddButton()
    {

        // FileStream fsop = new FileStream(Application.dataPath + "/data.txt", FileMode.Open);
        // StreamReader sr = new StreamReader(fsop);
        // timebox = sr.ReadLine();
        // sr.Close();
        // fsop.Close();
        // Debug.Log(timebox);
        // timebox += "\r" + addPlayerName.text + " " + timetxt.text;


        // FileStream fsop2 = new FileStream(Application.dataPath + "/data.txt", FileMode.Open);
        // StreamWriter sw = new StreamWriter(fsop2);
        // sw.WriteLine("\r" + addPlayerName.text + " " + timetxt.text);
        // sw.Close();
        // fsop.Close();

        FileStream fs = new FileStream(Path + "//" + fileName, FileMode.Append, FileAccess.Write);
        byte[] bytes = Encoding.UTF8.GetBytes("\n" + addPlayerName.text + " " + timetxt.text);
        fs.Write(bytes, 0, bytes.Length);
        fs.Flush();
        SceneManager.LoadScene("menu");

    }
    public void exitButton()
    {

        SceneManager.LoadScene("menu");

    }


    [System.Serializable]
    public class PlayerData
    {
        public string time;
        public string name;


    }
}
