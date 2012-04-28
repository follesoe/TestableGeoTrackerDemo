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
    public class CompassSensorReading : ISensorReading
    {
        public CompassSensorReading(CompassReading compassReading)
        {
            HeadingAccuracy = compassReading.HeadingAccuracy;
            MagneticHeading = compassReading.MagneticHeading;
            MagnetometerReading = compassReading.MagnetometerReading;
            Timestamp = compassReading.Timestamp;
            TrueHeading = compassReading.TrueHeading;
        }

        public CompassSensorReading()
        {
        }

        public double HeadingAccuracy { get; protected set; }
        public double MagneticHeading { get; protected set; }
        public Vector3 MagnetometerReading { get; protected set; }
        public DateTimeOffset Timestamp { get; protected set; }
        public double TrueHeading { get; protected set; }
    }
}
