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
		private float timeSinceLastCigarette; // Hours


		public User(string firstName, string familyName, string sex, int age, int smokingTime, float timeSinceLastCigarette)
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

			if ( (string.Compare(sex, "male") == 0) || (string.Compare(sex, "female") == 0))
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


		public JSONClass getJson()
		{	
			JSONClass jsonToReturn = new JSONClass();

			jsonToReturn["first_name"] 							= firstName;
			jsonToReturn["family_name"]							= familyName;
			jsonToReturn["sex"] 								= sex;
			jsonToReturn["age"].AsInt 							= age;
			jsonToReturn["smoking_time"].AsInt 					= smokingTime;
			jsonToReturn["time_since_last_cigarette"].AsFloat 	= timeSinceLastCigarette;

			return jsonToReturn;
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