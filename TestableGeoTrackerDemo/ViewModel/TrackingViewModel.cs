using System.ComponentModel;
using System.Device.Location;
using System.Windows;
using System.Windows.Input;
using Microsoft.Devices.Sensors;
using Microsoft.Practices.Phone.Adapters;

namespace TestableGeoTrackerDemo.ViewModel
{
    public class TrackingViewModel : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand StartTrackingCommand { get; private set; }

        private readonly ICompass _compass;
        private readonly IGeoCoordinateWatcher _geoWatcher;

        private double _lat;
        public double Lat
        {
            get { return _lat; }
            set
            {
                _lat = value;
                RaisePropertyChanged("Lat");
            }
        }

        private double _lon;
        public double Lon
        {
            get { return _lon; }
            set
            {
                _lon = value;
                RaisePropertyChanged("Lon");
            }
        }

        private double _heading;
        public double Heading
        {
            get { return _heading; }
            set
            {
                _heading = value;
                RaisePropertyChanged("Heading");
            }
        }

        public TrackingViewModel() : 
            this(new CompassAdapter(), new GeoCoordinateWatcherAdapter())
        {
            
        }

        public TrackingViewModel(ICompass compass, IGeoCoordinateWatcher geoWatcher)
        {
            _compass = compass;
            _compass.CurrentValueChanged += OnCompassValueChanged;

            _geoWatcher = geoWatcher;
            _geoWatcher.PositionChanged += OnPositionChanged;

            StartTrackingCommand = new RelayCommand(StartTracking);
            Reset();
        }

        private void Reset()
        {
            Heading = 0;
            Lat = 0;
            Lon = 0;
        }

        private void StartTracking(object param)
        {
            if(_compass.IsSupported) _compass.Start();
            _geoWatcher.Start();
        }

        private void OnCompassValueChanged(object sender, SensorReadingEventArgs<CompassSensorReading> e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                Heading = e.SensorReading.TrueHeading;
            });
        }

        private void OnPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                Lat = e.Position.Location.Latitude;
                Lon = e.Position.Location.Longitude;
            });            
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}