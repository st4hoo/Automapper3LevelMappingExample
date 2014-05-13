using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Automapper3LevelMappingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseA dbA = new DatabaseA
            {
                id = 1,
                nom = "dbA",
                Bprop = new DatabaseB
                {
                    id = 10,
                    nom = "dbB",
                    Cprop = new DatabaseC
                    {
                        id = 100,
                        nom = "dbC"
                    }
                }
            };

            Mapper.CreateMap<DatabaseA, A>()
                .ForMember(dest => dest.Bprop , opt => opt.MapFrom(src => src.Bprop));

            Mapper.CreateMap<DatabaseB,B>()
                .ForMember(dest => dest.Cprop , opt => opt.MapFrom(src => src.Cprop));

            Mapper.CreateMap<DatabaseC, C>();

            var a = Mapper.Map<DatabaseA, A>(dbA);

        }
    }

    class A
    {
        public int id { get; set; }
        public string nom { get; set; }
        public B Bprop { get; set; }
    }

    class B
    {
        public int id { get; set; }
        public string nom { get; set; }
        public C Cprop { get; set; }
    }

    class C
    {
        public int id { get; set; }
        public string nom { get; set; }
    }

    class DatabaseA
    {
        public int id { get; set; }
        public string nom { get; set; }
        public DatabaseB Bprop { get; set; }
    }

    class DatabaseB
    {
        public int id { get; set; }
        public string nom { get; set; }
        public DatabaseC Cprop { get; set; }
    }

    class DatabaseC
    {
        public int id { get; set; }
        public string nom { get; set; }
    }

}
