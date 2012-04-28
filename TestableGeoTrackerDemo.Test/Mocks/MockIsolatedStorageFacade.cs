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
using Microsoft.Practices.Phone.Adapters;

namespace Microsoft.Practices.Phone.Testing
{
    public class MockIsolatedStorageFacade : IIsolatedStorageFacade
    {
        public IIsolatedStorageFileStream CreateStreamReturnValue { get; set; }

        public IIsolatedStorageFileStream CreateStream(string path, FileMode mode)
        {
            return CreateStreamReturnValue;
        }

    }
}
