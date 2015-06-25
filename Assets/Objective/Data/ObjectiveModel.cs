using UnityEngine;
using System.Collections;
using UniRx;

[System.Serializable]
public class ObjectiveModel{
	public string Id;
	public string Name;
	public string Info;
	public BoolReactiveProperty Finished;

	public IntReactiveProperty ObjectiveNum;

	public ObjectiveThingsModel[] Objects;
	
	public void Initialize() {

		ObjectiveNum.Value = Objects.Length;

		foreach(ObjectiveThingsModel otm in Objects) {

			//observe everything in objectivethings model
			otm.Obtained.Where (obtained => obtained == true)
				.Subscribe(_ =>
	           	{
					ObjectiveNum.Value--;
				});

		}

		//observe finished
		ObjectiveNum.Where(x => x <= 0).
			Subscribe(_=>{
				Finished.Value = true;
			});

	}
}