using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Multi_Threaded_RW
{
    // a controller for a sequential text file:
    // allows a thread to read or write the file
    public class FileController
    {
        private File thefile;  // the file controlled by this controller

        public Status state;// I.  DECLARE AND USE A STATE VARIABLE THAT REMEMBERS STATE OF thefile's USE
        // II. ADD CODE TO PREVENT TWO THREADS FROM OPENING THE FILE AT THE SAME INSTANT.

        public FileController(File f) { thefile = f; }

        // opens the file for read use; returns handle to file.  
        // If file cannot be opened, returns null.
        public Reader openRead()
        {

           
            lock (this)
            {   
                Reader r = null;

                if (state == Status.Closed)
                {
                    state = Status.Reading;
                    thefile.initRead();
                    r = thefile;

                }
                return r;
            }
        }

        // opens the file for write use; returns handle to file.  
        //   If file cannot be opened, returns null.
        public Writer openWrite()
        {
            
            Writer w = thefile;
            lock (this)
            {
                if (state == Status.Closed)
                {
                    state = Status.Writing;
                    thefile.initWrite();
                    w = thefile;
      
                }
                return w;
            }
        }

        // closes file
        public void close()
        {
            state = Status.Closed;
        }
    }
}
