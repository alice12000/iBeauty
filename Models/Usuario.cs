using IBeauty.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public CadastroUsuario Cadastro { get; set; }

    public Usuario(int id, string email, string senha, CadastroUsuario cadastro)
    {
        Id = id;
        Email = email;
        Senha = senha;
        Cadastro = cadastro;
    }
}
