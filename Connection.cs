using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList
{
    public class Connection
    {
        static private string servidor = "localhost";
        static private string db = "task_list";
        static private string usuario = "root";
        static private string senha = "123456";

        static public string ConnectionString = $"server={servidor}; database={db}; User Id={usuario}; password={senha}";
    }
}