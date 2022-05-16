using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionClases.DTO
{
    public class BancoDTO
    {
        private int id;
        private int numero;
        private CeldaDTO[] celdas;

        public int Id { get => id; set => id = value; }
        public int Numero { get => numero; set => numero = value; }
        public CeldaDTO[] Celdas { get => celdas; set => celdas = value; }

        public BancoDTO()
        {
            this.celdas = new CeldaDTO[] {}; 
            // Inicializar un arreglo de objetos vacíos del tipo CeldaDTO
        }

        public BancoDTO(int id, int numero, CeldaDTO[] celdas)
        {
            this.celdas = new CeldaDTO[] { };
            this.id = id;
            this.numero = numero;
            this.celdas = celdas;
        }
    }
}
