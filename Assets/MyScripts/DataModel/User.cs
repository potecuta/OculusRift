using UnityEngine;
using System.Collections;
using SimpleJSON;


namespace DataModel{

	public class User {

		private string firstName;
		private string familyName;
		private string sex; // male or female
		private int age; //years
		private int smokingTime; //how long has he been smoking for. Years
		private int timeSinceLastCigarette; // Hours


		public User(string firstName, string familyName, string sex, int age, int smokingTime, int timeSinceLastCigarette)
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

			if ( age >= 18  && age < 100)
			{
				this.age = age;
			}
			else
			{
				this.age = -1;
			}

			if ( smokingTime > 0)
			{
				this.smokingTime = smokingTime;
			}
			else
			{
				this.smokingTime = -1;
			}

			if ( timeSinceLastCigarette > 0)
			{
				this.timeSinceLastCigarette = timeSinceLastCigarette;
			}
			else
			{
				this.timeSinceLastCigarette = -1;
			}
		}


		public JSONClass writeUserInJson()
		{
            JSONClass obj = new JSONClass();
			obj["first_name"] 							= firstName;
            obj["family_name"] = familyName;
            obj["sex"] = sex;
            obj["age"].AsInt = age;
            obj["smoking_time"].AsInt = smokingTime;
            obj["time_since_last_cigarette"].AsInt = timeSinceLastCigarette;

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

		public int Age{
			get{ 
				return age;
			}
		}
		
		public int SmokingTime{
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