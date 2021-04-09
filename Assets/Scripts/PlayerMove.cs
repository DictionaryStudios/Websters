using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public GameObject body;
    private Rigidbody torso;
    public float speed = 5.0f;
    public float jumppower = 9;
    private bool touchfeet;
    // Start is called before the first frame update
    void Start()
    {
       torso  = body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
