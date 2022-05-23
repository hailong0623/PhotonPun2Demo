using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonNetworkLancher : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        //Debug.Log("wecome photon");

        PhotonNetwork.JoinOrCreateRoom("Room", new Photon.Realtime.RoomOptions() { MaxPlayers = 10 }, default);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
    }
}
