using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwedaLib {
    public static class FileTools {
        // c:/xyz/filename.txt + prefix- ==> c:/xyz/prefix-filename.txt
        public static string AddPrefixToName(string fullFilePath, string prefix) {
            var result = Path.Combine(
                            Path.GetDirectoryName(fullFilePath), 
                            prefix + Path.GetFileName(fullFilePath)
                         );

            return result;
        }

        // c:/xyz/filename.txt + -suffix- ==> c:/xyz/filename-suffix.txt
        public static string AddSuffixToName(string fullFilePath, string suffix) {
            var result = Path.Combine(
                            Path.GetDirectoryName(fullFilePath), 
                            Path.GetFileNameWithoutExtension(fullFilePath) + suffix + Path.GetExtension(fullFilePath)
                         );

            return result;
        }
    }
}