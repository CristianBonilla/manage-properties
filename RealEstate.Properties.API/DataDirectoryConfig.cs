using System;
using System.IO;

namespace RealEstate.Properties.API
{
    /// <summary>
    /// Provides the configure operation of the main directory of the data store
    /// </summary>
    class DataDirectoryConfig
    {
        const string DataDirectory = "[DataDirectory]";
        private static readonly string directory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDirectoryConfig"/> class
        /// </summary>
        static DataDirectoryConfig()
        {
            string baseDirectory = Directory.GetCurrentDirectory();
            int lastIndex = baseDirectory.ToLower().LastIndexOf(@"bin\debug\");
            int length = lastIndex >= 0 ? lastIndex : baseDirectory.Length;
            directory = baseDirectory.Substring(0, length);
        }

        /// <summary>
        /// Sets the path of the database directory from the connection string
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public static void SetDataDirectoryPath(ref string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "The connection string should be defined");

            string appDataPath = Path.Combine(directory, "App_Data");
            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);
            connectionString = connectionString.Replace(
                DataDirectory,
                appDataPath,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
