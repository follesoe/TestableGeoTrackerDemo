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
    public class PhotoResultTaskEventArgs : TaskEventArgs
    {
        public PhotoResultTaskEventArgs(PhotoResult photoResult)
        {
            this.PhotoResult = photoResult;

            if (photoResult == null) return;

            this.ChosenPhoto = photoResult.ChosenPhoto;
            this.OriginalFileName = photoResult.OriginalFileName;
            this.Error = photoResult.Error;
        }

        public Stream ChosenPhoto { get; protected set; }
        public string OriginalFileName { get; protected set; }
        public new Exception Error { get; protected set; }

        public PhotoResult PhotoResult { get; private set; }
    }
}
