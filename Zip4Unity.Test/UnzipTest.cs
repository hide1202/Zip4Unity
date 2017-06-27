using System;
using System.Diagnostics;
using System.IO;
using Ionic.Zip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zip4Unity.Test
{
    [TestClass]
    public class UnzipTest
    {
        private const string TestResourcesDirPath = @".\TestResources";
        private const string MoonZipFileName = @"moon.zip";
        private const string MoonJpgFileName = @"moon.jpg";
        private const string MoonOriginalJpgFileName = @"moon_original.jpg";

        [TestMethod]
        public void MoonUnzipTest()
        {
            var moonZipFilePath = Path.Combine(TestResourcesDirPath, MoonZipFileName);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            using (var zf = ZipFile.Read(moonZipFilePath))
                zf.ExtractAll(TestResourcesDirPath);
            stopWatch.Stop();

            Console.WriteLine("Elapsed time : {0} ms", stopWatch.ElapsedMilliseconds);

            var moonJpg = File.ReadAllBytes(Path.Combine(TestResourcesDirPath, MoonJpgFileName));
            var moonOriginalJpg = File.ReadAllBytes(Path.Combine(TestResourcesDirPath, MoonOriginalJpgFileName));

            CollectionAssert.AreEqual(moonOriginalJpg, moonJpg);

            File.Delete(Path.Combine(TestResourcesDirPath, MoonJpgFileName));
        }
    }
}
