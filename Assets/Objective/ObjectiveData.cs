using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;

public class ObjectiveData : MonoBehaviour {
	
	public List<ObjectiveModel> Objectives;

	// Use this for initialization
	void Start () {

		//initialize observation in every model
		foreach(ObjectiveModel om in Objectives) {
			om.Initialize();

			//observe every requirements
			ObjectiveThingsModel[] things = om.Objects;
			foreach(ObjectiveThingsModel thing in things){

				ObjectiveThingsModel.RequirementModel[] requirements = thing.Requirements;

				foreach(ObjectiveThingsModel.RequirementModel rm in requirements) {


					ObjectiveThingsModel rm_otm = GetObjectiveThingsModel(rm.objective_id, rm.things_id);

					rm_otm.Obtained.Where(Obtained => Obtained == true)
						.Subscribe(x=>{
							rm.Obtained.Value = true;
						});

					rm_otm.Obtained.Where(Obtained => Obtained == false)
						.Subscribe(x=>{
							rm.Obtained.Value = false;
						});



				}

			}

//			ObjectiveThingsModel.RequirementModel[] requirements = otm.Requirements;
		}



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public ObjectiveModel GetObjectiveModel(string id) {
		foreach(ObjectiveModel om in Objectives) {
			//found
			if (String.Equals(om.Id, id)) {
				return om;
			}
		}
		//not found
		return null;
	}

	public ObjectiveThingsModel GetObjectiveThingsModel(string id, ObjectiveModel om) {
		foreach(ObjectiveThingsModel otm in om.Objects) {
			//found
			if (String.Equals(otm.Id, id)) {
				return otm;
			}
		}
		//not found
		return null;
	}

	public ObjectiveThingsModel GetObjectiveThingsModel(string objective_id, string things_id) {

		ObjectiveModel om = GetObjectiveModel(objective_id);

		foreach(ObjectiveThingsModel otm in om.Objects) {
			//found
			if (String.Equals(otm.Id, things_id)) {
				return otm;
			}
		}
		//not found
		return null;
	}
//
//	public bool CheckThingsRequirements(string objectiveId, string thingsId) {
//
//
//		ObjectiveModel om = GetObjectiveModel(objectiveId);
//		ObjectiveThingsModel otm = GetObjectiveThingsModel(thingsId, om);
//
//		ObjectiveThingsModel.RequirementModel[] requirements = otm.Requirements;
//
//		bool obtainedAll = true;
//
//		//check there's unobtained things
//		foreach(ObjectiveThingsModel.RequirementModel rm in requirements) {
//
//			ObjectiveModel rm_om = GetObjectiveModel(rm.objective_id);
//			ObjectiveThingsModel rm_otm = GetObjectiveThingsModel(rm.things_id, rm_om);
//
//			if (!rm_otm.Obtained.Value) {
//				obtainedAll = false;
//				break;
//			}
//		}
//
//		return obtainedAll;
//
//	}
}
