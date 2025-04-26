using FestivosPascua.Dominio.Entidades;

namespace FestivosPascua.Core.Utilidades
{
    public static class ClsCalcularFestivo
    {
        public static string EsFestivo(DateTime fecha, List<ClsFestivos> festivos)
        {
            foreach (var festivo in festivos)
            {
                DateTime fechaFestivo;

                switch (festivo.IdTipo)
                {
                    case 1: //Fijo
                        fechaFestivo = new DateTime(fecha.Year, festivo.Mes, festivo.Dia);
                        break;

                    case 2: //Ley Puente Festivo
                        fechaFestivo = AjustarAlLunes(new DateTime(fecha.Year, festivo.Mes, festivo.Dia));
                        break;

                    case 3: //Basado en Pascua
                        var pascua = CalcularPascua(fecha.Year);
                        fechaFestivo = pascua.AddDays(festivo.DiasPascuas);
                        break;

                    case 4: //Pascua + Ley Puente
                        var basePascua = CalcularPascua(fecha.Year).AddDays(festivo.DiasPascuas);
                        fechaFestivo = AjustarAlLunes(basePascua);
                        break;

                    default:
                        continue;
                }

                if (fechaFestivo.Date == fecha.Date)
                    return $"Es festivo: {festivo.Nombre}";
            }

            return "No es festivo.";
        }

        //Calcula el primer lunes después de la fecha (incluyéndola si ya es lunes)
        private static DateTime AjustarAlLunes(DateTime fecha)
        {
            while (fecha.DayOfWeek != DayOfWeek.Monday)
            {
                fecha = fecha.AddDays(1);
            }
            return fecha;
        }

        //Cálculo de la fecha de Pascua para un año dado (método de Gauss)
        private static DateTime CalcularPascua(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int mes = (h + l - 7 * m + 114) / 31;
            int dia = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, mes, dia);
        }

        public static List<string> ObtenerFestivosDelMes(int año, int mes, List<ClsFestivos> festivos)
        {
            List<string> festivosDelMes = new List<string>();

            //Calcular la fecha del Domingo de Pascua una sola vez
            DateTime pascua = CalcularPascua(año);

            foreach (var festivo in festivos)
            {
                DateTime fechaFestivo;

                switch (festivo.IdTipo)
                {
                    case 1: //Fijo
                        fechaFestivo = new DateTime(año, festivo.Mes, festivo.Dia);
                        break;

                    case 2: //Ley de puente festivo
                        fechaFestivo = AjustarAlLunes(new DateTime(año, festivo.Mes, festivo.Dia));
                        break;

                    case 3: //Basado en Pascua
                        fechaFestivo = pascua.AddDays(festivo.DiasPascuas);
                        break;

                    case 4: //Pascua + Ley del puente
                        var fechaBase = pascua.AddDays(festivo.DiasPascuas);
                        fechaFestivo = AjustarAlLunes(fechaBase);
                        break;

                    default:
                        continue;
                }

                if (fechaFestivo.Month == mes)
                {
                    festivosDelMes.Add($"{fechaFestivo:dd/MM/yyyy} - {festivo.Nombre}");
                }
            }

            return festivosDelMes;
        }
    }
}
