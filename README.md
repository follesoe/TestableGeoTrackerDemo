 # Building testable WP7 apps using Microsoft.Practices.Phone.Adapters #

<p>I’m a big believer in Test Driven Development as an effective practice that helps me write high quality, maintainable code. TDD is a practice I not only apply on larger enterprise applications, but something I try to do even on smaller mobile apps. In the day of the Apple App Store or Microsoft Marketplace you are relying on Apple or Microsoft to approve your application before it’s made available to your users. The process typically takes around a week – meaning it can potentially take a week before you fix a bug and the update is made available to the users. Introducing a bug in your mobile app can greatly hurt your rating in the Marketplace/App Store. Given the fact that you cannot simply upload a quick fix to the app stores, like you can on a web application, having solid testing for mobile applications is even more important than for other types of applications.</p>

<p>With this in mind I was thrilled to see that Microsoft Pattern &amp; Practices had taken this to hearth in their latest guidance for building Windows Phone 7 applications. The latest guide includes three major topics:</p>

<ul> 
	<li><a href="http://msdn.microsoft.com/en-us/library/hh848247.aspx">Developing a Windows Phone Application using the MVVM Pattern</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/gg490765.aspx">Developing an Advanced Windows Phone 7.5 App that Connects to the Cloud</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/hh830877.aspx">Building Testable Windows Phone Applications</a></li>
</ul>

<p>I have previously written <a href="http://jonas.follesoe.no/2008/07/19/youcard-re-visited-implementing-the-viewmodel-pattern/">several blog posts</a> and given presentations on how the MVVM Pattern can help you separate the state and behavior of a piece of UI from the actual View-code. By moving state and behavior into a View Model-class with no UI dependencies, you can easily unit test the View Model in separation. If you would like to learn more about the MVVM-pattern I would strongly recommend my <a href="http://jonas.follesoe.no/2010/03/07/mvvm-presentation-from-ndc2009-on-vimeo/">presentation from NDC 2009</a>, or the <a href="http://msdn.microsoft.com/en-us/library/hh848247.aspx">MVVM-chapter from the P&amp;P WP7 Guidelines</a>.
To ensure that the View Model classes can be tested independently it is important that they do not have any external dependencies that are hard to test. Whenever a View Model depends on some external resource, such as a web service, we introduce an interface for that dependency, and enable some form of Dependency Injection on the View Model so that we can replace the dependency with a stub or a mock during test.</p>

<p>When working against the Windows Phone 7 APIs you will quickly realize that they are not very test-friendly. The API consists of several static or sealed classes that provide access to core phone-functionality such as Location Services, Compass, Camera, Gyroscope or other sensors. Since the classes are sealed, and do not implement an interface, there is no simple way to test code accessing these classes directly. The solution in such cases is typically to define your own interface mimicking the underlying API, and then implement an Adapter class delegating through to the underlying API.</p>

<p>To demonstrate this principle I have created a simple application that displays your current location and compass heading. Such an application would need to use two classes that are hard to test; the <a href="http://msdn.microsoft.com/en-us/library/system.device.location.geocoordinatewatcher.aspx">GeoCoordinateWatcher-class</a> and the <a href="http://msdn.microsoft.com/en-us/library/microsoft.devices.sensors.compass(v=vs.92).aspx">Compass-class</a>. A simple design, using the View Model pattern, would look something like this:</p>

<img src="http://static.follesoe.no/testablewp7diagram1.jpg" alt="Class Diagram illustrating the MVVM pattern" />

<p>The problem with this design is how the TrackingViewModel-class is using the Compass-class and GeoCoordinateWatcher-class directly. It would be impossible to unit test the View Model, both because the Compass-sensor is not available in the simulator, but also just because of the fact that getting a location/compass reading takes time, and would make the tests slow and unreliable. Instead we are going to modify the design, and use the abstractions introduced by the Patterns &amp; Practices team. We change our TrackingViewModel-class to depend on ICompass and IGeoCoordinateWatcher. At test-time we pass in mock-implementations of these two classes to enable testability, while at run-time we use the adapter classes GeoCordinateWatcherAdapter and CompassAdapter.</p>

<img src="http://static.follesoe.no/testablewp7diagram2.jpg" alt="Class Diagram illustrating the MVVM pattern with testable Compass and GeoLocationWatcher classes" />

<p>With this small change we can now write unit tests for the TrackingViewModel-class. Here is an example of some of the tests I have written for the View Model.</p>

<script src="https://gist.github.com/2520932.js?file=TrackingViewModelTest.cs"></script>

