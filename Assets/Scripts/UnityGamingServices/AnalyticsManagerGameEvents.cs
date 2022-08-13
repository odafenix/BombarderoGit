using System.Collections.Generic;

namespace UnityGamingServices
{
    public partial class AnalyticsManager
    {
        public static void RegistrarNavegacion(string nombreEscena)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("nombreEscena", nombreEscena);
            TrackEvent("Navegacion", parametros);
        }

        public static void RegistrarDanioJugador(int cantidad, string nombreEnemigo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("cantidad", cantidad);
            parametros.Add("nombreEnemigo", nombreEnemigo);
            TrackEvent("DañoJugador", parametros);
        }
    }
}