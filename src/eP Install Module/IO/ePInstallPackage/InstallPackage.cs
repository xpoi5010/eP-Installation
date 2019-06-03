using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eP_Installer.IO.ePInstallPackage
{
    public class InstallPackage : ICollection<InstallFile>
    {
        public const uint Header = 0x74614465;

        public FileStream BaseFileStream;

        public InstallPackage()
        {

        }

        public static InstallPackage ReadFromFile(string Path)
        {
            if (!File.Exists(Path))
                throw new FileNotFoundException("FileNotFound", Path);
            InstallPackage output = new InstallPackage();
            FileStream fs = new FileStream(Path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            uint header = br.ReadUInt32();
            if (header != Header)
                throw new Exception("FormatWrong");
            byte[] hash = br.ReadBytes(64);
            uint FileCount = br.ReadUInt32();
            for(int i = 0; i < FileCount; i++)
            {
                ushort path_l = br.ReadUInt16();
                byte[] path_b = br.ReadBytes(path_l);
                string path = Encoding.UTF8.GetString(path_b);
                long size = br.ReadInt64();
                long offset = br.BaseStream.Position;
                string DataPath = $"this://offset:{offset}&size:{size}";
                br.BaseStream.Seek(size, SeekOrigin.Current);
                output.Add(DataPath, path);
            }
            fs.Seek(0, SeekOrigin.Begin);
            output.BaseFileStream = fs;
            return output;
        }

        //Collection
        public int Count => arr.Length;

        public bool IsReadOnly => false;

        private InstallFile[] arr = new InstallFile[0];

        public void Add(InstallFile item)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = item;
        }

        public void Add(string FilePath,string OutputFile)
        {
            Add(new InstallFile(FilePath, OutputFile));
        }

        public void Clear()
        {
            arr = new InstallFile[0];
        }

        public bool Contains(InstallFile item)
        {
            return Array.Exists(arr, x => x == item);
        }

        public void CopyTo(InstallFile[] array, int arrayIndex)
        {
            arr.CopyTo(array, arrayIndex);
        }

        public IEnumerator<InstallFile> GetEnumerator()
        {
            return new FileCollectionEnumerator(arr);
        }

        public bool Remove(InstallFile item)
        {
            int index = Array.FindIndex(arr, x => x == item);
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index >= arr.Length || index == -1)
                return false;
            if (index == arr.Length - 1)
                Array.Resize(ref arr, arr.Length - 1);
            Array.Copy(arr, index, arr, index - 1, arr.Length - index - 1);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FileCollectionEnumerator(arr);
        }

        public void CloseStream()
        {
            if (BaseFileStream != null)
                BaseFileStream.Close();
        }

        public void SaveFile(string Path)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(Header);
            bw.Write(new byte[64]);
            bw.Write(this.Count);
            foreach(InstallFile f in this)
            {
                string[] split = OriginalFilePath.Spliter(f.OriginalFileLocation);
                bw.Write(f.TargerLocation.Length);
                bw.Write(Encoding.UTF8.GetBytes(f.TargerLocation));
                if(split[0] == "this")
                {
                    long[] spli = OriginalFilePath.SplitThis(split[1]);
                    long offsett = spli[0];
                    long size = spli[1];
                    bw.Write(size);
                    BaseFileStream.Seek(offsett, SeekOrigin.Begin);
                    if (BaseFileStream == null)
                        throw new Exception("Unknown Path");
                    for (long i = size; i > 0; i -= 262144)
                    {
                        long rs = i >= 262144 ? 262144 : i;
                        byte[] readBytes = new byte[rs];
                        BaseFileStream.Read(readBytes, 0, readBytes.Length);
                        bw.Write(readBytes);
                    }
                }
                else if(split[0] == "file")
                {
                    using(FileStream ts = new FileStream(split[1], FileMode.Open))
                    {
                        bw.Write(ts.Length);
                        for (long i = ts.Length; i > 0; i -= 262144)
                        {
                            long rs = i >= 262144 ? 262144 : i;
                            byte[] readBytes = new byte[rs];
                            ts.Read(readBytes, 0, readBytes.Length);
                            bw.Write(readBytes);
                        }
                    }
                }
            }
            BaseFileStream = fs;
        }

    }

    public class FileCollectionEnumerator : IEnumerator<InstallFile>
    {
        private InstallFile[] files = new InstallFile[0];

        private int now = -1;

        public InstallFile Current => files[now];

        object IEnumerator.Current => files[now];

        public FileCollectionEnumerator(InstallFile[] files)
        {
            this.files = files;
        }
        public void Dispose()
        {
            files = null;
        }

        public bool MoveNext()
        {
            now++;
            if (now >= files.Length)
                return false;
            return true;
        }

        public void Reset()
        {
            now = -1;
        }
    }
}
