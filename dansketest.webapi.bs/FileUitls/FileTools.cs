using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace dansketest.webapi.bs.FileUitls
{
    public class FileTools : IFileTools
    {
        private object _lock;
        private readonly string _fnm;

        public FileTools(IConfiguration config)
        {
            _lock = new object();
            _fnm = config["ResultPath"];
        }


        public void WriteToFile(string content)
        {
            lock (_lock)
            {
                System.IO.File.WriteAllText(_fnm, content);
            }
        }

        public string ReadFile()
        {
            lock (_lock)
            {
                return System.IO.File.ReadAllText(_fnm);

            }
        }
    }
}
