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
using System.Security;

namespace Microsoft.Practices.Phone.Adapters
{
    public interface IIsolatedStorageFileStream : IDisposable
    {
        bool CanRead { get; }
        bool CanWrite { get; }
        bool CanSeek { get; }
        long Length { get; }
        long Position { get; set; }

        string Name { [SecurityCritical]
        get; }

        void Flush();
        void Flush(bool flushToDisk);

        [SecuritySafeCritical]
        void SetLength(long value);

        int Read(byte[] buffer, int offset, int count);
        int ReadByte();

        [SecuritySafeCritical]
        long Seek(long offset, SeekOrigin origin);

        [SecuritySafeCritical]
        void Write(byte[] buffer, int offset, int count);

        [SecuritySafeCritical]
        void WriteByte(byte value);

        IAsyncResult BeginRead(byte[] buffer, int offset, int numBytes, AsyncCallback userCallback, object stateObject);
        int EndRead(IAsyncResult asyncResult);

        [SecuritySafeCritical]
        IAsyncResult BeginWrite(byte[] buffer, int offset, int numBytes, AsyncCallback userCallback, object stateObject);

        void EndWrite(IAsyncResult asyncResult);

        int ReadTimeout { get; set; }
        int WriteTimeout { get; set; }
        void Close();
        void CopyTo(Stream destination);
        void CopyTo(Stream destination, int bufferSize);
        bool CanTimeout { get; }
    }
}