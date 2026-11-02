namespace ApiJwt.Models
{
    // Classe que representa os dados enviados pelo usuário no login.
    public class LoginModel
    {
        // Nome do usuário informado no login.
        public string Usuario { get; set; } = string.Empty;

        // Senha informada no login.
        public string Senha { get; set; } = string.Empty;
    }
}