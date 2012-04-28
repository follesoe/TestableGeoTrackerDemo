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
    public class MockIsolatedStorageFileStream : Stream, IIsolatedStorageFileStream
    {
        public BufferOffsetCountParameters WriteCalledWithParameters { get; set; }
        public Action<byte[], int, int> WriteTestCallback { get; set; }

        public BufferOffsetCountParameters ReadCalledWithParameters { get; set; }
        public Func<byte[], int, int, byte[]> ReadTestCallback { get; set; }

        public MockIsolatedStorageFileStream(bool canRead, bool canWrite, bool canSeek, long length)
        {
            this.canRead = canRead;
            this.canWrite = canWrite;
            this.canSeek = canSeek;
            this.length = length;
            WriteTestCallback = (b, o, c) => { };
            ReadTestCallback = (b, o, c) => null;
        }

        public new void Dispose() {}

        private bool canRead;
        public override bool CanRead
        {
            get { return canRead; }
        }

        private bool canWrite;
        public override bool CanWrite
        {
            get { return canWrite; }
        }

        private bool canSeek;
        public override bool CanSeek
        {
            get { return canSeek; }
        }

        private long length;
        public override long Length
        {
            get { return length; }
        }

        private long position;

        public override long Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Name { get; set; }

        public override void Flush()
        {
        }

        public void Flush(bool flushToDisk)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            ReadCalledWithParameters = new BufferOffsetCountParameters
            {
                buffer = buffer,
                offset = offset,
                count = count
            };
            var contentBytes = ReadTestCallback(buffer, offset, count);
            for (int index = 0; index < contentBytes.Length; index++)
            {
                buffer[index] = contentBytes[index];
            }
            return contentBytes.Length;
        }

        public new int ReadByte()
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            WriteCalledWithParameters = new BufferOffsetCountParameters
                                            {
                                                buffer = buffer,
                                                offset = offset,
                                                count = count
                                            };
            WriteTestCallback(buffer, offset, count);
        }

        public new void WriteByte(byte value)
        {
            throw new NotImplementedException();
        }

        public new IAsyncResult BeginRead(byte[] buffer, int offset, int numBytes, AsyncCallback userCallback, object stateObject)
        {
            throw new NotImplementedException();
        }

        public new int EndRead(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public new IAsyncResult BeginWrite(byte[] buffer, int offset, int numBytes, AsyncCallback userCallback, object stateObject)
        {
            throw new NotImplementedException();
        }

        public new void EndWrite(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }
    }

    public struct BufferOffsetCountParameters
    {
        public byte[] buffer;
        public int offset;
        public int count;
    }
}
