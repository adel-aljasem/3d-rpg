using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviourPunCallbacks
{
    public Dictionary<int, ITeam> TeamDictionary = new Dictionary<int, ITeam>();


    RedTeam redTeam = new RedTeam();
    BlueTeam blueTeam = new BlueTeam();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        AssaginPlayerToTeam();


        

    }


    private void AssaginPlayerToTeam()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                float randomTeam = Random.Range(1, 2);

                if (randomTeam == 1)
                {
                    TeamDictionary.Add(PhotonNetwork.PlayerList[i].ActorNumber, redTeam);
                }
                else
                {
                    TeamDictionary.Add(PhotonNetwork.PlayerList[i].ActorNumber, blueTeam);
                }

            }
        }
    }


    public void CheckMyTeam()
    {
        if (!photonView.IsMine) return;
        for (int i = 0; i < TeamDictionary.Count; i++)
        {

        }
    }
       

}
