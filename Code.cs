// Deeply Sorry For The Nested Code! First Time Using C#


namespace V3
{
    class RSettings
    {
        static void Main(string[] args)
        {
            string mainPath = @"C:\Program Files (x86)\Roblox\Versions";
            string[] dirs = Directory.GetDirectories(mainPath);
            string settingsPath = @".\Assests\AppSettings.json";
            Console.WriteLine("Getting Assets...");

            foreach (string dir in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                FileInfo[] fi = di.GetFiles();
                Console.WriteLine("Finding Roblox Directory...");

                foreach (FileInfo fi2 in fi)
                {
                    if (fi2.Name == "RobloxPlayerBeta.exe")
                    {
                        string path = fi2.DirectoryName.ToString();
                        DirectoryInfo gotoDir = new DirectoryInfo(path);
                        Console.WriteLine("Finding Latest Version Of Roblox...");
                        if (gotoDir.Exists)
                        {
                            DirectoryInfo subDir = gotoDir.CreateSubdirectory("ClientSettings");
                            File.Create(subDir + "\\ClientAppSettings.json").Close();
                            FileInfo[] clientFiles = subDir.GetFiles();
                            Console.WriteLine("Copying Assets...");

                            foreach (FileInfo clientFile in clientFiles)
                            {
                                File.Copy(settingsPath, clientFile.FullName, true);
                                Console.WriteLine("Successfully Modified Roblox");
                            }
                        }
                    }
                }
            }
        }
    }
}
