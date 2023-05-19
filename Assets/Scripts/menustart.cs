using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
public class menustart : MonoBehaviour
{
    // Start is called before the first frame update
    private string Ptahstring;
    void Start()
    {
        Screen.fullScreen = false;
        Ptahstring = Application.dataPath + "/rankdata.txt";
        if (System.IO.File.Exists(Ptahstring))
        {
            Debug.Log("檔案存在");
        }
        else
        {
            FileStream fs = new FileStream(Ptahstring, FileMode.Create);
            Debug.Log("createRank.txt");
            Debug.Log("檔案不存在 以創建");
            fs.Close();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game close");
    }
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
