namespace TelaDeLogin
{
    public class Settings
    {
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// String de conexão com o Postgre
        /// </summary>
        public static string SQLConnectionString => Configuration.GetConnectionString("DefaultConnection");
    }
}
