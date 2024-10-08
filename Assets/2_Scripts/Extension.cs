using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    private const string format0N0 = "{0:N0}";
    private const string format0N1 = "{0:N1}";
    private const string format0N2 = "{0:N2}";
    private const string format0N3 = "{0:N3}";

    public static string ToString_Func(this float _value, int _pointNumber = 0)
    {
        if (0 < _pointNumber)
        {
            if (_pointNumber == 1)
            {
                return string.Format(format0N1, _value);
            }
            else if (_pointNumber == 2)
            {
                return string.Format(format0N2, _value);
            }
            else if (_pointNumber == 3)
            {
                return string.Format(format0N3, _value);
            }
            else
            {
                return _value.ToString();
            }
        }
        else
        {
            return string.Format(format0N0, _value);
        }
    }
}