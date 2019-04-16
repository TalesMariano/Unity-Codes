//Referencias
// https://stackoverflow.com/questions/53802200/unity-c-sharp-convert-date-string-to-datetime-object-in-desired-date-time-format


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

}
