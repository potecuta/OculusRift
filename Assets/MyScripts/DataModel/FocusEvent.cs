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

		public FocusEvent(string name, string type, string location, float enterTime){
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
			jsonToReturn ["entered_time"] = formatDate(enterTime);

			Debug.Log(formatDate(enterTime));
			jsonToReturn ["exit_time"] = formatDate(exitTime);
            float duratie = exitFocusTime - enteredFocusTime;
			jsonToReturn ["duration"].AsInt = (int)duratie; 

			return jsonToReturn;
			
		}

		private string formatDate(DateTime time)
		{
			string stringToReturn = "";

			stringToReturn = time.Year.ToString () + '-';
			if (time.Month < 10) {
				stringToReturn += '0' + time.Month.ToString() + '-';
			} else {
				stringToReturn += time.Month.ToString() + '-';
			}
			if (time.Day < 10) {
				stringToReturn += '0' + time.Day.ToString();
			} else {
				stringToReturn += time.Day.ToString();
			}
		
			stringToReturn += 'T';
			if (time.Hour < 10) {
				stringToReturn += '0' + time.Hour.ToString() + ':';
			} else {
				stringToReturn += time.Hour.ToString()+ ':';
			}
			if (time.Minute < 10) {
				stringToReturn += '0' + time.Minute.ToString() + ':';
			} else {
				stringToReturn += time.Minute.ToString()+ ':';
			}
			if (time.Second < 10) {
				stringToReturn += '0' + time.Second.ToString() + 'Z';
			} else {
				stringToReturn += time.Second.ToString() + 'Z';
			}

			return stringToReturn;
		}
	}
}