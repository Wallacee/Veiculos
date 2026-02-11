namespace Veiculos.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Login { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;

        private Usuario() { }

        public Usuario(string nome, string login, string senhaHash)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Login = login;
            SenhaHash = senhaHash;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }

        public void AtualizarSenha(string novaHash)
        {
            SenhaHash = novaHash;
        }
    }
}
