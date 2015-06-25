using UnityEngine;
using System.Collections;

public class ObjectiveSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUILayout.Button("Fire"))
		{
			EventManager.Instance.TriggerEvent(new ObjectiveEvent("Cooking", "Fire"));
		}

		if (GUILayout.Button("Cook"))
		{
			EventManager.Instance.TriggerEvent(new ObjectiveEvent("Cooking", "Cook"));
		}

		if (GUILayout.Button("Eat"))
		{
			EventManager.Instance.TriggerEvent(new ObjectiveEvent("Cooking", "Eat"));
		}
	}
}
