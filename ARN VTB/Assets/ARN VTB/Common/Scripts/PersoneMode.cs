using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PersoneModeType
{
    fiz,
    ur,
    vip
}


public class PersoneMode
{
    public const string PLAYER_PREFS_KEY = "PersonMode";

    static bool isLoad = false;
    static PersoneModeType lastValue;
    public static PersoneModeType current
    {
        get
        {
            if (isLoad)
            {
                return lastValue;
            }
            else
            {
                if (PlayerPrefs.HasKey(PLAYER_PREFS_KEY))
                {
                    lastValue = (PersoneModeType) PlayerPrefs.GetInt(PLAYER_PREFS_KEY);
                    isLoad = true;
                    return lastValue;
                }
                else
                {
                    return PersoneModeType.fiz;
                }
            }
        }

        set
        {
            lastValue = value;
            isLoad = true;
            PlayerPrefs.SetInt(PLAYER_PREFS_KEY, (int) value);
        }
    }
}
