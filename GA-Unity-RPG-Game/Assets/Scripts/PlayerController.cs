using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interactable focus;

    public LayerMask movementMask; //Filter out everyting not walkable

    Camera cam;         //Reference to our camera
    PlayerMotor motor;      //Referance to our motor

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}

	// Update is called once per frame
	void Update () {
	
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);    // Move our player to what we hit

                //Stop focusing any objekt
                RemoveFocus();

            }
        }

        // If we press right mouse
        if (Input.GetMouseButtonDown(1))
        {
            // We create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //check if we hit an interacible 
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                //if we did set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {

            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        
        newFocus.OnFocused(transform);
        
    }

    void RemoveFocus ()
    {
        if(focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }
}