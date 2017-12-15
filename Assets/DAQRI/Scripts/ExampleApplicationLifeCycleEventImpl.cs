//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.

using UnityEngine;
using DAQRI;

//ApplicationEventHandler inherits from Monodevelop
public class ExampleApplicationLifeCycleEventImpl : ApplicationEventHandler 
{
    public override void OnApplicationLoad()
    {
        //Implement logic which should happen on Application load
        //Memory allocations, Initialization logic goes here
    }

    public override void OnApplicationForeground()
    {
        //Implement logic which should happen on Application un pause
    }

    public override void OnApplicationBackground()
    {
        //Implement logic which should happen on Application pause
    }

    public override void OnApplicationStop()
    {
        //Implement logic which should happen on Application un pause
        //Garbade collection
    }
}
