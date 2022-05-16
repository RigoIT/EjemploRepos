using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionClases.DTO
{
    public class CeldaDTO
    {
        private int id;
        private int numero;

        public int Id { get => id; set => id = value; }
        public int Numero { get => numero; set => numero = value; }
    }
}
