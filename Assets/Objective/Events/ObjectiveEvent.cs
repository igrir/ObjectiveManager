using UnityEngine;
using System.Collections;

public class ObjectiveEvent : GameEvent {

	public string ObjectiveId;
	public string ObjectiveThingsId;

	public ObjectiveEvent(string ObjectiveId, string ObjectiveThingsId) {
		this.ObjectiveId = ObjectiveId;
		this.ObjectiveThingsId = ObjectiveThingsId;
	}
}
