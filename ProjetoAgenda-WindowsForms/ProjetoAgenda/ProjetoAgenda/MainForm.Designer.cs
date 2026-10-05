namespace ProjetoAgenda;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        grpContato = new GroupBox();
        lblNome = new Label();
        txtNome = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblNascimento = new Label();
        dtpNascimento = new DateTimePicker();
        grpTelefone = new GroupBox();
        lblTipoTelefone = new Label();
        txtTipoTelefone = new TextBox();
        lblNumeroTelefone = new Label();
        txtNumeroTelefone = new TextBox();
        chkPrincipal = new CheckBox();
        btnAdicionarTelefone = new Button();
        btnRemoverTelefone = new Button();
        lstTelefones = new ListBox();
        btnAdicionar = new Button();
        btnAlterar = new Button();
        btnRemover = new Button();
        btnLimpar = new Button();
        grpAgenda = new GroupBox();
        txtPesquisa = new TextBox();
        btnPesquisar = new Button();
        btnListarTodos = new Button();
        dgvContatos = new DataGridView();
        lblTotal = new Label();
        btnSair = new Button();
        grpContato.SuspendLayout();
        grpTelefone.SuspendLayout();
        grpAgenda.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvContatos).BeginInit();
        SuspendLayout();

        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitulo.Location = new Point(24, 18);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(214, 37);
        lblTitulo.Text = "Agenda de Contatos";

        grpContato.Controls.Add(lblNome);
        grpContato.Controls.Add(txtNome);
        grpContato.Controls.Add(lblEmail);
        grpContato.Controls.Add(txtEmail);
        grpContato.Controls.Add(lblNascimento);
        grpContato.Controls.Add(dtpNascimento);
        grpContato.Location = new Point(24, 70);
        grpContato.Name = "grpContato";
        grpContato.Size = new Size(470, 184);
        grpContato.TabStop = false;
        grpContato.Text = "Dados do contato";

        lblNome.AutoSize = true;
        lblNome.Location = new Point(18, 34);
        lblNome.Text = "Nome";
        txtNome.Location = new Point(18, 56);
        txtNome.Size = new Size(430, 23);

        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(18, 88);
        lblEmail.Text = "E-mail";
        txtEmail.Location = new Point(18, 110);
        txtEmail.Size = new Size(270, 23);

        lblNascimento.AutoSize = true;
        lblNascimento.Location = new Point(306, 88);
        lblNascimento.Text = "Nascimento";
        dtpNascimento.Format = DateTimePickerFormat.Short;
        dtpNascimento.Location = new Point(306, 110);
        dtpNascimento.Size = new Size(142, 23);

        grpTelefone.Controls.Add(lblTipoTelefone);
        grpTelefone.Controls.Add(txtTipoTelefone);
        grpTelefone.Controls.Add(lblNumeroTelefone);
        grpTelefone.Controls.Add(txtNumeroTelefone);
        grpTelefone.Controls.Add(chkPrincipal);
        grpTelefone.Controls.Add(btnAdicionarTelefone);
        grpTelefone.Controls.Add(btnRemoverTelefone);
        grpTelefone.Controls.Add(lstTelefones);
        grpTelefone.Location = new Point(510, 70);
        grpTelefone.Name = "grpTelefone";
        grpTelefone.Size = new Size(510, 184);
        grpTelefone.TabStop = false;
        grpTelefone.Text = "Telefones";

        lblTipoTelefone.AutoSize = true;
        lblTipoTelefone.Location = new Point(16, 32);
        lblTipoTelefone.Text = "Tipo";
        txtTipoTelefone.Location = new Point(16, 54);
        txtTipoTelefone.PlaceholderText = "Ex.: Celular";
        txtTipoTelefone.Size = new Size(112, 23);

        lblNumeroTelefone.AutoSize = true;
        lblNumeroTelefone.Location = new Point(138, 32);
        lblNumeroTelefone.Text = "Número";
        txtNumeroTelefone.Location = new Point(138, 54);
        txtNumeroTelefone.PlaceholderText = "(13) 99999-9999";
        txtNumeroTelefone.Size = new Size(165, 23);

        chkPrincipal.AutoSize = true;
        chkPrincipal.Location = new Point(316, 56);
        chkPrincipal.Text = "Principal";

        btnAdicionarTelefone.Location = new Point(397, 51);
        btnAdicionarTelefone.Size = new Size(96, 28);
        btnAdicionarTelefone.Text = "Adicionar";
        btnAdicionarTelefone.Click += btnAdicionarTelefone_Click;

        lstTelefones.Location = new Point(16, 91);
        lstTelefones.Size = new Size(376, 76);

        btnRemoverTelefone.Location = new Point(397, 91);
        btnRemoverTelefone.Size = new Size(96, 30);
        btnRemoverTelefone.Text = "Remover";
        btnRemoverTelefone.Click += btnRemoverTelefone_Click;

        btnAdicionar.Location = new Point(24, 270);
        btnAdicionar.Size = new Size(112, 34);
        btnAdicionar.Text = "Adicionar";
        btnAdicionar.Click += btnAdicionar_Click;

        btnAlterar.Location = new Point(144, 270);
        btnAlterar.Size = new Size(112, 34);
        btnAlterar.Text = "Alterar";
        btnAlterar.Click += btnAlterar_Click;

        btnRemover.Location = new Point(264, 270);
        btnRemover.Size = new Size(112, 34);
        btnRemover.Text = "Remover";
        btnRemover.Click += btnRemover_Click;

        btnLimpar.Location = new Point(384, 270);
        btnLimpar.Size = new Size(110, 34);
        btnLimpar.Text = "Limpar";
        btnLimpar.Click += btnLimpar_Click;

        grpAgenda.Controls.Add(txtPesquisa);
        grpAgenda.Controls.Add(btnPesquisar);
        grpAgenda.Controls.Add(btnListarTodos);
        grpAgenda.Controls.Add(dgvContatos);
        grpAgenda.Controls.Add(lblTotal);
        grpAgenda.Location = new Point(24, 322);
        grpAgenda.Name = "grpAgenda";
        grpAgenda.Size = new Size(996, 326);
        grpAgenda.TabStop = false;
        grpAgenda.Text = "Contatos cadastrados";

        txtPesquisa.Location = new Point(16, 30);
        txtPesquisa.PlaceholderText = "Pesquisar por nome, e-mail ou telefone";
        txtPesquisa.Size = new Size(520, 23);

        btnPesquisar.Location = new Point(545, 27);
        btnPesquisar.Size = new Size(100, 29);
        btnPesquisar.Text = "Pesquisar";
        btnPesquisar.Click += btnPesquisar_Click;

        btnListarTodos.Location = new Point(653, 27);
        btnListarTodos.Size = new Size(110, 29);
        btnListarTodos.Text = "Listar todos";
        btnListarTodos.Click += btnListarTodos_Click;

        dgvContatos.AllowUserToAddRows = false;
        dgvContatos.AllowUserToDeleteRows = false;
        dgvContatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvContatos.BackgroundColor = SystemColors.Window;
        dgvContatos.MultiSelect = false;
        dgvContatos.ReadOnly = true;
        dgvContatos.RowHeadersVisible = false;
        dgvContatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvContatos.Location = new Point(16, 68);
        dgvContatos.Size = new Size(964, 222);
        dgvContatos.SelectionChanged += dgvContatos_SelectionChanged;

        lblTotal.AutoSize = true;
        lblTotal.Location = new Point(16, 299);
        lblTotal.Text = "Total: 0 contato(s)";

        btnSair.Location = new Point(908, 662);
        btnSair.Size = new Size(112, 34);
        btnSair.Text = "Sair";
        btnSair.Click += btnSair_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1044, 716);
        Controls.Add(lblTitulo);
        Controls.Add(grpContato);
        Controls.Add(grpTelefone);
        Controls.Add(btnAdicionar);
        Controls.Add(btnAlterar);
        Controls.Add(btnRemover);
        Controls.Add(btnLimpar);
        Controls.Add(grpAgenda);
        Controls.Add(btnSair);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Projeto Agenda - Windows Forms";
        grpContato.ResumeLayout(false);
        grpContato.PerformLayout();
        grpTelefone.ResumeLayout(false);
        grpTelefone.PerformLayout();
        grpAgenda.ResumeLayout(false);
        grpAgenda.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvContatos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitulo;
    private GroupBox grpContato;
    private Label lblNome;
    private TextBox txtNome;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblNascimento;
    private DateTimePicker dtpNascimento;
    private GroupBox grpTelefone;
    private Label lblTipoTelefone;
    private TextBox txtTipoTelefone;
    private Label lblNumeroTelefone;
    private TextBox txtNumeroTelefone;
    private CheckBox chkPrincipal;
    private Button btnAdicionarTelefone;
    private Button btnRemoverTelefone;
    private ListBox lstTelefones;
    private Button btnAdicionar;
    private Button btnAlterar;
    private Button btnRemover;
    private Button btnLimpar;
    private GroupBox grpAgenda;
    private TextBox txtPesquisa;
    private Button btnPesquisar;
    private Button btnListarTodos;
    private DataGridView dgvContatos;
    private Label lblTotal;
    private Button btnSair;
}
