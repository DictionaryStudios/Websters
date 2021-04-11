using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class MyPlayerManager : MonoBehaviour
{
    PhotonView PV;

    void Awake(){
        PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PV.IsMine){
            CreatePlayer();
        }
    }
    void CreatePlayer(){
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "player"), Vector3.zero, Quaternion.identity );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
