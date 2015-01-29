using UnityEngine;
using System.Collections;

public class TriggerCube : MonoBehaviour {

	//The chest dummy
	public GameObject chestDummy;
	private CPRChest chestComponent;

	//The triggering collider and its components
	private GameObject trigger;
	private OVRPlayerController playerMovement;
	private OVRMainMenu menu;

	//The boolean to make the player crouch in front of the CPR dummy
	private bool beginCharacterCrouch = false;

	//Constants for the accepted range for values to be and for how low to crouch
	private const float acceptedRange = 0.05f;
	private const float crouchVal = 0.7f;

	//Triggers when something collides with the box
	void OnTriggerEnter(Collider other){
		trigger = other.gameObject; //saves the triggering object
		if (trigger) //if it is an object
		{
			//then save it as a Player Controller
			playerMovement = trigger.GetComponent<OVRPlayerController>();
			if (playerMovement) //if it is player-controlled
			{
				//then halt the player movement
				playerMovement.SetHaltUpdateMovement(true);
				menu = trigger.GetComponent<OVRMainMenu>();
				if (menu)
					menu.haltMovement = true;

				beginCharacterCrouch = true; //begin the player crouching sequence
			}
		}
	}

	// Use this for initialization
	void Start () {
		//set the Chest component
		chestComponent = chestDummy.GetComponentInChildren<CPRChest>();
	}
	
	// Update is called once per frame
	void Update () {
		//Player Crouching Sequence
		if (beginCharacterCrouch)
		{
			//Create check booleans
			bool xCheck = true;
			bool yCheck = true;
			bool zCheck = true;

			//Find the difference between where the player is and where it should be
			Vector3 positionDiff;
			positionDiff = trigger.transform.position - transform.position;
			positionDiff.y = trigger.transform.position.y - crouchVal;

			//If it is within the accepted range for the axis, do nothing.
			//Otherwise, inch the player closer.
			if (positionDiff.x > acceptedRange)
			{
				xCheck = false;
				Vector3 pos = trigger.transform.position;
				pos.x = trigger.transform.position.x - acceptedRange;
				trigger.transform.position = pos;
			}
			else if (positionDiff.x < -acceptedRange)
			{
				xCheck = false;
				Vector3 pos = trigger.transform.position;
				pos.x = trigger.transform.position.x + acceptedRange;
				trigger.transform.position = pos;
			}
			if (positionDiff.y > acceptedRange)
			{
				yCheck = false;
				Vector3 pos = trigger.transform.position;
				pos.y = trigger.transform.position.y - acceptedRange;
				trigger.transform.position = pos;
			}
			else if (positionDiff.y < -acceptedRange)
			{
				yCheck = false;
				Vector3 pos = trigger.transform.position;
				pos.y = trigger.transform.position.y + acceptedRange;
				trigger.transform.position = pos;
			}
			if (positionDiff.z > acceptedRange)
			{
				zCheck = false;
				Vector3 pos = trigger.transform.position;
				pos.z = trigger.transform.position.z - acceptedRange;
				trigger.transform.position = pos;
			}
			else if (positionDiff.z < -acceptedRange)
			{
				zCheck = false;
				Vector3 pos = trigger.transform.position;
				pos.z = trigger.transform.position.z + acceptedRange;
				trigger.transform.position = pos;
			}

			//If the player is in the right place
			if (xCheck && yCheck && zCheck)
			{
				beginCharacterCrouch = false; //turn off crouching sequence
				chestComponent.readyForInteraction = true; //turn on CPR sequence
			}
		}
	}
}
