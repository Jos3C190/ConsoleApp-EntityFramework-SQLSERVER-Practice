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
                var cursos = db.Curso.Include(p => p.PrecioPromocion).AsNoTracking();

                foreach(var curso in cursos) {
                    Console.WriteLine(curso.Titulo + " | " + curso.PrecioPromocion.PrecioActual);
                }
            }

        }
    }
}