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
    public class MockCompass : ICompass
    {
        public bool StartCalled { get; set; }
        public Action StartTestCallback { get; set; }
        public bool StopCalled { get; set; }
        public Action StopTestCallback { get; set; }

        public void Start()
        {
            StartCalled = true;
            if (StartTestCallback != null)
            {
                StartTestCallback();
            }
        }

        public void Stop()
        {
            StopCalled = true;
            if (StopTestCallback != null)
            {
                StopTestCallback();
            }
        }

        public CompassSensorReading CurrentValue { get; set; }

        public bool IsDataValid { get; set; }

        public bool IsSupported { get; set; }

        public TimeSpan TimeBetweenUpdates { get; set; }

        public event EventHandler<CalibrationEventArgs> Calibrate;

        public void RaiseCalibrate()
        {
            var handler = Calibrate;
            if (handler != null)
                handler(null, new CalibrationEventArgs());
        }

        public event EventHandler<SensorReadingEventArgs<CompassSensorReading>> CurrentValueChanged;

        public void ChangeCurrentValue(double headingAccuracy, double magneticHeading, Vector3 magnetometerReading, DateTimeOffset timestamp, double trueHeading)
        {
            var compassSensorReading = new SettableCompassSensorReading();
            compassSensorReading.SetHeadingAccuracy(headingAccuracy);
            compassSensorReading.SetMagneticHeading(magneticHeading);
            compassSensorReading.SetMagnetometerReading(magnetometerReading);
            compassSensorReading.SetTimestamp(timestamp);
            compassSensorReading.SetTrueHeading(trueHeading);

            CurrentValue = compassSensorReading;

            var handler = CurrentValueChanged;
            if (handler != null)
                handler(null, new SensorReadingEventArgs<CompassSensorReading>() { SensorReading = CurrentValue });
        }

        public void Dispose()
        {
        }
    }
}
