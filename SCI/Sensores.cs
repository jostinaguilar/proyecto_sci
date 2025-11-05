using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class Sensores
    {
        public int[] IdsSensores()
        {
            int[] ids = { 1, 2, 3, 4, 5, 6 };
            return ids;
        }

        public string[] TiposSensores()
        {
            string[] tipos = { "Temperatura", "Humo", "Manual", "Temperatura", "Humo", "Manual" };
            return tipos;
        }

        public string[] UbicacionesSensores()
        {
            string[] ubicaciones = { "Oficina", "Sala de Reuniones", "Gerencia", "Almacén", "Pasillo", "Grupo Electrógeno" };
            return ubicaciones;
        }

        public int[] EstadosSensores()
        {
            int[] estados = { 0, 0, 0, 0, 0, 0 };
            return estados;
        }
    }
}
