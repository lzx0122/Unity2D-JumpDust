using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{


    [SerializeField] Rigidbody2D rb;
    private bool isLadder = false;
    private float keybroadV = 0;
    private float keybroadH = 0;
    [SerializeField] GameObject player;
    private float gr;





    // Start is called before the first frame update
    void Start()
    {
        gr = rb.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (isLadder == true)
        {
            rb.gravityScale = 0f;
            keybroadV = Input.GetAxis("Vertical");
            keybroadH = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.UpArrow))
            {
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.05f);


            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {

                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 0.05f);
            }


        }
        else
        {

            rb.gravityScale = gr;
            isLadder = false;


        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ladder" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            isLadder = true;
            Debug.Log("ladder true");
            player.transform.position = player.transform.position;
            GameObject.Find("Player").GetComponent<Player>().ladder(1, true);

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ladder")
        {
            isLadder = false;
            GameObject.Find("Player").GetComponent<Player>().ladder(3, false);

        }
    }

}
