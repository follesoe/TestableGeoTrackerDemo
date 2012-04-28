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
    public class IsolatedStorageFileAdapter : IIsolatedStorageFile
    {
        private IsolatedStorageFile WrappedSubject;

        public IsolatedStorageFileAdapter()
        {
            WrappedSubject = IsolatedStorageFile.GetUserStoreForApplication();
        }

        public void Dispose()
        {
            WrappedSubject.Dispose();
        }

        public long Quota
        {
            get { return WrappedSubject.Quota; }
        }

        public long AvailableFreeSpace
        {
            get { return WrappedSubject.AvailableFreeSpace; }
        }

        public void Remove()
        {
            WrappedSubject.Remove();
        }

        public bool IncreaseQuotaTo(long newQuotaSize)
        {
            return WrappedSubject.IncreaseQuotaTo(newQuotaSize);
        }

        public void DeleteFile(string file)
        {
            WrappedSubject.DeleteFile(file);
        }

        public bool FileExists(string path)
        {
            return WrappedSubject.FileExists(path);
        }

        public bool DirectoryExists(string path)
        {
            return WrappedSubject.DirectoryExists(path);
        }

        public void CreateDirectory(string dir)
        {
            WrappedSubject.CreateDirectory(dir);
        }

        public void DeleteDirectory(string dir)
        {
            WrappedSubject.DeleteDirectory(dir);
        }

        public string[] GetFileNames()
        {
            return WrappedSubject.GetFileNames();
        }

        public string[] GetFileNames(string searchPattern)
        {
            return WrappedSubject.GetFileNames(searchPattern);
        }

        public string[] GetDirectoryNames()
        {
            return WrappedSubject.GetDirectoryNames();
        }

        public string[] GetDirectoryNames(string searchPattern)
        {
            return WrappedSubject.GetDirectoryNames(searchPattern);
        }

        public IsolatedStorageFileStream OpenFile(string path, FileMode mode)
        {
            return WrappedSubject.OpenFile(path, mode);
        }

        public IsolatedStorageFileStream OpenFile(string path, FileMode mode, FileAccess access)
        {
            return WrappedSubject.OpenFile(path, mode, access);
        }

        public IsolatedStorageFileStream OpenFile(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return WrappedSubject.OpenFile(path, mode, access, share);
        }

        public IsolatedStorageFileStream CreateFile(string path)
        {
            return WrappedSubject.CreateFile(path);
        }

        public DateTimeOffset GetCreationTime(string path)
        {
            return WrappedSubject.GetCreationTime(path);
        }

        public DateTimeOffset GetLastAccessTime(string path)
        {
            return WrappedSubject.GetLastAccessTime(path);
        }

        public DateTimeOffset GetLastWriteTime(string path)
        {
            return WrappedSubject.GetLastWriteTime(path);
        }

        public void CopyFile(string sourceFileName, string destinationFileName)
        {
            WrappedSubject.CopyFile(sourceFileName, destinationFileName);
        }

        public void CopyFile(string sourceFileName, string destinationFileName, bool overwrite)
        {
            WrappedSubject.CopyFile(sourceFileName, destinationFileName, overwrite);

        }

        public void MoveFile(string sourceFileName, string destinationFileName)
        {
            WrappedSubject.MoveFile(sourceFileName, destinationFileName);
        }

        public void MoveDirectory(string sourceDirectoryName, string destinationDirectoryName)
        {
            WrappedSubject.MoveDirectory(sourceDirectoryName, destinationDirectoryName);
        }

        public IIsolatedStorageFile GetUserStoreForApplication()
        {
            return this;
        }

        public IsolatedStorageFile IsolatedStorageFile
        {
            get { return WrappedSubject; }
        }
    }
}
