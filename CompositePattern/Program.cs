﻿using CompositePattern.Structural;
using System;
using System.Xml.Linq;

namespace CompositePattern
{
    class Program
    {
        // Client object
        static void Main(string[] args)
        {
            var xml = XElement.Load("file-system.xml");
            foreach (var leaf in xml.FindElements(x => !x.HasElements))
            {
                Console.WriteLine($"*** LEAF : {leaf.Attribute("name")}, {leaf.Attribute("fileBytes")}");
            }
        }

        private static void FileSystemExample()
        {
            var builder = new FileSystemBuilder("development");
            builder.AddDirectory("project1");
            builder.AddFile("p1f1.txt", 2100);
            builder.AddFile("p1f2.txt", 3100);
            builder.AddDirectory("sub-dir");
            builder.AddFile("p1f3.txt", 4100);
            builder.AddFile("p1f4.txt", 5100);
            builder.SetCurrentDirectory("project1");
            builder.AddFile("test", 666);
            Console.WriteLine("Total fize size(kb): " + builder.Root.GetSizeInKB());
            //Console.WriteLine(JsonConvert)
        }

        private static void FileSystemComposite()
        {
            var root = new DirectoryItem("development");
            var proj1 = new DirectoryItem("project1");
            var proj2 = new DirectoryItem("project2");

            root.Add(proj1);
            root.Add(proj2);

            proj1.Add(new FileItem("p1f1.txt", 2100));
            proj1.Add(new FileItem("p1f2.txt", 3100));

            var subdir = new DirectoryItem("sub-dir1");
            proj1.Add(subdir);

            subdir.Add(new FileItem("p1f3.txt", 4100));
            subdir.Add(new FileItem("p1f4.txt", 5100));

            proj2.Add(new FileItem("p2f1.txt", 6100));
            proj2.Add(new FileItem("p2f2.txt", 7100));

            Console.WriteLine($"Total size (proj2): {proj2.GetSizeInKB()}");
            Console.WriteLine($"Total size (proj1): {proj1.GetSizeInKB()}");
            Console.WriteLine($"Total size (root): {root.GetSizeInKB()}");
        }

        private static void StructuralExample()
        {
            // Create a tree structure
            var root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var comp1 = new Composite("Composite C1");
            comp1.Add(new Leaf("Leaf C1-A"));
            comp1.Add(new Leaf("Leaf C1-B"));
            var comp2 = new Composite("Composite C2");
            comp2.Add(new Leaf("Leaf C2-A"));
            comp1.Add(comp2);

            root.Add(comp1);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.PrimaryOperation(1);
        }
    }
}
