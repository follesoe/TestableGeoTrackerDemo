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
    public class GyroscopeAdapter : IGyroscope
    {
        public GyroscopeAdapter()
        {
            WrappedSubject = new Gyroscope();
            AttachToEvents();
        }

        private Gyroscope WrappedSubject { get; set; }

        public GyroscopeSensorReading CurrentValue
        {
            get { return new GyroscopeSensorReading(WrappedSubject.CurrentValue); }
        }

        public bool IsDataValid
        {
            get { return WrappedSubject.IsDataValid; }
        }

        public bool IsSupported
        {
            get { return Gyroscope.IsSupported; }
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

        public event EventHandler<SensorReadingEventArgs<GyroscopeSensorReading>> CurrentValueChanged;

        private void AttachToEvents()
        {
            WrappedSubject.CurrentValueChanged += WrappedSubjectCurrentValueChanged;
        }

        void WrappedSubjectCurrentValueChanged(object sender, SensorReadingEventArgs<GyroscopeReading> e)
        {
            CurrentValueChangedRelay(sender, new SensorReadingEventArgs<GyroscopeSensorReading>() { SensorReading = new GyroscopeSensorReading(e.SensorReading) });
        }

        private void CurrentValueChangedRelay(object sender, SensorReadingEventArgs<GyroscopeSensorReading> e)
        {
            var handler = CurrentValueChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
