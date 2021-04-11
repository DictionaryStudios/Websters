using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
using Photon.Realtime;

public class MyGameManager : MonoBehaviourPunCallbacks
{
    public static MyGameManager InstanceVar;

    public void Awake(){
        InstanceVar = this;
    }

    string myRoomName = "Test Room";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Master (Photon Servers)");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to Photon, joining Lobby");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby(){
        Debug.Log("Joined Lobby");
    }

    public void CreateRoom(){
        if(string.IsNullOrEmpty(myRoomName)){
            return;
        }
        PhotonNetwork.CreateRoom(myRoomName);
    }

    public void JoinRoom(){

        PhotonNetwork.JoinRoom("Test Room");
        Debug.Log("I joined the room");
    }

    public void StartGame(){
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinedRoom(){
        Debug.Log("Joined room:  " +PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnCreateRoomFailed(short returnCode, string message){
        Debug.Log("Errorcode is " + returnCode);
        Debug.Log("Error message is " + message);
        
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList){

        for(int i = 0; i < roomList.Count; i++){
            Debug.Log("Room number: " + i + "\n" +roomList[i].Name);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
