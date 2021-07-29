using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {
	//This Script could be added straight to the player script

	//Distance the player keeps from the rope
	float dist = 0f;
	void OnTriggerEnter2D (Collider2D other)
	{
     
		//Checking if the object has parent object (Parts of rope are children of the rope)
		if (other.gameObject.transform.parent != null) {

			//Checking if the collider is a rope and that the player is not swinging
			if (other.gameObject.transform.parent.name.StartsWith ("Rope") &&
			    other.gameObject.transform.parent.gameObject.GetComponent<RopeGrabbed> ().grabbed == false) {
				RopeGrabbed grabscript = other.gameObject.transform.parent.gameObject.GetComponent<RopeGrabbed> ();

				//We create a new distance joint between the player and the rope
				var joint = gameObject.AddComponent <DistanceJoint2D> ();
				joint.connectedBody = other.GetComponent<Rigidbody2D> ();
				joint.autoConfigureConnectedAnchor = true;
				joint.distance = dist;

				//Set the rope as grabbed
				grabscript.grabbed = true;
				//Change the player state to swinging
				this.gameObject.GetComponent<Player> ().ManageState(Player.State.State_Swinging);

			}
        }
    }
    }
