using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class skinDropDown : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerSkin;
    [SerializeField] TMPro.TMP_Dropdown skinList;

    private Sprite imageSkin;
    private string ImagePath = "Assets/skin/";


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void skinChoose()
    {

        ImagePath = "skin/" + skinList.value;
        Debug.Log(ImagePath);
        imageSkin = Resources.Load(ImagePath, typeof(Sprite)) as Sprite;
        playerSkin.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>(ImagePath);
        Debug.Log(skinList.value);



    }
}
