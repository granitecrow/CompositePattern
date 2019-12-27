using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public class DirectoryItem : FileSystemItem
    {
        public List<FileSystemItem> Items { get; } = new List<FileSystemItem>();

        public DirectoryItem(string name) : base(name)
        {
        }

        public long FileBytes { get; }

        public override decimal GetSizeInKB()
        {
            return this.Items.Sum(x => x.GetSizeInKB());
        }

        public void Add(FileSystemItem component)
        {
            this.Items.Add(component);
        }

        public void Remove(FileSystemItem component)
        {
            this.Items.Remove(component);
        }

    }
}
