namespace ProjetoAgenda.Models;

public class Contato
{
    private string email;
    private string nome;
    private Data dtNasc;
    private readonly List<Telefone> telefones;

    public string Email
    {
        get => email;
        set => email = value;
    }

    public string Nome
    {
        get => nome;
        set => nome = value;
    }

    public Data DtNasc
    {
        get => dtNasc;
        set => dtNasc = value;
    }

    public IReadOnlyList<Telefone> Telefones => telefones.AsReadOnly();

    public Contato()
    {
        email = string.Empty;
        nome = string.Empty;
        dtNasc = new Data();
        telefones = new List<Telefone>();
    }

    public Contato(string nome, string email, Data dtNasc)
    {
        this.nome = nome;
        this.email = email;
        this.dtNasc = dtNasc;
        telefones = new List<Telefone>();
    }

    public int getIdade()
    {
        DateTime hoje = DateTime.Today;
        DateTime nascimento = dtNasc.ToDateTime();

        int idade = hoje.Year - nascimento.Year;
        if (nascimento.Date > hoje.AddYears(-idade))
            idade--;

        return idade;
    }

    public void adicionarTelefone(Telefone t)
    {
        if (t == null)
            throw new ArgumentNullException(nameof(t));

        if (t.Principal)
        {
            foreach (Telefone telefone in telefones)
                telefone.Principal = false;
        }

        telefones.Add(t);

        if (telefones.Count == 1)
            telefones[0].Principal = true;
    }

    public void removerTelefone(Telefone t)
    {
        bool eraPrincipal = t.Principal;
        telefones.Remove(t);

        if (eraPrincipal && telefones.Count > 0)
            telefones[0].Principal = true;
    }

    public void limparTelefones()
    {
        telefones.Clear();
    }

    public string getTelefonePrincipal()
    {
        Telefone? telefone = telefones.FirstOrDefault(t => t.Principal)
                             ?? telefones.FirstOrDefault();

        return telefone?.Numero ?? "Sem telefone";
    }

    public override string ToString()
    {
        return $"Nome: {nome} | E-mail: {email} | Nascimento: {dtNasc} | Idade: {getIdade()} | Telefone principal: {getTelefonePrincipal()}";
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is not Contato outro)
            return false;

        return string.Equals(email.Trim(), outro.email.Trim(), StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(email.Trim());
    }
}
