using System;
using System.Xml;
using System.Xml.Linq;

namespace XMLCommentRemover
{
    class Program
    {
        /// <summary>
        ///    The name of input XML file
        /// </summary>
        /// <remarks>
        ///     Obtained from a commandline param
        /// </remarks>
        static string victimFileName;

        /// <summary>
        ///    The name of output XML file (without comments)
        /// </summary>
        static string outputFileName;

        /// <summary>
        ///     The main program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// Must have a commandline param.
            if (args.Length < 1)
            {
                Console.WriteLine("Remove all comment from XML file.");
                Console.WriteLine("Syntax: removecomment.exe <filename> [output]");
                return;
            }
            else
            {
                victimFileName = args[0];
            }


            /// Get the output file name
             outputFileName = (args.Length >= 2)?(args[2]):victimFileName;

            /// Create Setting to read xml without comment and no blankline after removing comment.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;

            /// Readxml and parse
            XmlReader reader = XmlReader.Create(victimFileName, settings);

            /// Parse xml
            XDocument doc = XDocument.Load(reader); // Or whatever

            /// Save to file
            reader.Close();
            doc.Save(outputFileName);
        }
    }
}
