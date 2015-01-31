using UnityEngine;
using System.Collections;
using Ovr;

public class CPRChest : MonoBehaviour {

	//The chest dummy
	public GameObject chestDummy;
	private CPRChest chestComponent;
	
	//The triggering collider and its components
	private GameObject trigger;
	private palmClass palm;

	//The boolean which activates the CPR section of the game
	public bool readyForInteraction = false;

	//The objects created when touched
	private static GameObject Victory;

	//Triggers when something collides with the box
	void OnTriggerEnter(Collider other){
		//If the simulation part has begun
		if (readyForInteraction)
		{
			trigger = other.gameObject; //saves the triggering object
			if (trigger) //if it is an object
			{
				//then save it as a palm
				palm = trigger.GetComponent<palmClass>();
				if (palm) //if it is a palm
				{
					OVRUGUI.UIObjectManager(Victory,"Victory",-55,"Victory!! Congratulations!",20,
					                        new Color(7f / 255f, 90f / 255f, 41f / 255f, 200f / 255f));
				}
			}
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
