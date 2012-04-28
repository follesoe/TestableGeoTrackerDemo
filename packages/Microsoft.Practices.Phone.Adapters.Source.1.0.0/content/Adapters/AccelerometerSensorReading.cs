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
using Microsoft.Xna.Framework;

namespace Microsoft.Practices.Phone.Adapters
{
    public class AccelerometerSensorReading : ISensorReading
    {
        public AccelerometerSensorReading(AccelerometerReading accelerometerReading)
        {
            Acceleration = accelerometerReading.Acceleration;
            Timestamp = accelerometerReading.Timestamp;
        }

        public AccelerometerSensorReading()
        {
        }

        public Vector3 Acceleration { get; protected set; }
        public DateTimeOffset Timestamp { get; protected set; }
    }
}
