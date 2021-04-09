using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpandThrow : MonoBehaviour
{

    public GameObject startpoint;
    //usually the head of player or where the camera is located
    public GameObject endpoint;
    //the hand
    private Vector3 direction;
    public float yeetpwr;
    private bool isholdingitem = false;
    private GameObject helditem;
    private Rigidbody helditemrb;
    //rigidbody of object you pick up
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isholdingitem == true)
        {
            
            if (Input.GetKey("f"))
            {
                ThrowObject();

            }
            else if (Input.GetKey("q"))
            {
                 DropObject();
            }
        }
        

    }
     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "canpickup")
        {
            
            //Debug.Log("Press 'E' to Pick Up" + other.gameObject.name);
            if (Input.GetKeyDown("e"))
            {
                helditem = other.gameObject;
                helditemrb = helditem.GetComponent<Rigidbody>();
                
                if (isholdingitem == false)
                {
                    Debug.Log("Picked Up" + helditem.gameObject.name);
                    helditem.transform.SetParent(this.transform);
                    helditemrb.useGravity = false;
                    helditemrb.constraints = RigidbodyConstraints.FreezeRotation;
                    helditemrb.constraints = RigidbodyConstraints.FreezePosition;
                    isholdingitem = true;
                }
            }
        }
    }
    void ThrowObject()
    {
        
       
        //helditemrb = helditem.GetComponent<Rigidbody>();
        direction = endpoint.transform.position - startpoint.transform.position;
        helditem.transform.parent = null;
        helditemrb.useGravity = true;
        helditemrb.constraints = RigidbodyConstraints.None;
        helditemrb.AddForce(direction * yeetpwr, ForceMode.Impulse);
        isholdingitem = false;
    }
    void DropObject()
    {
        if (isholdingitem == true)
        {
            Debug.Log("Dropped " + helditem.gameObject.name);
            helditem.transform.parent = null;
            helditemrb.useGravity = true;
            helditemrb.constraints = RigidbodyConstraints.None;
            isholdingitem = false;
        }
    }
}
