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
    public class MotionSensorReading : ISensorReading
    {
        public MotionSensorReading(MotionReading motionReading)
        {
            Attitude = motionReading.Attitude;
            DeviceAcceleration = motionReading.DeviceAcceleration;
            DeviceRotationRate = motionReading.DeviceRotationRate;
            Gravity = motionReading.Gravity;
            Timestamp = motionReading.Timestamp;
        }

        public MotionSensorReading()
        {
        }

        public AttitudeReading Attitude { get; protected set; }
        public Vector3 DeviceAcceleration { get; protected set; }
        public Vector3 DeviceRotationRate { get; protected set; }
        public Vector3 Gravity { get; protected set; }
        public DateTimeOffset Timestamp { get; protected set; }
    }
}
