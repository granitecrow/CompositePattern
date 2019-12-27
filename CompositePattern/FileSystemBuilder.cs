using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public class FileSystemBuilder
    {
        public DirectoryItem Root { get; }

        public FileSystemBuilder(string rootDirectory)
        {
            this.Root = new DirectoryItem(rootDirectory);
            this.currentDirectory = this.Root;
        }

        private DirectoryItem currentDirectory;

        public DirectoryItem AddDirectory(string name)
        {
            var dir = new DirectoryItem(name);
            this.currentDirectory.Add(dir);
            this.currentDirectory = dir;
            return dir;
        }

        public FileItem AddFile(string name, long size)
        {
            var file = new FileItem(name, size);
            this.currentDirectory.Add(file);
            return file;
        }

        public DirectoryItem SetCurrentDirectory(string directoryName)
        {
            var dirstack = new Stack<DirectoryItem>();
            dirstack.Push(this.Root);

            while (dirstack.Any())
            {
                var currentItem = dirstack.Pop();
                if (currentItem.Name == directoryName)
                {
                    this.currentDirectory = currentItem;
                    return currentItem;
                }
                foreach (var item in currentItem.Items.OfType<DirectoryItem>())
                {
                    dirstack.Push(item);
                }
            }
            throw new InvalidOperationException($"Directory '{directoryName}' not found!");
        }
    }
}
