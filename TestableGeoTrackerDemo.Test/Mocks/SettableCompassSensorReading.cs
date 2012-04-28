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
using Microsoft.Practices.Phone.Adapters;
using Microsoft.Xna.Framework;

namespace Microsoft.Practices.Phone.Testing
{
    public class SettableCompassSensorReading : CompassSensorReading
    {
        public SettableCompassSensorReading(CompassReading compassReading)
        {
            HeadingAccuracy = compassReading.HeadingAccuracy;
            MagneticHeading = compassReading.MagneticHeading;
            MagnetometerReading = compassReading.MagnetometerReading;
            Timestamp = compassReading.Timestamp;
            TrueHeading = compassReading.TrueHeading;
        }

        public SettableCompassSensorReading()
        {
        }

        public void SetHeadingAccuracy(double headingAccuracy)
        {
            this.HeadingAccuracy = headingAccuracy;
        }

        public void SetMagneticHeading(double magneticHeading)
        {
            this.MagneticHeading = magneticHeading;
        }

        public void SetMagnetometerReading(Vector3 magnetometerReading)
        {
            this.MagnetometerReading = magnetometerReading;
        }

        public void SetTimestamp(DateTimeOffset timestamp)
        {
            this.Timestamp = timestamp;
        }

        public void SetTrueHeading(double trueHeading)
        {
            this.TrueHeading = trueHeading;
        }
    }
}
