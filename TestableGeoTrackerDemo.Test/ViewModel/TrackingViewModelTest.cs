using System;
using System.Device.Location;
using Microsoft.Practices.Phone.Testing;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using TestableGeoTrackerDemo.ViewModel;

namespace TestableGeoTrackerDemo.Test.ViewModel
{
    [TestClass]
    public class TrackingViewModelTest : SilverlightTest
    {
        private MockCompass _compass;
        private MockGeoCoordinateWatcher _geoWatcher;
        private TrackingViewModel _viewModel;            

        [TestInitialize]
        public void Setup()
        {
            _compass = new MockCompass();
            _geoWatcher = new MockGeoCoordinateWatcher();
            _viewModel = new TrackingViewModel(_compass, _geoWatcher);
        }

        [TestMethod]
        public void Should_start_compass_when_tracking_starts()
        {
            _compass.IsSupported = true;
            _viewModel.StartTrackingCommand.Execute(null);
            Assert.IsTrue(_compass.StartCalled);
        }

        [TestMethod]
        public void Should_not_start_compass_if_not_supported()
        {
            _compass.IsSupported = false;
            _viewModel.StartTrackingCommand.Execute(null);
            Assert.IsFalse(_compass.StartCalled);            
        }

        [TestMethod]
        public void Should_start_geo_watcher_when_tracking_starts()
        {
            _viewModel.StartTrackingCommand.Execute(null);
            Assert.IsTrue(_geoWatcher.StartCalled);
        }

        [TestMethod, Asynchronous, Timeout(5000)]
        public void Should_display_current_position()
        {
            bool latSet = false, lonSet = false;
            _viewModel.PropertyChanged += (o, e) => {                                                  
                if (e.PropertyName.Equals("Lat"))
                {
                    latSet = true;
                    Assert.AreEqual(15, _viewModel.Lat);
                }

                if (e.PropertyName.Equals("Lon"))
                {
                    lonSet = true;
                    Assert.AreEqual(30, _viewModel.Lon);
                }
                EnqueueConditional(() => latSet && lonSet);
                EnqueueTestComplete();
            };

            _geoWatcher.Status = GeoPositionStatus.Ready;
            _geoWatcher.ChangePosition(new GeoCoordinate(15, 30), DateTimeOffset.Now);
        }

        [TestMethod, Asynchronous, Timeout(5000)]
        public void Should_display_true_heading()
        {
            _viewModel.PropertyChanged += (o, e) => {
                if(e.PropertyName.Equals("Heading"))
                    Assert.AreEqual(45.5, _viewModel.Heading);
                EnqueueTestComplete();
            };

            const double trueHeading = 45.5;
            _compass.ChangeCurrentValue(-1, -1, Vector3.Zero, DateTimeOffset.Now, trueHeading);
        }
    }
}