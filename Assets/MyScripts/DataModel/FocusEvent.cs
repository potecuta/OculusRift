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
        private string location;
        private string type;

		public FocusEvent(string name, string type, string location, float enterTime, float exitTime){
            if (location.Length == 0)
            {
                location = "NA";
            }
            if(name.Length == 0)
            {
                name = "NA";
            }
            if (type.Length == 0)
            {
                type = "NA";
            }
            
            this.objectName = name;
            this.type = type;
            this.location = location;
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
            jsonToReturn ["location"] = location;
            jsonToReturn["type"] = type;
			//jsonToReturn ["entered_time"] = enterTime.ToString();
			//jsonToReturn ["exit_time"] = exitTime.ToString();
            double duratie = exitFocusTime - enteredFocusTime;
			jsonToReturn ["duration"].AsInt = (int)duratie; 

			return jsonToReturn;
			
		}

	}
}