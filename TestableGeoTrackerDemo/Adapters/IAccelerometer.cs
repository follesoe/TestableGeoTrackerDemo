//===============================================================================
// Microsoft patterns & practices
// Building Testable Windows Phone Applications
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// This code released under the terms of the 
// Microsoft patterns & practices license (http://wp7guide.codeplex.com/license)
//===============================================================================


using System;
using Microsoft.Devices.Sensors;

namespace Microsoft.Practices.Phone.Adapters
{
    public interface IAccelerometer : IDisposable
    {
        void Start();
        void Stop();

        AccelerometerSensorReading CurrentValue { get; }
        bool IsDataValid { get; }
        bool IsSupported { get; }
        SensorState State { get; }
        TimeSpan TimeBetweenUpdates { get; set; }

        event EventHandler<SensorReadingEventArgs<AccelerometerSensorReading>> CurrentValueChanged;
    }
}
