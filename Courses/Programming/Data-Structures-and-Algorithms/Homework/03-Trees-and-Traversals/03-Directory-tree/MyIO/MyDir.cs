namespace MyIO
{
    public class MyDir
    {
        public MyDir(string name)
        {
            this.Name = name;
        }

        public MyFile[] Files { get; set; }

        public MyDir[] Dirs { get; set; }

        public string Name { get; private set; }

        public long CalculateTotalSize()
        {
            long totalSize = 0;

            var dirsSize = this.CalculateSubDirsSize();
            totalSize += dirsSize;

            var filesSize = this.CalculateFilesSize();
            totalSize += filesSize;

            return totalSize;
        }

        private long CalculateFilesSize()
        {
            long totalSize = 0;

            if (this.Files == null)
            {
                return 0;
            }

            foreach (var file in this.Files)
            {
                var fileSize = file.Size;
                totalSize += fileSize;
            }

            return totalSize;
        }

        private long CalculateSubDirsSize()
        {
            long totalSize = 0;
            if (this.Dirs == null)
            {
                return 0;
            }

            foreach (var subDir in this.Dirs)
            {
                var subDirSize = subDir.CalculateTotalSize();
                totalSize += subDirSize;
            }

            return totalSize;
        }
    }
}