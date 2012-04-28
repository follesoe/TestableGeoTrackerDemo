//===============================================================================
// Microsoft patterns & practices
// Building Testable Windows Phone Applications
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// This code released under the terms of the 
// Microsoft patterns & practices license (http://wp7guide.codeplex.com/license)
//===============================================================================


using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Microsoft.Practices.Phone.Adapters
{
    public class ApplicationFrameNavigationService : INavigationService
    {
        private readonly PhoneApplicationFrame frame;

        public ApplicationFrameNavigationService(PhoneApplicationFrame frame)
        {
            this.frame = frame;
            this.frame.Navigated += frame_Navigated;
            this.frame.Navigating += frame_Navigating;
            this.frame.NavigationFailed += frame_NavigationFailed;
            this.frame.NavigationStopped += frame_NavigationStopped;
            this.frame.FragmentNavigation += frame_FragmentNavigation;
            this.frame.JournalEntryRemoved += frame_JournalEntryRemoved;
        }

        public bool CanGoBack
        {
            get { return this.frame.CanGoBack; }
        }

        public bool CanGoForward
        {
            get { return this.frame.CanGoForward; }
        }

        public Uri CurrentSource
        {
            get { return this.frame.CurrentSource; }
        }

        public IEnumerable<JournalEntry> BackStack
        {
            get { return this.frame.BackStack; }
        }

        public Uri Source
        {
            get { return this.frame.Source; }
            set { this.frame.Source = value; }
        }

        public void GoBack()
        {
            this.frame.GoBack();
        }

        public void GoForward()
        {
            this.frame.GoForward();
        }

        public bool Navigate(Uri source)
        {
            return this.frame.Navigate(source);
        }

        public JournalEntry RemoveBackEntry()
        {
            return this.frame.RemoveBackEntry();
        }

        public void StopLoading()
        {
            this.frame.StopLoading();
        }
        
        public event NavigatedEventHandler Navigated;

        void frame_Navigated(object sender, NavigationEventArgs e)
        {
            var handler = this.Navigated;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public event NavigatingCancelEventHandler Navigating;

        void frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var handler = this.Navigating;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public event NavigationFailedEventHandler NavigationFailed;

        void frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            var handler = this.NavigationFailed;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public event NavigationStoppedEventHandler NavigationStopped;

        void frame_NavigationStopped(object sender, NavigationEventArgs e)
        {
            var handler = this.NavigationStopped;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public event FragmentNavigationEventHandler FragmentNavigation;

        void frame_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {
            var handler = this.FragmentNavigation;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public event EventHandler<JournalEntryRemovedEventArgs> JournalEntryRemoved;

        void frame_JournalEntryRemoved(object sender, JournalEntryRemovedEventArgs e)
        {
            var handler = this.JournalEntryRemoved;
            if (handler != null)
            {
                handler(sender, e);
            }
        }


    }
}
