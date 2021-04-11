using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPunCallbacks
{
    public GameObject body;
    private Rigidbody torso;
    public float speed = 5.0f;
    public float jumppower = 9;
    private bool touchfeet;

    PhotonView PV;

    // PhotonViewer PV;
    // Start is called before the first frame update
    void Awake()
    {
       torso  = body.GetComponent<Rigidbody>();
       PV = gameObject.GetComponentInParent<PhotonView>();
    }

    void Start(){
        if(!PV.IsMine){
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!PV.IsMine){
            return;
        }
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
        if(Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown("space"))
        {
            checkifgrounded();
            if (touchfeet == true)
            {
                torso.AddForce(transform.up * jumppower, ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown("left shift"))
        {
            speed = speed * 2;
        }
        if (Input.GetKeyUp("left shift"))
        {
            speed = speed / 2;
        }

    }
    void checkifgrounded ()
    {
        RaycastHit poke;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out poke, distance))
        {
            touchfeet = true;
        }
        else
        {
            touchfeet = false;
        }
    }
}
