﻿//===============================================================================
// Microsoft patterns & practices
// Building Testable Windows Phone Applications
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// This code released under the terms of the 
// Microsoft patterns & practices license (http://wp7guide.codeplex.com/license)
//===============================================================================


using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Practices.Phone.Adapters
{
    public class IsolatedStorageFileStreamAdapter : IsolatedStorageFileStream, IIsolatedStorageFileStream
    {
        public IsolatedStorageFileStreamAdapter(string path, FileMode mode, IsolatedStorageFile isf)
            : base(path, mode, isf)
        {
        }

        public IsolatedStorageFileStreamAdapter(string path, FileMode mode, FileAccess access, IsolatedStorageFile isf)
            : base(path, mode, access, isf)
        {
        }

        public IsolatedStorageFileStreamAdapter(string path, FileMode mode, FileAccess access, FileShare share, IsolatedStorageFile isf)
            : base(path, mode, access, share, isf)
        {
        }
    }
}

