//===============================================================================
// Microsoft patterns & practices
// Building Testable Windows Phone Applications
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// This code released under the terms of the 
// Microsoft patterns & practices license (http://wp7guide.codeplex.com/license)
//===============================================================================


using System;
using System.IO;
using Microsoft.Phone.Tasks;

namespace Microsoft.Practices.Phone.Adapters
{
    public class CameraCaptureTaskAdapter : ICameraCaptureTask
    {
        public CameraCaptureTaskAdapter()
        {
            WrappedSubject = new CameraCaptureTask();
            AttachToEvents();
        }

        private CameraCaptureTask WrappedSubject { get; set; }

        public PhotoResultTaskEventArgs TaskEventArgs
        {
            get
            {
                return new PhotoResultTaskEventArgs(WrappedSubject.TaskEventArgs);
            }

            set { WrappedSubject.TaskEventArgs = value.PhotoResult; }
        }

        public event EventHandler<PhotoResultTaskEventArgs> Completed;

        private void AttachToEvents()
        {
            WrappedSubject.Completed += WrappedSubjectCompleted;
        }

        void WrappedSubjectCompleted(object sender, PhotoResult e)
        {
            CompletedRelay(sender, new PhotoResultTaskEventArgs(e));
        }

        public void Show()
        {
            WrappedSubject.Show();
        }

        private void CompletedRelay(object sender, PhotoResultTaskEventArgs e)
        {
            var handler = Completed;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
