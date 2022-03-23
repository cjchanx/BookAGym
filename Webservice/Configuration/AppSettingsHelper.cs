namespace Webservice.Configuration
{
    public class AppSettingsHelper
    {

        #region Constants

        private const string SECTION__DATABASE = "Database";
        private const string FIELD__CONNECTION_STRING = "ConnectionString";

        #endregion

        #region Initialization

        /// <summary>
        /// Reference to the appsettings.json configuration file.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor called by the service provider.
        /// Using injection to get the parameters.
        /// </summary>
        public AppSettingsHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Database

        /// <summary>
        /// Database connection string.
        /// </summary>
        public string DATABASE_CONNECTION_STRING
        {
            get
            {
                return Configuration.GetSection(SECTION__DATABASE).GetValue<string>(FIELD__CONNECTION_STRING);
            }
        }

        #endregion

    }
}
