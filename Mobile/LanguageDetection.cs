using UnityEngine;

public class LanguageDetection : MonoBehaviour

    string langRegion;

    void Awake()
    {
        langRegion = GetLocaleCode();

        if (langRegion == "es_AR")
        {

        }
        else if (Application.systemLanguage == SystemLanguage.Spanish)
        {

        }
        else
        {
            //globalLanguage = ptBr;
        }

    }
    
        private static string GetLocaleCode()
    {
        // Default locale
        string localeVal = "pt_BR";

#if UNITY_IPHONE
        localeVal = EtceteraBinding.getCurrentLocale();
        string langVal = EtceteraBinding.getCurrentLanguage();
        if( langVal != null )
        {
            if( langVal.Length == 5 )
            {
                localeVal = langVal;
            }
            else
            {
                if( ( langVal.Length == 2 ) && ( localeVal.Length == 5 ) )
                {
                    localeVal = localeVal.Substring( 2 , 3 );
                    localeVal = langVal + localeVal;
                }
            }
        }
#endif

#if UNITY_ANDROID
        using (AndroidJavaClass cls = new AndroidJavaClass("java.util.Locale"))
        {
            if (cls != null)
            {
                using (AndroidJavaObject locale = cls.CallStatic<AndroidJavaObject>("getDefault"))
                {
                    if (locale != null)
                    {
                        localeVal = locale.Call<string>("getLanguage") + "_" + locale.Call<string>("getCountry");
                        Debug.Log("Android lang: " + localeVal);
                    }
                    else
                    {
                        Debug.Log("locale null");
                    }
                }
            }
            else
            {
                Debug.Log("cls null");
            }
        }
#endif
        Debug.Log("Locale: " + localeVal);
        return (localeVal);
    }
}
