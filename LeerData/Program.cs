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
                var cursos = db.Curso
                .Include(p => p.PrecioPromocion)
                .Include(c => c.ComentarioLista)
                .AsNoTracking();

                foreach(var curso in cursos) {
                    Console.WriteLine($"{curso.Titulo}  |  ${curso.PrecioPromocion.PrecioActual}");
                    Console.WriteLine("Comentarios:" );

                    foreach(var comentario in curso.ComentarioLista) {
                        Console.WriteLine("*****" + comentario.ComentarioTexto);
                    }
                }
            }

        }
    }
}