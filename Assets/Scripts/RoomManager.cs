using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager :  MonoBehaviourPunCallbacks
{
    public static RoomManager Instance; 
    // Start is called before the first frame update
    void Start()
    {
        if(Instance){
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;

    }

    public override void OnEnable() {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    public override void OnDisable() {
        base.OnDisable();
    }

    void OnSceneLoaded(Scene scene,  LoadSceneMode loadSceneMoad){
        if(scene.buildIndex == 1){
            Debug.Log("worked?");
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
