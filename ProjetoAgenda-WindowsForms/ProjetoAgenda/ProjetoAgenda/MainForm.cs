using ProjetoAgenda.Models;

namespace ProjetoAgenda;

public partial class MainForm : Form
{
    private readonly Contatos contatos = new();
    private readonly List<Telefone> telefonesEmEdicao = new();
    private Contato? contatoSelecionado;

    public MainForm()
    {
        InitializeComponent();
        AtualizarListaContatos();
    }

    private void btnAdicionarTelefone_Click(object sender, EventArgs e)
    {
        string tipo = txtTipoTelefone.Text.Trim();
        string numero = txtNumeroTelefone.Text.Trim();

        if (string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(numero))
        {
            MessageBox.Show("Informe o tipo e o número do telefone.", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        bool principal = chkPrincipal.Checked || telefonesEmEdicao.Count == 0;

        if (principal)
        {
            foreach (Telefone telefone in telefonesEmEdicao)
                telefone.Principal = false;
        }

        telefonesEmEdicao.Add(new Telefone(tipo, numero, principal));
        AtualizarListaTelefones();

        txtTipoTelefone.Clear();
        txtNumeroTelefone.Clear();
        chkPrincipal.Checked = false;
        txtTipoTelefone.Focus();
    }

    private void btnRemoverTelefone_Click(object sender, EventArgs e)
    {
        if (lstTelefones.SelectedIndex < 0)
            return;

        Telefone removido = telefonesEmEdicao[lstTelefones.SelectedIndex];
        bool eraPrincipal = removido.Principal;
        telefonesEmEdicao.RemoveAt(lstTelefones.SelectedIndex);

        if (eraPrincipal && telefonesEmEdicao.Count > 0)
            telefonesEmEdicao[0].Principal = true;

        AtualizarListaTelefones();
    }

    private void btnAdicionar_Click(object sender, EventArgs e)
    {
        if (!TryCriarContato(out Contato? contato))
            return;

        if (!contatos.adicionar(contato!))
        {
            MessageBox.Show("Já existe um contato com esse e-mail.", "Contato duplicado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        MessageBox.Show("Contato adicionado com sucesso!", "Agenda",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        LimparFormulario();
        AtualizarListaContatos();
    }

    private void btnAlterar_Click(object sender, EventArgs e)
    {
        if (contatoSelecionado == null)
        {
            MessageBox.Show("Selecione um contato na lista para alterar.", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!TryCriarContato(out Contato? atualizado))
            return;

        if (!contatos.alterar(contatoSelecionado, atualizado!))
        {
            MessageBox.Show("Não foi possível alterar. Verifique se o novo e-mail já pertence a outro contato.",
                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        MessageBox.Show("Contato alterado com sucesso!", "Agenda",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        LimparFormulario();
        AtualizarListaContatos();
    }

    private void btnRemover_Click(object sender, EventArgs e)
    {
        if (contatoSelecionado == null)
        {
            MessageBox.Show("Selecione um contato para remover.", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult resposta = MessageBox.Show(
            $"Deseja remover o contato {contatoSelecionado.Nome}?",
            "Confirmar remoção",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (resposta != DialogResult.Yes)
            return;

        contatos.remover(contatoSelecionado);
        LimparFormulario();
        AtualizarListaContatos();
    }

    private void btnPesquisar_Click(object sender, EventArgs e)
    {
        AtualizarListaContatos(txtPesquisa.Text.Trim());
    }

    private void btnListarTodos_Click(object sender, EventArgs e)
    {
        txtPesquisa.Clear();
        AtualizarListaContatos();
    }

    private void btnLimpar_Click(object sender, EventArgs e)
    {
        LimparFormulario();
    }

    private void btnSair_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvContatos_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvContatos.CurrentRow?.DataBoundItem is not ContatoGridItem item)
            return;

        Contato contato = item.Contato;
        contatoSelecionado = contato;
        txtNome.Text = contato.Nome;
        txtEmail.Text = contato.Email;
        dtpNascimento.Value = contato.DtNasc.ToDateTime();

        telefonesEmEdicao.Clear();
        foreach (Telefone telefone in contato.Telefones)
            telefonesEmEdicao.Add(new Telefone(telefone.Tipo, telefone.Numero, telefone.Principal));

        AtualizarListaTelefones();
    }

    private bool TryCriarContato(out Contato? contato)
    {
        contato = null;

        string nome = txtNome.Text.Trim();
        string email = txtEmail.Text.Trim();

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show("Nome e e-mail são obrigatórios.", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (!email.Contains('@') || !email.Contains('.'))
        {
            MessageBox.Show("Informe um e-mail válido.", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        DateTime nascimento = dtpNascimento.Value.Date;
        if (nascimento > DateTime.Today)
        {
            MessageBox.Show("A data de nascimento não pode estar no futuro.", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        Data data = new(nascimento.Day, nascimento.Month, nascimento.Year);
        contato = new Contato(nome, email, data);

        foreach (Telefone telefone in telefonesEmEdicao)
        {
            contato.adicionarTelefone(
                new Telefone(telefone.Tipo, telefone.Numero, telefone.Principal));
        }

        return true;
    }

    private void AtualizarListaTelefones()
    {
        lstTelefones.DataSource = null;
        lstTelefones.DataSource = telefonesEmEdicao.ToList();
    }

    private void AtualizarListaContatos(string filtro = "")
    {
        IEnumerable<Contato> lista = contatos.Agenda;

        if (!string.IsNullOrWhiteSpace(filtro))
        {
            lista = lista.Where(c =>
                c.Nome.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                c.getTelefonePrincipal().Contains(filtro, StringComparison.OrdinalIgnoreCase));
        }

        dgvContatos.DataSource = null;
        dgvContatos.DataSource = lista
            .OrderBy(c => c.Nome)
            .Select(c => new ContatoGridItem(c))
            .ToList();

        if (dgvContatos.Columns[nameof(ContatoGridItem.Contato)] != null)
            dgvContatos.Columns[nameof(ContatoGridItem.Contato)].Visible = false;

        lblTotal.Text = $"Total: {dgvContatos.Rows.Count} contato(s)";
    }

    private void LimparFormulario()
    {
        contatoSelecionado = null;
        txtNome.Clear();
        txtEmail.Clear();
        dtpNascimento.Value = DateTime.Today;
        txtTipoTelefone.Clear();
        txtNumeroTelefone.Clear();
        chkPrincipal.Checked = false;
        telefonesEmEdicao.Clear();
        AtualizarListaTelefones();
        dgvContatos.ClearSelection();
        txtNome.Focus();
    }

    private sealed class ContatoGridItem
    {
        [System.ComponentModel.Browsable(false)]
        public Contato Contato { get; }
        public string Nome => Contato.Nome;
        public string Email => Contato.Email;
        public string Nascimento => Contato.DtNasc.ToString();
        public int Idade => Contato.getIdade();
        public string TelefonePrincipal => Contato.getTelefonePrincipal();

        public ContatoGridItem(Contato contato)
        {
            Contato = contato;
        }
    }
}
