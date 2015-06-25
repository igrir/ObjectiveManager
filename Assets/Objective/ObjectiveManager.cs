using UnityEngine;
using System.Collections;

public class ObjectiveManager : MonoBehaviour {

	public ObjectiveData ObjectiveLevelData;

	public void Start() {
		EventManager.Instance.AddListener<ObjectiveEvent>(ObjectiveEvent);
	}

	public void ObjectiveEvent(ObjectiveEvent e) {
		ObjectiveModel om = ObjectiveLevelData.GetObjectiveModel(e.ObjectiveId);
		ObjectiveThingsModel otm = ObjectiveLevelData.GetObjectiveThingsModel(e.ObjectiveThingsId, om);

		if (otm.CheckThingsRequirements()) {
			otm.Obtained.Value = true;
		}
	}



}
