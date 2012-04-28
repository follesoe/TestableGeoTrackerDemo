//===============================================================================
// Microsoft patterns & practices
// Building Testable Windows Phone Applications
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// This code released under the terms of the 
// Microsoft patterns & practices license (http://wp7guide.codeplex.com/license)
//===============================================================================


using System.IO;
using System.IO.IsolatedStorage;

namespace Microsoft.Practices.Phone.Adapters
{
    public class IsolatedStorageFacade : IIsolatedStorageFacade
    {
        public IIsolatedStorageFileStream CreateStream(string path, FileMode mode)
        {
            var store = new IsolatedStorageFileAdapter();
            return new IsolatedStorageFileStreamAdapter(path, mode, store.IsolatedStorageFile);
        }
    }
}
