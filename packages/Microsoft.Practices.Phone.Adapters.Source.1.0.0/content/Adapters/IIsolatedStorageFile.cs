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
    public interface IIsolatedStorageFile : IDisposable
    {
        long Quota { [SecuritySafeCritical] get; }

        long AvailableFreeSpace { [SecuritySafeCritical] get; }

        [SecuritySafeCritical]
        void Remove();

        [SecuritySafeCritical]
        bool IncreaseQuotaTo(long newQuotaSize);

        [SecuritySafeCritical]
        void DeleteFile(string file);

        [SecuritySafeCritical]
        bool FileExists(string path);

        [SecuritySafeCritical]
        bool DirectoryExists(string path);

        [SecuritySafeCritical]
        void CreateDirectory(string dir);

        [SecuritySafeCritical]
        void DeleteDirectory(string dir);

        string[] GetFileNames();

        [SecuritySafeCritical]
        string[] GetFileNames(string searchPattern);

        string[] GetDirectoryNames();

        [SecuritySafeCritical]
        string[] GetDirectoryNames(string searchPattern);

        IsolatedStorageFileStream OpenFile(string path, FileMode mode);

        IsolatedStorageFileStream OpenFile(string path, FileMode mode, FileAccess access);

        IsolatedStorageFileStream OpenFile(string path, FileMode mode, FileAccess access, FileShare share);

        IsolatedStorageFileStream CreateFile(string path);

        [SecuritySafeCritical]
        DateTimeOffset GetCreationTime(string path);

        [SecuritySafeCritical]
        DateTimeOffset GetLastAccessTime(string path);

        [SecuritySafeCritical]
        DateTimeOffset GetLastWriteTime(string path);

        [SecuritySafeCritical]
        void CopyFile(string sourceFileName, string destinationFileName);

        [SecuritySafeCritical]
        void CopyFile(string sourceFileName, string destinationFileName, bool overwrite);

        [SecuritySafeCritical]
        void MoveFile(string sourceFileName, string destinationFileName);

        [SecuritySafeCritical]
        void MoveDirectory(string sourceDirectoryName, string destinationDirectoryName);

        [SecuritySafeCritical]
        IIsolatedStorageFile GetUserStoreForApplication();

        IsolatedStorageFile IsolatedStorageFile { get;}
    }
}
