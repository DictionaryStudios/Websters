using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpandThrow : MonoBehaviour
{

    public GameObject startpoint;
    public GameObject endpoint;
    private Vector3 direction;
    public float yeetpwr;
    private bool isholdingitem = false;
    private GameObject helditem;
    private Rigidbody helditemrb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isholdingitem == true)
        {
            
            if (Input.GetKey("q"))
            {
                ThrowObject();

            }
        }

    }
     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "canpickup")
        {
            helditem = other.gameObject;
            helditemrb = helditem.GetComponent<Rigidbody>();
            Debug.Log("Press 'E' to Pick Up" + other.gameObject.name);
            if (Input.GetKey("e"))
            {
                if (isholdingitem == false)
                {

                    Debug.Log("Picked Up");

                    helditem.transform.SetParent(this.transform);
                    helditemrb.useGravity = false;
                    helditemrb.constraints = RigidbodyConstraints.FreezeRotation;
                    isholdingitem = true;
                }
                else if (isholdingitem == true)
                {
                    Debug.Log("Dropped " + helditem.gameObject.name);
                    helditem.transform.parent = null;
                    helditemrb.useGravity = true;
                    helditemrb.constraints = RigidbodyConstraints.None;
                    isholdingitem = false;
                }
            }
        }
    }
    void ThrowObject()
    {
        
       
        helditemrb = helditem.GetComponent<Rigidbody>();
        direction = endpoint.transform.position - startpoint.transform.position;
        helditem.transform.parent = null;
        helditemrb.useGravity = true;
        helditemrb.constraints = RigidbodyConstraints.None;
        // objectrb.AddForce(xray * yeetpwr,yray * yeetpwr, yeetpwr, ForceMode.Impulse);
        helditemrb.AddForce(direction * yeetpwr, ForceMode.Impulse);
        isholdingitem = false;
    }
}
