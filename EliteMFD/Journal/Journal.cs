using System;
using System.IO;
using System.Runtime.InteropServices;

namespace EliteMFD.Journal
{
    class Journal
    {
        JournalReader journalReader;
        FileSystemWatcher fswatcher;

        protected string journalPath;
        protected FileInfo journalFile;

        [DllImport("shell32.dll")]
        static extern int SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            uint dwFlags,
            IntPtr hToken,
            out IntPtr pszPath  // API uses CoTaskMemAlloc
        );

        private static Guid folderSavedGames = new Guid("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4"); //Guid of the SavedGames folder

        public Journal()
        {
            journalPath = GetJournalPath();

            SetupFsWatcher();
        }

        /// <summary>
        /// Finds the Elite Dangerous journal path
        /// </summary>
        /// <returns>Journal file location</returns>
        private static string GetJournalPath()
        {
            if (Environment.OSVersion.Version.Major < 6) throw new NotSupportedException();

            IntPtr pszPath = IntPtr.Zero;
            
            if (SHGetKnownFolderPath(folderSavedGames, 0, IntPtr.Zero, out pszPath) == 0)
            {
                string path = Marshal.PtrToStringUni(pszPath);
                Marshal.FreeCoTaskMem(pszPath);
                return Path.Combine(path, "Frontier Developments", "Elite Dangerous");
            }

            return null;
        }

        /// <summary>
        /// Sets up the fswatcher to monitor the journal files location and watch for new files and changes
        /// </summary>
        private void SetupFsWatcher()
        {
            fswatcher = new FileSystemWatcher();
            fswatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.Size;
            fswatcher.Path = journalPath;
            fswatcher.EnableRaisingEvents = true;
            fswatcher.Filter = "Journal.*.log";
            fswatcher.Created += JournalCreated;
            fswatcher.Changed += JournalChanged;
        }

        /// <summary>
        /// Removes existing journalreader and creates a new one on the new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JournalCreated(object sender, FileSystemEventArgs e)
        {
            if (journalReader != null)
            {
                journalReader.Dispose();
                journalReader = null;
            }

            journalFile = new FileInfo(e.FullPath);

            journalReader = new JournalReader(journalFile, LineRead);
        }

        /// <summary>
        /// Creates a journalreader on the changed file if no journalreader exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JournalChanged(object sender, FileSystemEventArgs e)
        {
            if (journalReader == null)
            {
                journalFile = new FileInfo(e.FullPath);

                journalReader = new JournalReader(journalFile, LineRead);
            }
        }

        /// <summary>
        /// Callback function called when a line is read to pass the line to the journalparser
        /// </summary>
        /// <param name="line">Line to be parsed</param>
        private void LineRead(string line)
        {
            //TO DO: parse the line
        }
    }
}
