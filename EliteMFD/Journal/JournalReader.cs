using System;
using System.IO;
using System.Timers;

namespace EliteMFD.Journal
{
    class JournalReader : IDisposable
    {
        protected FileInfo journal;

        protected FileSystemWatcher fswatcher;
        protected FileStream filestream;
        protected StreamReader streamreader;

        protected Action<string> linereadCallback;

        Timer timer;
        
        /// <summary>
        /// Creates a new JournalReader
        /// </summary>
        /// <param name="file">Journal file to read</param>
        /// <param name="callbackMethod">Callback method that gets called once a line is read</param>
        public JournalReader(FileInfo file, Action<string> callbackMethod)
        {
            journal = file;

            linereadCallback = callbackMethod;

            SetupFsWatcher();

            filestream = new FileStream(journal.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            streamreader = new StreamReader(filestream);

            //read file size every second to make the filesystemwatcher work
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(CheckUpdate);
            timer.Interval = 1000;
            timer.Start();
        }

        /// <summary>
        /// Closes the file 
        /// </summary>
        private void Cleanup()
        {
            streamreader.Close();
            filestream.Close();
            timer.Stop();
        }

        /// <summary>
        /// Clean up and dispose of 
        /// </summary>
        public void Dispose()
        {
            Cleanup();
            streamreader.Dispose();
            filestream.Dispose();
            timer.Dispose();
        }
        
        /// <summary>
        /// Sets up the filesystemwatcher
        /// </summary>
        private void SetupFsWatcher()
        {
            fswatcher = new FileSystemWatcher();
            fswatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
            fswatcher.Path = journal.DirectoryName;
            fswatcher.EnableRaisingEvents = true;
            fswatcher.Filter = journal.Name;
            fswatcher.Changed += FileChanged;
        }  

        /// <summary>
        /// Called whenever a the journal file is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            ReadLine();
        }

        /// <summary>
        /// Gets the last line from the journal and passes it to the callback function
        /// </summary>
        private void ReadLine()
        {
            string lastLine, currentLine;

            //continue reading lines until EOF
            do
            {
                currentLine = streamreader.ReadLine();
                lastLine = currentLine;
            } while (currentLine != null);

            //pass the last line before EOF to the callback function
            linereadCallback(lastLine);
        }

        /// <summary>
        /// Workaround to make the filesystemwatcher work, otherwise it doesn't realize the file changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckUpdate(object sender, ElapsedEventArgs e)
        {
            long filesize = new FileInfo(journal.FullName).Length;
            journal.Refresh();
        }
    }
}
