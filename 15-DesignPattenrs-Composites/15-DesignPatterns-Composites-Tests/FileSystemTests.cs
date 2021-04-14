using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns_Composites;

namespace DesignPatterns_Composites_Tests
{
    [TestClass]
    public class FileSystemTests
    {
        [TestMethod]
        public void PrintFileSystem()
        {
            // try making a file system:
            Folder filesystem = makeSystem();

            // try printing the names of all its contents:
            Console.WriteLine("FILE SYSTEM CONTENTS:"); Console.WriteLine();
            Console.WriteLine(filesystem.ToString());

            // Since  a.txt  is saved in Root filesystem, we can fetch it and print it:
            Console.WriteLine("FIND AND PRINT contents of  a.txt,  saved in Root filesystem:");
            Entry atxt = filesystem.find("a.txt");
            displayTextFile(atxt);   // see method  displayTextFile  below
            Console.WriteLine();
        }

        [TestMethod]
        public void Find_A()
        {
            // try making a file system:
            var filesystem = makeSystem();
            var t = filesystem.search("a.txt");
            Assert.AreEqual("I am file a.txt\r\nEnd of a.txt\r\n", getTextFileContent(t));
        }

        [TestMethod]
        public void Find_F_b()
        {
            // try making a file system:
            var filesystem = makeSystem();
            var t = filesystem.search("F/b.txt");
            Assert.AreEqual("I am file b.txt.  The end.\r\n", getTextFileContent(t));
        }

        [TestMethod]
        public void Find_F_A_Link()
        {
            // try making a file system:
            var filesystem = makeSystem();
            var e = filesystem.search("F/LinkTo a");
            Assert.AreEqual("I am file a.txt\r\nEnd of a.txt\r\n", getTextFileContent(e));
        }

        [TestMethod]
        public void Find_F_B_Folder_Link()
        {
            // try making a file system:
            var filesystem = makeSystem();
            var e = filesystem.search("F/G/Link To Folder F/b.txt");
            Assert.AreEqual("I am file b.txt.  The end.\r\n", getTextFileContent(e));
        }

        [TestMethod]
        public void Find_Silly_Link()
        {
            // try making a file system:
            var filesystem = makeSystem();
            var f = filesystem.search("SillyLink/a.txt");
            Assert.AreEqual(null, getTextFileContent(f));
        }

        // assembles a sample filesystem whose root folder is named "Root"; returns handle.
        Folder makeSystem()
        {
            Folder filesystem = new Folder("Root");

            TextFile a = new TextFile("a.txt");
            a.addLine("I am file a.txt"); a.addLine("End of a.txt");
            filesystem.add(a);

            Folder f = new Folder("F");
            filesystem.add(f);

            TextFile b = new TextFile("b.txt");
            b.addLine("I am file b.txt.  The end.");
            f.add(b);

            Shortcut s = new Shortcut("LinkTo a", a);
            f.add(s);

            Folder g = new Folder("G");
            f.add(g);

            TextFile c = new TextFile("c.txt");
            c.addLine("I am file c.txt.  The end.");
            g.add(c);

            g.add(new Shortcut("Link To Folder F", f));  // circular link

            Folder h = new Folder("H");
            filesystem.add(h);

            return filesystem;
        }

        String getTextFileContent(Entry e)
        {
            if (e is Shortcut) return getTextFileContent(((Shortcut)e).Link);
            else if (e is TextFile) return ((TextFile)e).Lines;
            else return null;
        }


        // writes on the Console the lines in the textfile indicated by object  e :
        void displayTextFile(Entry e)
        {
            var text = getTextFileContent(e);
            if (text != null)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("invalid entry");
            }
        }
    }
}
