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
    public interface INavigationService
    {
        // Events
        event NavigatedEventHandler Navigated;
        event NavigatingCancelEventHandler Navigating;
        event FragmentNavigationEventHandler FragmentNavigation;
        event EventHandler<JournalEntryRemovedEventArgs> JournalEntryRemoved;
        event NavigationFailedEventHandler NavigationFailed;
        event NavigationStoppedEventHandler NavigationStopped;

        // Methods
        void GoBack();
        void GoForward();
        bool Navigate(Uri source);
        JournalEntry RemoveBackEntry();
        void StopLoading();

        // Properties
        bool CanGoBack { get; }
        bool CanGoForward { get; }
        Uri CurrentSource { get; }
        IEnumerable<JournalEntry> BackStack { get; }
        Uri Source { get; set; }

    }
}
