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
    public class AccelerometerAdapter : IAccelerometer
    {
        public AccelerometerAdapter()
        {
            WrappedSubject = new Accelerometer();
            AttachToEvents();
        }

        private Accelerometer WrappedSubject { get; set; }

        public AccelerometerSensorReading CurrentValue
        {
            get { return new AccelerometerSensorReading(WrappedSubject.CurrentValue); }
        }

        public bool IsDataValid
        {
            get { return WrappedSubject.IsDataValid; }
        }

        public bool IsSupported
        {
            get { return Accelerometer.IsSupported; }
        }

        public SensorState State
        {
            get { return WrappedSubject.State; }
        }

        public TimeSpan TimeBetweenUpdates
        {
            get
            {
                return WrappedSubject.TimeBetweenUpdates;
            }
            set
            {
                WrappedSubject.TimeBetweenUpdates = value;
            }
        }

        public void Start()
        {
            WrappedSubject.Start();
        }

        public void Stop()
        {
            WrappedSubject.Stop();
        }

        public void Dispose()
        {
            WrappedSubject.Dispose();
        }

        public event EventHandler<SensorReadingEventArgs<AccelerometerSensorReading>> CurrentValueChanged;

        private void AttachToEvents()
        {
            WrappedSubject.CurrentValueChanged += WrappedSubjectCurrentValueChanged;
        }

        void WrappedSubjectCurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            CurrentValueChangedRelay(sender, new SensorReadingEventArgs<AccelerometerSensorReading>() { SensorReading = new AccelerometerSensorReading(e.SensorReading) });
        }

        private void CurrentValueChangedRelay(object sender, SensorReadingEventArgs<AccelerometerSensorReading> e)
        {
            var handler = CurrentValueChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
