using UnityEngine;
using System.Collections;
using System;
using SimpleJSON;

namespace DataModel
{
	public class FocusEvent {

		private string objectName;
		private float enteredFocusTime;
		private float exitFocusTime;

		public FocusEvent(string name, float enterTime, float exitTime){
			this.objectName = name;
			this.enteredFocusTime = enterTime;
			this.exitFocusTime = exitTime;
		}

		public string ObjectName{
			get{ 
				return objectName;
			}

		}

		public float EnteredFocusTime{
			get{
				return enteredFocusTime;
			}
		}


		public float ExitFocusTime{
			get{
				return exitFocusTime;
			}
		
		}

		public JSONClass getJson(){
			JSONClass jsonToReturn = new JSONClass ();

			DateTime gameStart = DateTime.Now.Subtract(TimeSpan.FromSeconds(Time.realtimeSinceStartup)); 
			DateTime enterTime = gameStart.AddSeconds(enteredFocusTime);
			DateTime exitTime = gameStart.AddSeconds(exitFocusTime);
			
			enterTime = enterTime.ToLocalTime();
			exitTime = exitTime.ToLocalTime();

			jsonToReturn ["name"] = objectName;
			jsonToReturn ["entered_focus_time"] = enterTime.ToLongTimeString();
			jsonToReturn ["exit_focus_time"] = exitTime.ToLongTimeString();
			jsonToReturn ["duration"].AsFloat = exitFocusTime - enteredFocusTime; 

			return jsonToReturn;
			
		}

	}
}