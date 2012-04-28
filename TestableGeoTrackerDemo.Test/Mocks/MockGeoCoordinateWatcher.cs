//===============================================================================
// Microsoft patterns & practices
// Building Testable Windows Phone Applications
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// This code released under the terms of the 
// Microsoft patterns & practices license (http://wp7guide.codeplex.com/license)
//===============================================================================


using System;
using System.Device.Location;
using Microsoft.Practices.Phone.Adapters;

namespace Microsoft.Practices.Phone.Testing
{
    public class MockGeoCoordinateWatcher : IGeoCoordinateWatcher
    {
        public MockGeoCoordinateWatcher()
        {
            TryStartTestCallback = (b1, t) => true;
            StopTestCallback = () => { };

            this.DesiredAccuracy = GeoPositionAccuracy.Default;
            this.MovementThreshold = 0.0;
            this.Permission = GeoPositionPermission.Granted;
            this.Status = GeoPositionStatus.NoData;
        }

        public Action<bool> StartTestCallback { get; set; }
        public Action StopTestCallback { get; set; }
        public Func<bool, TimeSpan, bool> TryStartTestCallback { get; set; }
        public bool StartCalled { get; set; }

        public void Start()
        {
            Start(false);
        }

        public void Start(bool suppressPermissionPrompt)
        {
            StartCalled = true;
            if (StartTestCallback != null)
            {
                StartTestCallback(suppressPermissionPrompt);                
            }
            else
            {
                //Default behavior
                ChangeStatus(GeoPositionStatus.Ready);
            }
        }

        public bool TryStart(bool suppressPermissionPrompt, TimeSpan timeout)
        {
            return TryStartTestCallback(suppressPermissionPrompt, timeout);
        }

        public void Stop()
        {
            StopTestCallback();
        }

        public void Dispose()
        {
        }

        public GeoPositionAccuracy DesiredAccuracy { get; set; }

        public double MovementThreshold { get; set; }

        public GeoPosition<GeoCoordinate> Position { get; set; }

        public GeoPositionStatus Status { get; set; }

        public GeoPositionPermission Permission { get; set; }

        public event EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>> PositionChanged;
        public event EventHandler<GeoPositionStatusChangedEventArgs> StatusChanged;

        public void ChangePosition(GeoCoordinate geoCoordinate, DateTimeOffset dateTimeOffset)
        {
            Position = new GeoPosition<GeoCoordinate>(dateTimeOffset, geoCoordinate);

            var handler = PositionChanged;
            if (handler != null)
                handler(null, new GeoPositionChangedEventArgs<GeoCoordinate>(Position));
        }

        public void ChangeStatus(GeoPositionStatus geoPositionStatus)
        {
            Status = geoPositionStatus;

            var handler = StatusChanged;
            if (handler != null)
                handler(null, new GeoPositionStatusChangedEventArgs(geoPositionStatus));
        }
    }
}
