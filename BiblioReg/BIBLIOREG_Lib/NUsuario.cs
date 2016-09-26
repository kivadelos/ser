using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using System.Data;

namespace BIBLIOREG_Lib
{
    public class NUsuario
    {
      //Método que llama al método Insertar de la Capa de Datos de la clase DUsuario
        public static string Insertar(string nombre, string acceso, string usuario, string password,byte[] imagen)
        {
            DUsuario Obj = new DUsuario();
            Obj.Nombre = nombre;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Imagen = imagen;
           
            
            return Obj.Insertar(Obj);
        }
        //Método que llama al método Actualizar de la Capa de Datos de la clase DUsuario
        public static string Editar(int idUsuario, string nombre, string acceso, string usuario, string password,byte[] imagen)
        {
            DUsuario Obj = new DUsuario();
            Obj.IdUsuario = idUsuario;
            Obj.Nombre = nombre;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Imagen = imagen;
            
           
            return Obj.Editar(Obj);
        }

        //Método que se encarga de llamar al método Eliminar de la clase DUsuario
        public static string Eliminar(int IdUsuario)
        {
            DUsuario Obj = new DUsuario();
            Obj.IdUsuario = IdUsuario;

            return Obj.Eliminar(Obj);
        }

        //Método que se encarga de llamar al método Mostrar de la clase DUsuario
        public static DataTable Mostrar()
        {
            return new DUsuario().Mostrar();
        }
        
        //Método BuscarNombre que llama al Método BuscarNombre de la clase DUsuario de la capa de datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        
        public static DataTable Login(string usuario, string password)
        {
            DUsuario Obj = new DUsuario();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }

    
    }
}
