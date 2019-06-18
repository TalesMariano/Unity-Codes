/// References
/// https://stackoverflow.com/questions/6366408/calculating-distance-between-two-latitude-and-longitude-geocoordinates/6366657
/// Awnser by: https://stackoverflow.com/users/2167804/david-leitner
/// https://docs.unity3d.com/ScriptReference/LocationService.Start.html

using System.Collections;
using UnityEngine;
using TMPro;


public class Location : MonoBehaviour
{
    public GameObject loading;

    public GameObject noGPS;
    public GameObject notEvent;
    public TMP_Text textt;

    public float lati = -23.5233368f;
    public float longi = -46.6147834f;

    float radiosKm = 0.5f;

    IEnumerator Start()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            loading.SetActive(false);
            noGPS.SetActive(true);
            yield break;
        }
            

        // Start service before querying location
        Input.location.Start(10);

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            textt.text = ("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //print("Unable to determine device location");
            loading.SetActive(false);
            noGPS.SetActive(true);
            yield break;
        }
        else
        {
            /*
            // Access granted and location value could be retrieved
            textt.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
            textt.text += ("\n\n Location 2: " + lati + " " + longi);
            //Calculate_Distance(Input.location.lastData.longitude, Input.location.lastData.latitude, longi, lati);
            DistanceTo(Input.location.lastData.latitude, Input.location.lastData.longitude, lati, longi);*/

            loading.SetActive(false);
            

            if (DistanceTo(Input.location.lastData.latitude, Input.location.lastData.longitude, lati, longi) > radiosKm)
            {
                notEvent.SetActive(true);
            }


        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
    /*
    float DegToRad(float deg)
    {
        float temp;
        temp = (deg * Mathf.PI) / 180.0f;
        temp = Mathf.Tan(temp);
        return temp;
    }

    float Distance_x(float lon_a, float lon_b, float lat_a, float lat_b)
    {
        float temp;
        float c;
        temp = (lat_b - lat_a);
        c = Mathf.Abs(temp * Mathf.Cos((lat_a + lat_b)) / 2);
        return c;
    }

    private float Distance_y(float lat_a, float lat_b)
    {
        float c;
        c = (lat_b - lat_a);
        return c;
    }

    float Final_distance(float x, float y)
    {
        float c;
        c = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f))) * 6371;
        return c;
    }

    //*******************************
    //This is the function to call to calculate the distance between two points

    public void Calculate_Distance(float long_a, float lat_a, float long_b, float lat_b)
    {
        float a_long_r, a_lat_r, p_long_r, p_lat_r, dist_x, dist_y, total_dist;
        a_long_r = DegToRad(long_a);
        a_lat_r = DegToRad(lat_a);
        p_long_r = DegToRad(long_b);
        p_lat_r = DegToRad(lat_b);
        dist_x = Distance_x(a_long_r, p_long_r, a_lat_r, p_lat_r);
        dist_y = Distance_y(a_lat_r, p_lat_r);
        total_dist = Final_distance(dist_x, dist_y);
        //prints the distance on the console
        textt.text += ("\n\n Distancia " + total_dist + "km");
        textt.text += ("\n\n Petz");

    }*/

    public /*static*/ float DistanceTo(float lat1, float lon1, float lat2, float lon2/*, char unit = 'K'*/)
    {
        float rlat1 = Mathf.PI * lat1 / 180;
        float rlat2 = Mathf.PI * lat2 / 180;
        float theta = lon1 - lon2;
        float rtheta = Mathf.PI * theta / 180;
        float dist =
            Mathf.Sin(rlat1) * Mathf.Sin(rlat2) + Mathf.Cos(rlat1) *
            Mathf.Cos(rlat2) * Mathf.Cos(rtheta);
        dist = Mathf.Acos(dist);
        dist = dist * 180 / Mathf.PI;
        dist = dist * 60 * 1.1515f * 1.609344f;
        /*
        switch (unit)
        {
            case 'K': //Kilometers -> default
                return dist * 1.609344f;
            case 'N': //Nautical Miles 
                return dist * 0.8684f;
            case 'M': //Miles
                return dist;
        }*/

        //textt.text += ("\n\n Distancia " + dist + "km");

        return dist;
    }

}
