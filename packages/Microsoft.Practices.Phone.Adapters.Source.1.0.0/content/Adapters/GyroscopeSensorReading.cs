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
    public class GyroscopeSensorReading : ISensorReading
    {
        public GyroscopeSensorReading(GyroscopeReading gyroscopeReading)
        {
            RotationRate = gyroscopeReading.RotationRate;
            Timestamp = gyroscopeReading.Timestamp;
        }

        public GyroscopeSensorReading()
        {
        }

        public Vector3 RotationRate { get; protected set; }
        public DateTimeOffset Timestamp { get; protected set; }
    }
}
