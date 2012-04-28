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
    public class MotionAdapter : IMotion
    {
        public MotionAdapter()
        {
            WrappedSubject = new Motion();
            AttachToEvents();
        }

        private Motion WrappedSubject { get; set; }

        public MotionSensorReading CurrentValue
        {
            get { return new MotionSensorReading(WrappedSubject.CurrentValue); }
        }

        public bool IsDataValid
        {
            get { return WrappedSubject.IsDataValid; }
        }

        public bool IsSupported
        {
            get { return Motion.IsSupported; }
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

        public event EventHandler<CalibrationEventArgs> Calibrate;
        public event EventHandler<SensorReadingEventArgs<MotionSensorReading>> CurrentValueChanged;

        private void AttachToEvents()
        {
            WrappedSubject.Calibrate += WrappedSubjectCalibrate;
            WrappedSubject.CurrentValueChanged += WrappedSubjectCurrentValueChanged;
        }

        void WrappedSubjectCalibrate(object sender, CalibrationEventArgs e)
        {
            CalibrateRelay(sender, e);
        }

        private void CalibrateRelay(object sender, CalibrationEventArgs e)
        {
            var handler = Calibrate;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        void WrappedSubjectCurrentValueChanged(object sender, SensorReadingEventArgs<MotionReading> e)
        {
            CurrentValueChangedRelay(sender, new SensorReadingEventArgs<MotionSensorReading>() { SensorReading = new MotionSensorReading(e.SensorReading) });
        }

        private void CurrentValueChangedRelay(object sender, SensorReadingEventArgs<MotionSensorReading> e)
        {
            var handler = CurrentValueChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
