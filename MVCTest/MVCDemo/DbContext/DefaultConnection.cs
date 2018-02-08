using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.DbContext
{
    public class DefaultConnection
    {
        private static volatile DefaultConnection instance;
        private static object syncRoot = new Object();
        private DefaultConnection() {
            IdActual = 0;
        }

        public List<Persona> Personas = new List<Persona>();
        public int IdActual { get; set; }

        public static DefaultConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DefaultConnection();
                    }
                }
                return instance;
            }
        }
    }
}