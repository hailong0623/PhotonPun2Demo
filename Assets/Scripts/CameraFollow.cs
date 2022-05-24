using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviour
{
    public PhotonNetworkLancher pnl;
    private GameObject player;
    private Vector3 offset;
    private float smoothSpeed = 3.0f;
    private PhotonView photonView;


    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(pnl ==null)
        {
            return; 
        }
        if(pnl.isPlayerInit)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            offset = transform.position - player.transform.position;
            photonView = player.GetComponent<PhotonView>();
            pnl.isPlayerInit = false;
        }
        if (photonView == null)
            return;
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        Vector3 targetPosition = player.transform.position + player.transform.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.fixedDeltaTime);
        transform.LookAt(player.transform.position);
    }
}
