using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    // Start is called before the first frame update



    public Rigidbody2D rb;


    public float playspeed = 3;
    public float jumpSpeed = 7;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask jumpwallLayer;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    bool isKeyBoard = true;

    float jumpDebugTime = 1;


    public float jumpkey = 0.0f;
    public PhysicsMaterial2D bounceMat, nomarlMat;

    public float jumpMax = 25.0f;
    float delay = 0;


    Vector2 spawnPoint;



    //jumpWall------------------------------------------------------
    public float wallJumpTime = 0.02f;
    public float wallSlideSpeed = 0.03f;

    public float wallJumpSpeed = 7f;


    public float wallDistance = 0.02f;

    private bool isWalljumprun = false;

    [SerializeField] bool isWallSliding = false;
    bool WallCheckHitLeft;

    bool WallCheckHitRight;
    float mx = 0f;

    float wallTime;
    string wallJumpDirection;

    [SerializeField] float walljumpMax = 19;

    //jumpParticles------------------------------------------------------
    [SerializeField] GameObject jumpParticles;
    [SerializeField] GameObject jumpPoint;


    //jumpPowerUI------------------------------------------------------


    [SerializeField] GameObject jumpPowerBackGround;
    public Image jumpPower;




    float boxJumpPowerHeight;
    float boxJumpPowerWidth;

    //send
    GameObject point1;
    GameObject point2;

    private bool isSendMove = false;
    public float sendSpeed = 20f;


    //level

    public int levelnum = 1;
    [SerializeField] Text levestr;

    [SerializeField] GameObject levelPoint;


    //monster


    //ladder
    private bool isladder = false;



    void Start()
    {

        //boxJumpPowerHeight = jumpPowerBackGround.gameObject.GetComponent<RectTransform>().rect.height;
        //boxJumpPowerWidth = jumpPowerBackGround.gameObject.GetComponent<RectTransform>().rect.width;
        //print(boxJumpPowerHeight);
        //print(boxJumpPowerWidth);

        Application.targetFrameRate = 300;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (isSendMove)
        {
            //rb.transform.Translate(new Vector3(0, 1 * sendSpeed * Time.deltaTime, 0));
            rb.velocity = new Vector2(0, sendSpeed * Time.deltaTime);


            if (rb.transform.position.y >= point2.transform.position.y)
            {


                isKeyBoard = true;
                isSendMove = false;
                rb.transform.position = new Vector2(rb.transform.position.x + 1f, rb.transform.position.y);
                rb.isKinematic = false;
                rb.transform.localScale = new Vector2(0.11f, 0.11f);
                spawnPoint = rb.transform.position;
            }


        }

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(feetPos.transform.position, checkRadius);
    }

    void Update()
    {



        if (isKeyBoard)
        {

            do
            {

                isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
                if (isGrounded == true)
                {
                    break;
                }
                isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, jumpwallLayer);


                break;
            } while (isGrounded);
            if (isGrounded == true)
            {
                //rb.sharedMaterial = nomarlMat;
                isWallSliding = false;
                isWalljumprun = false;
                jumpfun();
            }
            else if (isWallSliding == false)
            {
                //rb.sharedMaterial = nomarlMat;
                if (Input.GetKey(KeyCode.Space))
                {
                    jumpkey = 0;
                }

            };
            //walljump
            mx = Input.GetAxis("Horizontal");
            if (mx > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (mx < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);

            };
            if (jumpDebugTime > 0)
            {

                jumpDebugTime -= 1f;
            }
            else if (jumpDebugTime < 0)
            {

                jumpDebugTime = 0;
            };


            if (Input.GetKey(KeyCode.Space))
            {

            }
            else if (isGrounded == true && jumpDebugTime == 0 || isWalljumprun == true)
            {
                if (Input.GetKey(KeyCode.LeftArrow))

                {
                    rb.velocity = new Vector2(-1 * playspeed, rb.velocity.y);

                }
                else if (Input.GetKey(KeyCode.RightArrow))

                {
                    rb.velocity = new Vector2(1 * playspeed, rb.velocity.y);

                };


            };


            if (mx > 0 || mx < 0)
            {
                WallCheckHitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.3f), new Vector2(wallDistance, 0), wallDistance, jumpwallLayer);
                Debug.DrawRay(new Vector2(transform.position.x, (transform.position.y - 0.3f)), new Vector2(wallDistance, 0), Color.blue);


                WallCheckHitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.3f), new Vector2(-wallDistance, 0), wallDistance, jumpwallLayer);
                Debug.DrawRay(new Vector2(transform.position.x, (transform.position.y - 0.3f)), new Vector2(-wallDistance, 0), Color.red);



                if (WallCheckHitLeft)
                {
                    wallJumpDirection = "Left";

                }
                else if (WallCheckHitRight)
                {


                    wallJumpDirection = "Right";

                };



            }
            else
            {

                WallCheckHitLeft = false;
                WallCheckHitRight = false;
            };

            if ((WallCheckHitLeft == true || WallCheckHitRight == true) & isGrounded == false)
            {
                isWallSliding = true;
                wallJumpTime = Time.time + wallJumpTime;

            }
            else
            {
                isWallSliding = false;


            };

            if (isWallSliding)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));

                walljumpfun();

            };
            if (isladder)
            {

                ladderfun();

            }


        }
    }


    void jumpfun()
    {
        if (isKeyBoard)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpkey = 0.0f;
                jumpPower.fillAmount = 0;
            }
            if (Input.GetKey(KeyCode.Space))
            {

                jumpkey += Time.deltaTime * 15;
                if (jumpkey < jumpMax)
                {

                    jumpPower.fillAmount = (jumpkey / jumpMax) * 1;


                }
                else
                {
                    jumpPower.fillAmount = 1;
                }


            }

            if (Input.GetKeyUp(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow))
            {
                jumpDebugTime = 5;
                if (jumpkey < jumpMax)
                {

                    rb.velocity = new Vector2(-jumpSpeed, 1 + jumpkey);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    jumpPower.fillAmount = 0;
                    //rb.sharedMaterial = bounceMat;

                    jumpPoint.transform.position = feetPos.transform.position;
                    Instantiate(jumpParticles, jumpPoint.transform);




                }
                else if (jumpkey >= jumpMax)
                {

                    rb.velocity = new Vector2(-jumpSpeed, 1 + jumpMax);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    jumpPower.fillAmount = 0;
                    //rb.sharedMaterial = bounceMat;

                    jumpPoint.transform.position = feetPos.transform.position;
                    Instantiate(jumpParticles, jumpPoint.transform);


                }


            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {


                    jumpDebugTime = 5;
                    if (jumpkey < jumpMax)
                    {

                        rb.velocity = new Vector2(jumpSpeed, 1 + jumpkey);
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        jumpPower.fillAmount = 0;
                        //rb.sharedMaterial = bounceMat;

                        jumpPoint.transform.position = feetPos.transform.position;
                        Instantiate(jumpParticles, jumpPoint.transform);


                    }
                    else if (jumpkey >= jumpMax)
                    {

                        rb.velocity = new Vector2(jumpSpeed, 1 + jumpMax);
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        jumpPower.fillAmount = 0;
                        //rb.sharedMaterial = bounceMat;
                        jumpPoint.transform.position = feetPos.transform.position;
                        Instantiate(jumpParticles, jumpPoint.transform);

                    }

                }
            }


        }
    }


    void walljumpfun()
    {
        if (isKeyBoard)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpkey = 0.0f;

                jumpPower.fillAmount = 0;

            };

            if (Input.GetKey(KeyCode.Space))
            {
                jumpkey += Time.deltaTime * 22;
                if (jumpkey < walljumpMax)
                {

                    jumpPower.fillAmount = (jumpkey / walljumpMax) * 1;
                }
                else
                {
                    jumpPower.fillAmount = 1;
                };

            };

            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpDebugTime = 5;
                if (wallJumpDirection == "Left")
                {
                    if (jumpkey > walljumpMax)
                    {
                        jumpkey = walljumpMax;

                    };

                    rb.velocity = new Vector2(wallJumpSpeed, 1 + jumpkey);
                    jumpPower.fillAmount = 0;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    wallJumpDirection = "";
                    jumpPoint.transform.position = new Vector2(rb.transform.position.x + -wallDistance, rb.transform.position.y);
                    Debug.Log(jumpPoint.transform.position);
                    Instantiate(jumpParticles, jumpPoint.transform);
                    //isWalljumprun = true;
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        Invoke("wallJumpLeft", 0.1f);
                    };


                };


                if (wallJumpDirection == "Right")
                {
                    if (jumpkey > walljumpMax)
                    {
                        jumpkey = walljumpMax;

                    };

                    rb.velocity = new Vector2(-wallJumpSpeed, 1 + jumpkey);
                    jumpPower.fillAmount = 0;
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    wallJumpDirection = "";
                    jumpPoint.transform.position = new Vector2(rb.transform.position.x + wallDistance, rb.transform.position.y);
                    Debug.Log(jumpPoint.transform.position);
                    Instantiate(jumpParticles, jumpPoint.transform);
                    //isWalljumprun = true;
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        Invoke("wallJumpRight", 0.05f);
                    };


                };


            };
        }


    }

    void wallJumpRight()
    {
        rb.velocity = new Vector2(wallJumpSpeed, 1 + jumpkey);
        jumpPower.fillAmount = 0;
        transform.eulerAngles = new Vector3(0, 0, 0);


    }
    void wallJumpLeft()
    {
        rb.velocity = new Vector2(-wallJumpSpeed, 1 + jumpkey);
        jumpPower.fillAmount = 0;
        transform.eulerAngles = new Vector3(0, 0, 0);


    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (isKeyBoard)
        {


            if (other.gameObject.tag == "send")
            {
                point1 = other.gameObject.transform.GetChild(0).gameObject;
                point2 = other.gameObject.transform.GetChild(1).gameObject;

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    isKeyBoard = false;
                    levelnum += 1;
                    levestr.text = "LEVEL " + levelnum;
                    rb.transform.position = new Vector2(point1.transform.position.x, point1.transform.position.y);
                    isSendMove = true;
                    rb.isKinematic = true;
                    rb.transform.localScale = new Vector2(rb.transform.localScale.x - 0.02f, rb.transform.localScale.y + 0.01f);

                };



            }


            if (other.gameObject.tag == "bullet")
            {

                rb.transform.position = spawnPoint;
            }
        }
    }

    public void ladder(int a, bool s)
    {


        playspeed = a;

        Debug.Log("ladder " + a);

        isladder = s;

    }

    void ladderfun()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.position = new Vector2(rb.transform.position.x - 0.05f, rb.transform.position.y);


        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.position = new Vector2(rb.transform.position.x + 0.05f, rb.transform.position.y);


        }
    }


}




