using UnityEngine;
using System.Collections;
using SimpleJSON;


namespace DataModel{

	public class User {

		private string firstName;
		private string familyName;
		private string sex; // male or female
		private string age; //years
		private string smokingTime; //how long has he been smoking for. Years
		private int timeSinceLastCigarette; // Hours
		private int score;


		public User(string firstName, string familyName, string sex, string age, string smokingTime, int timeSinceLastCigarette, int score)
		{
			if (firstName != null)
			{
				this.firstName = firstName;
			}
			else
			{
				this.firstName = "empty";
			}

			if (familyName != null)
			{
				this.familyName = familyName;
			}
			else
			{
				this.familyName = "empty";
			}

			if ( (string.Compare(sex, "M") == 0) || (string.Compare(sex, "F") == 0))
			{
				this.sex = sex;
			}
			else
			{
				this.sex = "";
			}


			this.age = age;
			


			this.smokingTime = smokingTime;
		

			if ( timeSinceLastCigarette > 0)
			{
				this.timeSinceLastCigarette = timeSinceLastCigarette;
			}
			else
			{
				this.timeSinceLastCigarette = -1;
			}

			this.score = score;
		}


		public JSONClass writeUserInJson()
		{
            JSONClass obj = new JSONClass();
			obj["first_name"] 							= "";
            obj["family_name"] = "";
            obj["sex"] = sex;
            obj["age"] = age;
            obj["smoking_time"] = smokingTime;
            obj["time_since_last_cigarette"].AsInt = 0;
			obj ["form_score"].AsInt = score;

            return obj;
		}



		public string FirstName{
			get{ 
				return firstName;
			}
		}


		public string FamilyName{
			get{ 
				return familyName;
			}
		}

		public string Sex{
			get{ 
				return sex;
			}
		}

		public string Age{
			get{ 
				return age;
			}
		}
		
		public string SmokingTime{
			get{ 
				return smokingTime;
			}
		}

		public float TimeSinceLastCigarette{
			get{ 
				return timeSinceLastCigarette;
			}
		}

	}
}