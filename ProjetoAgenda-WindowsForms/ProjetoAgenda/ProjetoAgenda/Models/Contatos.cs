namespace ProjetoAgenda.Models;

public class Contatos
{
    private readonly List<Contato> agenda;

    public IReadOnlyList<Contato> Agenda => agenda.AsReadOnly();

    public Contatos()
    {
        agenda = new List<Contato>();
    }

    public bool adicionar(Contato c)
    {
        if (c == null || pesquisar(c) != null)
            return false;

        agenda.Add(c);
        return true;
    }

    public Contato? pesquisar(Contato c)
    {
        return agenda.FirstOrDefault(item => item.Equals(c));
    }

    public bool alterar(Contato c)
    {
        if (c == null)
            return false;

        int indice = agenda.FindIndex(item => item.Equals(c));
        if (indice < 0)
            return false;

        agenda[indice] = c;
        return true;
    }

    public bool alterar(Contato original, Contato atualizado)
    {
        int indice = agenda.FindIndex(item => ReferenceEquals(item, original));
        if (indice < 0)
            return false;

        bool emailEmUso = agenda
            .Where((_, i) => i != indice)
            .Any(item => item.Equals(atualizado));

        if (emailEmUso)
            return false;

        agenda[indice] = atualizado;
        return true;
    }

    public bool remover(Contato c)
    {
        Contato? existente = pesquisar(c);
        if (existente == null)
            return false;

        return agenda.Remove(existente);
    }
}
