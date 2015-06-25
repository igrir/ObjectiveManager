using UnityEngine;
using System.Collections;
using UniRx;

[System.Serializable]
public class ObjectiveThingsModel{
	public string Id;
	public string Name;
	public string Info;
	public BoolReactiveProperty Obtained;

	[System.Serializable]
	public class RequirementModel{
		public string objective_id;
		public string things_id;
		public BoolReactiveProperty Obtained;
	}
	
	public RequirementModel[] Requirements;

	public bool CheckThingsRequirements() {
		bool obtainedAll = true;

		foreach(RequirementModel rm in Requirements) {
			if (rm.Obtained.Value == false) {
				obtainedAll = false;
				break;
			}
		}

		return obtainedAll;
	}
	
}
