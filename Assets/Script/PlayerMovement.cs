using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  //把CharacterController的Script帶進來 

    public float speed = 12f;               //設一個名爲speed的變數
    public float gravity = -9.81f * 2;      //設一個名爲gravity的變數
    public float jumpHeight = 3f;           //設一個jumpheight(跳的高度)

    public Transform groundCheck;           //有一個物件的transform(可放進inspector)叫groundcheck,(transform是object的位置,旋轉和大小) 我們需要groundcheck來檢查我們是否在地面,否則會在空中連續跳躍
    public float groundDistance = 0.4f;     //設一個groundcheck與地面的距離偵測raduis
    public LayerMask groundMask;            //設置一個layermask,名爲groundmask

    Vector3 velocity;                       //就player的movement,命名為velocity

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //從physics的class調取checksphere功能,創造一個偵測的球體,用groundcheck物件的transform(位置),偵測範圍為grounddistance,偵測到的layer為groundmask(groundmask會設爲地面)
        //so if 偵測到了groundmask, isgrounded as true

        if (isGrounded && velocity.y < 0) //if 在空中了
        {
            velocity.y = -2f;
        }
        //velocity vector 為-2f,以免下次下墜越來越快
        

        float x = Input.GetAxis("Horizontal"); //輸入input的左右值為 x
        float z = Input.GetAxis("Vertical");    //輸入input的前後值為 z

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z; //vectormove的數值

        controller.Move(move * speed * Time.deltaTime); //把vectormove作用在cahractercontrollercomponent上,also以時間進行更新(deltatime)

        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
