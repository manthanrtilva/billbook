using Microsoft.Win32;
using System;

namespace BillBook
{
    public enum BrowserEmulationVersion
    {
        Default = 0,
        Version7 = 7000,
        Version8 = 8000,
        Version8Standards = 8888,
        Version9 = 9000,
        Version9Standards = 9999,
        Version10 = 10000,
        Version10Standards = 10001,
        Version11 = 11000,
        Version11Edge = 11001
    };

    public class HelperRegistry
    {
        public static BrowserEmulationVersion GetBrowserEmulationVersion()
        {
            //get browser emmulation version for this program (if it exists)

            BrowserEmulationVersion result = BrowserEmulationVersion.Default;

            try
            {
                string programName = System.IO.Path.GetFileName(Environment.GetCommandLineArgs()[0]);

                object data = GetValueFromRegistry(RegistryHive.CurrentUser, @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", programName);

                if (data != null)
                {
                    result = (BrowserEmulationVersion)Convert.ToInt32(data);
                }
            }
            catch (System.Security.SecurityException ex)
            {
                // The user does not have the permissions required to read from the registry key.
                LogMsg("Error: (GetBrowserEmulationVersion - SecurityException) - " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                // The user does not have the necessary registry rights.
                LogMsg("Error: (GetBrowserEmulationVersion - UnauthorizedAccessException) - " + ex.Message);
            }
            catch (Exception ex)
            {
                LogMsg("Error: (GetBrowserEmulationVersion) - " + ex.Message);
            }

            return result;
        }

        public static int GetInternetExplorerMajorVersion()
        {
            //get IE version

            int result = 0;
            string version = string.Empty;

            try
            {
                string programName = System.IO.Path.GetFileName(Environment.GetCommandLineArgs()[0]);

                object data = GetValueFromRegistry(RegistryHive.LocalMachine, @"Software\Microsoft\Internet Explorer", "svcVersion");

                if (data == null)
                    data = GetValueFromRegistry(RegistryHive.CurrentUser, @"Software\Microsoft\Internet Explorer", "Version");

                if (data != null)
                {
                    version = data.ToString();
                    int separator = version.IndexOf('.');

                    if (separator != -1)
                    {
                        int.TryParse(version.Substring(0, separator), out result);
                    }
                }
            }
            catch (System.Security.SecurityException ex)
            {
                // The user does not have the permissions required to read from the registry key.
                LogMsg("Error: (GetInternetExplorerMajorVersion - SecurityException) - " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                // The user does not have the necessary registry rights.
                LogMsg("Error: (GetInternetExplorerMajorVersion - UnauthorizedAccessException) - " + ex.Message);
            }
            catch (Exception ex)
            {
                LogMsg("Error: (GetInternetExplorerMajorVersion) - " + ex.Message);
            }

            return result;
        }

        private static object GetValueFromRegistry(RegistryHive hive, string subkey, string regValue)
        {

            //if running as 64-bit, get value from 64-bit registry
            //if running as 32-bit, get value from 32-bit registry
            RegistryView rView = RegistryView.Registry64;
            object data = null;

            if (!Environment.Is64BitProcess)
            {
                //running as 32-bit
                rView = RegistryView.Registry32;
            }

            using (RegistryKey regBaseKey = RegistryKey.OpenBaseKey(hive, rView))
            {
                using (RegistryKey sKey = regBaseKey.OpenSubKey(subkey))
                {
                    if (sKey != null)
                    {
                        data = sKey.GetValue(regValue, null);

                        if (data != null)
                        {
                            LogMsg("data: " + data.ToString());
                        }
                        else
                        {
                            LogMsg("data is null (" + data + ")");
                        }
                    }
                }
            }

            return data;
        }

        public static bool IsBrowserEmulationSet()
        {
            return GetBrowserEmulationVersion() != BrowserEmulationVersion.Default;
        }

        private static void LogMsg(string msg)
        {
            string logMsg = String.Format("{0} {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"), msg);
            System.Diagnostics.Debug.WriteLine(logMsg);
        }

        public static bool SetBrowserEmulationVersion()
        {
            BrowserEmulationVersion emulationCode;

            int ieVersion = GetInternetExplorerMajorVersion();

            if (ieVersion >= 11)
            {
                emulationCode = BrowserEmulationVersion.Version11;
            }
            else
            {
                switch (ieVersion)
                {
                    case 10:
                        emulationCode = BrowserEmulationVersion.Version10;
                        break;
                    case 9:
                        emulationCode = BrowserEmulationVersion.Version9;
                        break;
                    case 8:
                        emulationCode = BrowserEmulationVersion.Version8;
                        break;
                    default:
                        emulationCode = BrowserEmulationVersion.Version7;
                        break;
                }
            }

            return SetBrowserEmulationVersion(emulationCode);
        }

        public static bool SetBrowserEmulationVersion(BrowserEmulationVersion browserEmulationVersion)
        {
            bool result = false;

            //if running as 64-bit, get value from 64-bit registry
            //if running as 32-bit, get value from 32-bit registry
            RegistryView rView = RegistryView.Registry64;

            if (!Environment.Is64BitProcess)
            {
                //running as 32-bit
                rView = RegistryView.Registry32;
            }

            try
            {
                string programName = System.IO.Path.GetFileName(Environment.GetCommandLineArgs()[0]);

                using (RegistryKey regBaseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, rView))
                {
                    using (RegistryKey sKey = regBaseKey.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
                    {
                        if (sKey != null)
                        {
                            if (browserEmulationVersion != BrowserEmulationVersion.Default)
                            {
                                // if it's a valid value, update or create the value
                                sKey.SetValue(programName, (int)browserEmulationVersion, Microsoft.Win32.RegistryValueKind.DWord);
                            }
                            else
                            {
                                // otherwise, remove the existing value
                                sKey.DeleteValue(programName, false);
                            }

                            result = true;
                        }
                    }
                }
            }
            catch (System.Security.SecurityException ex)
            {
                // The user does not have the permissions required to read from the registry key.
                LogMsg("Error: (SetBrowserEmulationVersion - SecurityException) - " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                // The user does not have the necessary registry rights.
                LogMsg("Error: (SetBrowserEmulationVersion - UnauthorizedAccessException) - " + ex.Message);
            }
            catch (Exception ex)
            {
                LogMsg("Error: (SetBrowserEmulationVersion) - " + ex.Message);
            }

            return result;
        }
    }
}
