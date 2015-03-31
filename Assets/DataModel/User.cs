using UnityEngine;
using System.Collections;

public class User : MonoBehaviour {

	private string name;
	private string sex; // male or female
	private int age; //years
	private int smokingTime; //how long has he been smoking for. Years
	private float timeSinceLastCigarette; // Hours



	public string Name{
		get{ 
			return name;
		}
		set{
			if ( value != null)
			{
				name = value;
			}
		}
	}

	public string Sex{
		get{ 
			return sex;
		}
		set{
			if ( (string.Compare(value, "male") == 0) || (string.Compare(value, "female") == 0))
			{
				sex = value;
			}
		}
	}

	public int Age{
		get{ 
			return age;
		}
		set{
			if ( value >= 18  && value < 100)
			{
				age = value;
			}
		}
	}
	
	public int SmokingTime{
		get{ 
			return smokingTime;
		}
		set{
			if ( value != null)
			{
				smokingTime = value;
			}
		}
	}

	public float TimeSinceLastCigarette{
		get{ 
			return timeSinceLastCigarette;
		}
		set{
			if ( value != null)
			{
				timeSinceLastCigarette = value;
			}
		}
	}
}
