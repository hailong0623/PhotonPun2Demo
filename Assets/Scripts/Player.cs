using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    private Animator animator;
    private int speed = Animator.StringToHash("Speed");
    private int isRun = Animator.StringToHash("IsRun");
    private int horizontal = Animator.StringToHash("Horizontal");
    private int speedRotate = Animator.StringToHash("SpeedRotate");
    private int speedZ = Animator.StringToHash("SpeedZ");


    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        //使用BlendTree
        animator.SetFloat(speedZ, Input.GetAxis("Vertical") * 4.1f);
        animator.SetFloat(speedRotate, Input.GetAxis("Horizontal") * 126);

        //未使用BlendTree
        //animator.SetFloat(speed, Input.GetAxis("Vertical")* 4.1f);
        //animator.SetFloat(horizontal, Input.GetAxis("Horizontal"));
        //if(Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    animator.SetBool(isRun, true);  
        //}
        //if(Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    animator.SetBool(isRun, false);
        //}
    }
}
