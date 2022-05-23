using ImplementacionClases.DTO;

namespace ImplementacionClases.DAL
{
    public class DatoDAL
    {
        public bool Insertar(DatoDTO datos)
        {
            return DatoDTO.Add(datos);
        }

        public bool Actualizar(DatoDTO dato)
        {
            // obtener índice de objeto a editar
            int indice = BuscarPorId(dato); 
            
            // retornar el resultado de la edición del objeto en la lista
            return DatoDTO.Edit(dato, indice);  
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

        public int BuscarPorId(DatoDTO dato)
        {
            // método 1: tradicional (intro a programación)
            for (int i = 0; i < DatoDTO.List().Count; i++)
            {
                // si encuentra elemento
                if (DatoDTO.List()[i].Id == dato.Id)
                {
                    return i; // retorna índice de elemento
                }
            }
            return 0;
        }

        // el "?" implica que el retorno puede ser nulo
        public DatoDTO? BuscarPorId(int id)
        {
            //// método 1: tradicional (intro a programación)
            //for(int i = 0; i < DatoDTO.List().Count; i++)
            //{
            //    // si encuentra elemento
            //    if (DatoDTO.List()[i].Id == id)
            //    {
            //        return DatoDTO.List()[i]; // retorna elemento
            //    } 
            //}

            //// retorno en caso de no encontrar
            //return null; 

            // método 2: foreach
            foreach (DatoDTO dato in DatoDTO.List())
            {
                if (dato.Id == id) { return dato; }
            }

            // retorno en caso de no encontrar
            return null;

            //// método 3: expresiones (expresiones LinQ)
            //// method syntax
            //DatoDTO resultadoDato = DatoDTO.List().FirstOrDefault(x => x.Id == id);
            //// query syntax
            //DatoDTO resultadoDato2 = (from dato in DatoDTO.List()
            //                         where dato.Id == id
            //                         select dato).FirstOrDefault();
        }

    }
}
