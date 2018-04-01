using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWork_Controller : MonoBehaviour
{

    private string _gameVersion = "0.1";
    public GameObject titouanprefab;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
    }

    void Update()
    {

    }

    void OnJoinedLobby()
    {
        Debug.Log("On tente une connexion à une Room aléatoire!");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can not join random room.");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("You joined a Room!");
        PhotonNetwork.Instantiate("Prefabs/" + titouanprefab.name, titouanprefab.transform.position, Quaternion.identity, 0);
    }
}