<p>Many people assume that you have to use an IoC-container to use Dependency Injection. That is not the case. My personal preference is to not introduce an IoC-container until it is necessary, and instead use overloaded constructors. The TrackingViewModel-class has two constructors, one that accepts the ICompass and IGeoCoordinateWatcher interfaces as parameters, and one default constructor that calls the parameterized constructor passing in the adapter classes as default. This enables testability, yet at the same time keeps the architecture of the application simple.</p>

<script src="https://gist.github.com/2520938.js?file=TrackingViewModelCtr.cs"></script>

<p>In this example I only use two of the wrapped classes provided by the Microsoft.Practices.Phone.Adapters project. In addition the project contains adapters for the following classes in the Windows Phone 7.1 SDK:</p>

<table>
	<thead>
		<tr>
			<th>Wrapper</th>
			<th>Implements</th>
			<th>Abstracted Class</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td>AccelerometerAdapter</td>
			<td>IAccelerometer</td>
			<td>Accelerometer</td>
		</tr>
		<tr>
			<td>ApplicationFrameNavigationService</td>
			<td>INavigationService</td>
			<td>PhoneApplicationFrame</td>
		</tr>
		<tr>
			<td>CameraCaptureTaskAdapter</td>
			<td>ICameraCaptureTask</td>
			<td>CameraCaptureTask</td>
		</tr>
		<tr>
			<td>CompassAdapter</td>
			<td>ICompass</td>
			<td>Compass</td>
		</tr>
		<tr>			
			<td>GeoCordinateWatcherAdapter</td>
			<td>GeoCoordinateWatcher, IGeoCoordinateWatcher</td>
			<td>GeoCoordinateWatcher</td>
		</tr>
		<tr>
			<td>GyroscopeAdapter</td>
			<td>IGyroscope</td>
			<td>Gyroscope</td>
		</tr>
		<tr>
			<td>IsolatedStorageFacade</td>
			<td>IIsolatedStorageFacade</td>
			<td>IsolatedStorageFileAdapter, IsolatedStorageFileStreamAdapter</td>
		</tr>
		<tr>
			<td>IsolatedStorageFileAdapter</td>
			<td>IIsolatedStorageFile</td>
			<td>IsolatedStorageFile</td>
		</tr>
		<tr>
			<td>IsolatedStorageFileStreamAdapter</td>
			<td>IsolatedStorageFileStream, IIsolatedStorageFileStream</td>
			<td>IsolatedStorageFileStream</td>
		</tr>
		<tr>			
			<td>MessageBoxAdapter</td>
			<td>IMessageBox</td>
			<td>MessageBox</td>
		</tr>
		<tr>
			<td>MotionAdapter</td>
			<td>IMotion</td>		
			<td>Motion</td>
		</tr>
		<tr>
			<td>AccelerometerSensorReading</td>
			<td>ISensorReading</td>
			<td>AccelerometerReading</td>
		</tr>
		<tr>
			<td>CompassSensorReading</td>
			<td>ISensorReading</td>
			<td>CompassReading</td>
		</tr>
		<tr>
			<td>GyroscopeSensorReading</td>
			<td>ISensorReading</td>
			<td>GyroscopeReading</td>
		</tr>
		<tr>			
			<td>MotionSensorReading</td>
			<td>ISensorReading</td>
			<td>MotionReading</td>
		</tr>
		<tr>
			<td>PhotoResultTaskEventArgs</td>
			<td>TaskEventArgs</td>
			<td>PhotoResult</td>
		</tr>
	</tbody>
</table>


<p>The Microsoft.Practices.Phone.Adapters project can be added as a <a href="https://nuget.org/packages/Microsoft.Practices.Phone.Adapters.Source">NuGet-package</a>. The package adds the interfaces/adapter files to your project, and you can choose to delete the once you don’t need (it is not a pre-compiled package). If you <a href="http://www.microsoft.com/download/en/details.aspx?id=28804">download the example project from the MSDN site</a> you also get a set of pre-written mock-classes you can use in your Unit Test project to mock the different interfaces.</p>

<p>If you want to learn more about making your WP7 applications testable I would strongly encourage you to <a href="http://msdn.microsoft.com/en-us/library/gg477144.aspx">read the full guide on this on MSDN</a>. As I mentioned in the introduction, testability is just one aspect of the Patterns &amp; Practices Guide for WP7, and I will be covering other areas in a later blog post.</p>

<p>The example application for this blog post is available at <a href="https://github.com/follesoe/TestableGeoTrackerDemo">https://github.com/follesoe/TestableGeoTrackerDemo</a>.</p>
