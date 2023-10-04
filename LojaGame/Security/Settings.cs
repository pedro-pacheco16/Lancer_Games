namespace LojaGame.Security
{
    public class Settings
    {
        private static string secret = "cdc1a3d00fd6704edd1844585e9881cde76eeb25e5ec710f97ef963aad60f8e6";

        public static string Secret { get => secret; set => secret = value; }
    }
}
