//Referencias
// https://stackoverflow.com/questions/53802200/unity-c-sharp-convert-date-string-to-datetime-object-in-desired-date-time-format
// See later:
// https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// convert 156 to 02:36

public class TimerConvert : MonoBehaviour {

	public string ConvertTimeString ( float durationTime) {
		string minutes = Mathf.Floor((int)durationTime / 60).ToString("00");
		string seconds = ((int)durationTime % 60).ToString("00");

		return (minutes + ":" + seconds);
	}
	
	void OtherThing(){
		DateTime dt = DateTime.Now;
        	Debug.Log(dt.ToString("dd/MM/yyyy"));
	}

}
