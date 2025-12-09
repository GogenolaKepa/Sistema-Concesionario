namespace Entidades.ModulodeSeguridad
{
    public class Grupo
    {
        private int grupoId;
        private string nombreGrupo;

        public int GrupoId
        {
            get { return grupoId; }
            set { grupoId = value; }
        }

        public string NombreGrupo
        {
            get { return nombreGrupo; }
            set { nombreGrupo = value; }
        }
    }
}
