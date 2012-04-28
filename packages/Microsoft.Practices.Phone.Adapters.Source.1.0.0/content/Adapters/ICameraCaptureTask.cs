//===============================================================================
// Microsoft patterns & practices
// Building Testable Windows Phone Applications
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// This code released under the terms of the 
// Microsoft patterns & practices license (http://wp7guide.codeplex.com/license)
//===============================================================================


using System;
using Microsoft.Phone.Tasks;

namespace Microsoft.Practices.Phone.Adapters
{
    public interface ICameraCaptureTask
    {
        PhotoResultTaskEventArgs TaskEventArgs { get; set; }
        event EventHandler<PhotoResultTaskEventArgs> Completed;
        void Show();
    }
}
