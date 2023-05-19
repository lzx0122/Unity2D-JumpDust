using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
public class rank : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text outtxt;
    [SerializeField] GameObject ranklist;
    void Start()
    {
        List<string> newlist = new List<string>();
        string[] textTxt = File.ReadAllLines(Application.dataPath + "/rankdata.txt");
        var texttxt2 = textTxt.Where(x => !string.IsNullOrEmpty(x)).ToList();
        var list = texttxt2.OrderBy(x => int.Parse(x.Split(' ')[1].Split(':')[0])).OrderBy(x => int.Parse(x.Split(' ')[1].Split(':')[1])).OrderBy(x => int.Parse(x.Split(' ')[1].Split(':').Last())).OrderBy(x => x.Split(' ')[1].Split(':').ToList().Count());
        foreach (var i in list)
        {
            newlist.Add(i);
        }
        for (int i = 0; i < newlist.Count(); i++)
        {
            outtxt.text += "\n\n" + (i + 1).ToString().PadLeft(3, ' ') + "  " + newlist[i].Split(' ')[0].PadLeft(10, ' ') + "  " + newlist[i].Split(' ')[1].PadLeft(8, ' ');
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
