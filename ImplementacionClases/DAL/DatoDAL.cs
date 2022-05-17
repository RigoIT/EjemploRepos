using ImplementacionClases.DTO;

namespace ImplementacionClases.DAL
{
    public class DatoDAL
    {
        public bool Insertar(DatoDTO datos)
        {
            return DatoDTO.Add(datos);
        }

        public bool Actualizar(DatoDTO datos)
        {
            return false; // NO OLVIDAR
        }

        public bool Eliminar(DatoDTO datos)
        {
            return false; // NO OLVIDAR
        }

        public List<DatoDTO> Listar()
        {
            // return null;
            return DatoDTO.List();
        }

    }
}
