using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLettuceWrap
{
    public static class AsyncFileStream
    {
        public static async Task Write(string text, string filePath, FileMode fileMode=FileMode.Create, FileAccess fileAccess=FileAccess.Write, FileShare fileShare= FileShare.None, int bufferSizestring=4096)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (var sourceStream =
                new FileStream(
                    filePath,
                    mode: fileMode, access: fileAccess, share: fileShare,
                    bufferSize: bufferSizestring, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            }
        }

        public static async Task Write(string text, CancellationToken cancellationToken, string filePath, FileMode fileMode = FileMode.Create, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, int bufferSizestring = 4096)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (var sourceStream =
                new FileStream(
                    filePath,
                    mode: fileMode, access: fileAccess, share: fileShare,
                    bufferSize: bufferSizestring, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length, cancellationToken);
            }
        }

    }
}
