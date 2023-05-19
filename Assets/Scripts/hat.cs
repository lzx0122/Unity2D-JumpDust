using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hat : MonoBehaviour
{
    [SerializeField] GameObject playerHat;
    [SerializeField] TMPro.TMP_Dropdown hatdropdown;
    private string hatpath;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hatfun()
    {

        if (hatdropdown.value != 0)
        {
            playerHat.SetActive(true);

            hatpath = "hat/" + hatdropdown.value;
            Debug.Log(hatpath);

            playerHat.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>(hatpath);
            Debug.Log(hatdropdown.value);

        }
        else
        {
            playerHat.SetActive(false);

        }

    }
}
