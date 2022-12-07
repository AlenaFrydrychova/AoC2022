using System.Reflection;

namespace AdventOfCode2022
{
    public class Day07
    {
        private AocDirectory _currentDirectory;
        private AocDirectory _mainDirectory;
        private List<AocDirectory> _100kDirectories = new List<AocDirectory>();
        private List<AocDirectory> _directories = new List<AocDirectory>();

        public void SolvePuzzle()
        {
            var input = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day07.txt"));
            var allDirectories = input.Split("$ ").ToList();
            allDirectories.RemoveAt(0);
            foreach (var directory in allDirectories)
            {
                var directoryCommands = directory.Split(Environment.NewLine).ToList();
                foreach (var command in directoryCommands)
                {
                    CreateStructure(command);
                }
            }

            var totalSize = ReturnSum(_mainDirectory);
            var spaceNeeded = 30000000 - (70000000 - totalSize);
            var minimum = _directories.Where(d => d.Size >= spaceNeeded).Min(d => d.Size);

            Console.WriteLine(_100kDirectories.Sum(dir => dir.Size));
            Console.WriteLine(minimum);
        }

        private void CreateStructure(string line)
        {
            if (line.StartsWith("dir "))
            {
                var newDirectory = new AocDirectory();
                var splitLine = line.Split(" ");
                newDirectory.Name = splitLine[1];
                newDirectory.ParentDirectory = _currentDirectory;
                _currentDirectory.ChildDirectories.Add(newDirectory);
            }
            else if (line.StartsWith("ls"))
            {
            }
            else if (line.StartsWith("cd .."))
            {
                _currentDirectory = _currentDirectory.ParentDirectory;
            }
            else if (line.StartsWith("cd /"))
            {
                _mainDirectory = new AocDirectory();
                _mainDirectory.Name = "Main directory";
                _mainDirectory.Files = new List<AocFile>();
                _mainDirectory.ChildDirectories = new List<AocDirectory>();
                _currentDirectory = _mainDirectory;
            }
            else if (line.StartsWith("cd"))
            {
                var splitLine = line.Split(" ");
                _currentDirectory = _currentDirectory.ChildDirectories.Where(child => child.Name.Equals(splitLine[1])).Single();
            }
            else if (line.Equals(""))
            {
            }
            else
            {
                var file = new AocFile();
                var fileInfo = line.Split(" ");
                file.Size = Int32.Parse(fileInfo[0]);
                file.Name = fileInfo[1];
                _currentDirectory.Files.Add(file);
            }
        }

        private int ReturnSum(AocDirectory directory)
        {
            if (directory.ChildDirectories.Count() == 0)
            {
                return directory.Files.Sum(file => file.Size);
            }

            directory.Size = directory.ChildDirectories.Sum(child =>
            {
                var size = ReturnSum(child);
                _directories.Add(child);

                if (size <= 100000)
                {
                    _100kDirectories.Add(child);
                }

                child.Size = size;

                return size;
            }) + directory.Files.Sum(file => file.Size);

            return directory.Size;
        }
    }

    internal class AocDirectory
    {
        public string Name;
        public List<AocFile> Files = new List<AocFile>();
        public List<AocDirectory> ChildDirectories = new List<AocDirectory>();
        public AocDirectory ParentDirectory;
        public int Size;
    };

    internal class AocFile
    {
        public string Name;
        public int Size;
    };
}
