using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviourPunCallbacks
{
    public GameObject player;


    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnected()
    {


        base.OnConnected();

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {

        PhotonNetwork.Instantiate(player.name,transform.position, transform.rotation);


        print("Joined room" + PhotonNetwork.CurrentRoom.Name);

    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        float random = Random.Range(0, 1000);

        PhotonNetwork.CreateRoom(random.ToString(), new RoomOptions { MaxPlayers = 5 }) ;

        PhotonNetwork.JoinRandomRoom();


        base.OnJoinRandomFailed(returnCode, message);
    }

    public override void OnCreatedRoom()
    {
        print(PhotonNetwork.CurrentRoom.Name + "Created");
    }





}
