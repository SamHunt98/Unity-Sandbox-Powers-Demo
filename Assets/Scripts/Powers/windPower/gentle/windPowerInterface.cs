using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface windPowerInterface 
{
    //any object that interacts with the wind power will use this interface to see how it reacts to either the strong wind power or the gentle wind power
    void gentleWind();

    void strongWind();
}
