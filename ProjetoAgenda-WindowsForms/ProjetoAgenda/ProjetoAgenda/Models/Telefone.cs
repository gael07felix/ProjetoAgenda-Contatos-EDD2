namespace ProjetoAgenda.Models;

public class Telefone
{
    private string tipo;
    private string numero;
    private bool principal;

    public string Tipo
    {
        get => tipo;
        set => tipo = value;
    }

    public string Numero
    {
        get => numero;
        set => numero = value;
    }

    public bool Principal
    {
        get => principal;
        set => principal = value;
    }

    public Telefone()
    {
        tipo = string.Empty;
        numero = string.Empty;
    }

    public Telefone(string tipo, string numero, bool principal)
    {
        this.tipo = tipo;
        this.numero = numero;
        this.principal = principal;
    }

    public override string ToString()
    {
        string marcador = principal ? " (principal)" : string.Empty;
        return $"{tipo}: {numero}{marcador}";
    }
}
