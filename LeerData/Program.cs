using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    class Program
    {
        static void Main(string[] arg) 
        {
            
            using(var db = new AppVentaCursosContext()) {
                var cursos = db.Curso.AsNoTracking();
                
                foreach(var curso in cursos) {
                    Console.WriteLine(curso.Titulo + "\t | \t" + curso.Descripcion);
                }
            }

        }
    }
}