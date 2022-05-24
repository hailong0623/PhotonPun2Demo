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
    private Vector2 touchInval = Vector2.zero;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;

        //使用BlendTree
        //PC
        //animator.SetFloat(speedZ, Input.GetAxis("Vertical") * 4.1f);
        //animator.SetFloat(speedRotate, Input.GetAxis("Horizontal") * 126);


        if (Input.touchCount <= 0)
            return;
        //移动设备
        if (Input.touchCount <= 0)
            return;
        if (Input.touches[0].phase == TouchPhase.Moved)
        {
            touchInval = new Vector2(Input.touches[0].deltaPosition.x, Input.touches[0].deltaPosition.y);
            animator.SetFloat(speedZ, (touchInval.y <= -1 ? -1 : touchInval.y >= 1 ? 1 : touchInval.y) * 4.1f);
            animator.SetFloat(speedRotate, (touchInval.x <= -1 ? -1 : touchInval.x >= 1 ? 1 : touchInval.x) * 126);
        }
        if (Input.touches[0].phase == TouchPhase.Ended)
        {
            animator.SetFloat(speedZ, 0);
            animator.SetFloat(speedRotate, 0);  
        }


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
