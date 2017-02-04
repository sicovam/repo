using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GwedaLib {
    public static class DirTools {
        private static readonly string tempFolder = Path.GetTempPath().ToLower();

        public static string CreateTempFolder(bool createIt = true) {
            // ensure temp folder exists
            if (string.IsNullOrWhiteSpace(tempFolder) || !Directory.Exists(tempFolder)) {
                throw new FileNotFoundException("Cannot locate temp folder");
            }

            string path;
            do {
                var guid = Guid.NewGuid().ToString();
                path = Path.Combine(tempFolder, guid);
            } while (Directory.Exists(path));

            if (createIt) {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public static void DeleteTempFolder(string path) {
            if (string.IsNullOrWhiteSpace(path)) {
                throw new ArgumentException("path parameter is empty");
            }

            // ensure temp folder exists
            if (string.IsNullOrWhiteSpace(tempFolder) || !Directory.Exists(tempFolder)) {
                throw new FileNotFoundException("Cannot locate temp folder.");
            }

            // ensure path is something in the temp folder and isn't the temp folder
            if (!path.ToLower().StartsWith(tempFolder) || path.ToLower() == tempFolder) {
                throw new InvalidOperationException("Path must be in temp folder.");
            }

            var dirInfo = new DirectoryInfo(path);

            // ensure path is a folder
            if (dirInfo == null || !dirInfo.Attributes.HasFlag(FileAttributes.Directory)) {
                throw new InvalidOperationException("Path must be a folder.");
            }

            Directory.Delete(path, true);
        }
    }
}
