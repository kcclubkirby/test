using UnityEngine;
using System.Collections;

public class TriggerCube : MonoBehaviour {

	private GameObject trigger;
	private CharacterMotor playerMovement;
	private bool beginCharacterCrouch = false;
	private Vector3 positionDiff;

	private const float acceptedRange = 0.05f;
	private const float crouchVal = 0.2f;

	void OnTriggerEnter(Collider other){
		trigger = other.gameObject;

		int x;
		if (trigger)
		{
			playerMovement = trigger.GetComponent<CharacterMotor>();
			if (playerMovement)
			{
				playerMovement.movement.maxForwardSpeed = 0;
				playerMovement.movement.maxSidewaysSpeed = 0;
				playerMovement.movement.maxBackwardsSpeed = 0;
				playerMovement.movement.maxGroundAcceleration = 0;
				playerMovement.movement.maxAirAcceleration = 0;
				playerMovement.movement.gravity = 0;
				playerMovement.movement.maxFallSpeed = 0;
				playerMovement.SetVelocity(Vector3.zero);
				beginCharacterCrouch = true;
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (beginCharacterCrouch)
		{
			positionDiff = trigger.transform.position - transform.position;
			positionDiff.y = trigger.transform.position.y - crouchVal;
			if (positionDiff.x > acceptedRange)
			{
				Vector3 pos = trigger.transform.position;
				pos.x = trigger.transform.position.x - acceptedRange;
				trigger.transform.position = pos;
			}
			else if (positionDiff.x < -acceptedRange)
			{
				Vector3 pos = trigger.transform.position;
				pos.x = trigger.transform.position.x + acceptedRange;
				trigger.transform.position = pos;
			}
			if (positionDiff.y > acceptedRange)
			{
				Vector3 pos = trigger.transform.position;
				pos.y = trigger.transform.position.y - acceptedRange;
				trigger.transform.position = pos;
			}
			else if (positionDiff.y < -acceptedRange)
			{
				Vector3 pos = trigger.transform.position;
				pos.y = trigger.transform.position.y + acceptedRange;
				trigger.transform.position = pos;
			}
			if (positionDiff.z > acceptedRange)
			{
				Vector3 pos = trigger.transform.position;
				pos.z = trigger.transform.position.z - acceptedRange;
				trigger.transform.position = pos;
			}
			else if (positionDiff.z < -acceptedRange)
			{
				Vector3 pos = trigger.transform.position;
				pos.z = trigger.transform.position.z + acceptedRange;
				trigger.transform.position = pos;
			}
		}
		int x;
		x = 0;
	}
}
