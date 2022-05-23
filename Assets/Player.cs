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
    void Start()
    {
        animator = GetComponent<Animator>();  
        
    }

    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        animator.SetFloat(speed, Input.GetAxis("Vertical"));
        animator.SetFloat(horizontal, Input.GetAxis("Horizontal"));
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool(isRun, true);  
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool(isRun, false);
        }
    }
}
