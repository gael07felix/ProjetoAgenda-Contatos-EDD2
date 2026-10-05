namespace ProjetoAgenda.Models;

public class Data
{
    private int dia;
    private int mes;
    private int ano;

    public int Dia
    {
        get => dia;
        set => dia = value;
    }

    public int Mes
    {
        get => mes;
        set => mes = value;
    }

    public int Ano
    {
        get => ano;
        set => ano = value;
    }

    public Data()
    {
        setData(1, 1, 2000);
    }

    public Data(int dia, int mes, int ano)
    {
        setData(dia, mes, ano);
    }

    public void setData(int dia, int mes, int ano)
    {
        var valor = new DateTime(ano, mes, dia);
        this.dia = valor.Day;
        this.mes = valor.Month;
        this.ano = valor.Year;
    }

    public DateTime ToDateTime()
    {
        return new DateTime(ano, mes, dia);
    }

    public override string ToString()
    {
        return $"{dia:00}/{mes:00}/{ano:0000}";
    }
}
