using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new AppVentaCursosContext())
            {
                var cursos = db.Curso
                .Include(p => p.PrecioPromocion)
                .Include(c => c.ComentarioLista)
                .Include(i => i.InstructorLink)
                    .ThenInclude(ci => ci.Instructor)
                .AsNoTracking();

                foreach (var curso in cursos)
                {
                    Console.WriteLine($"{curso.Titulo}  |  ${curso.PrecioPromocion?.PrecioActual}");

                    Console.WriteLine("Impartido por: ");
                    foreach (var insLink in curso.InstructorLink)
                    {
                        if (insLink.Instructor != null)
                        {
                            Console.WriteLine($"- {insLink.Instructor.Nombre} {insLink.Instructor.Apellidos}");
                        }
                    }

                    Console.WriteLine("Comentarios:");
                    foreach (var comentario in curso.ComentarioLista)
                    {
                        if (comentario != null)
                        {
                            Console.WriteLine("*****" + comentario.ComentarioTexto);
                        }
                    }
                }
            }

        }
    }
}