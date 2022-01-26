using System;
using System.IO;

namespace RealEstate.Properties.API
{
    /// <summary>
    /// Provides the configure operation of the main directory of the data store
    /// </summary>
    class DataDirectoryConfig
    {
        const string DATA_DIRECTORY = "[DataDirectory]";

        /// <summary>
        /// Gets the current directory inside the assembly
        /// </summary>
        public static string DirectoryPath
        {
            get
            {
                string baseDirectory = Directory.GetCurrentDirectory();
                int lastIndex = baseDirectory.ToLower().LastIndexOf(@"bin\debug\");
                int length = lastIndex >= 0 ? lastIndex : baseDirectory.Length;
                string directory = baseDirectory.Substring(0, length);

                return directory;
            }
        }

        /// <summary>
        /// Sets the path of the database directory from the connection string
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public static void SetDataDirectoryPath(ref string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "The connection string should be defined");

            string appDataPath = Path.Combine(DirectoryPath, "App_Data");
            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);
            connectionString = connectionString.Replace(
                DATA_DIRECTORY,
                appDataPath,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
