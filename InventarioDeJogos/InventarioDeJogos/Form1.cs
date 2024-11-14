using System;
using System.Linq; // Add this directive
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private Inventario inventario;
    private TextBox textBoxMensagens;

    public Form1()
    {
        InitializeComponent();
        inventario = new Inventario();
        InicializarControles();
    }

    private void InicializarControles()
    {
        // Ajustar o tamanho do formulário
        this.Size = new System.Drawing.Size(870, 600);

        // Definir a fonte padrão maior
        Font fonteMaior = new Font("Arial", 14);

        // Adicionar Label para o tipo de item
        Label labelTipo = new Label();
        labelTipo.Text = "Escolha TIPO do item";
        labelTipo.Location = new System.Drawing.Point(17, 20);
        labelTipo.AutoSize = true; // Ajustar o tamanho automaticamente
        labelTipo.Font = fonteMaior;
        this.Controls.Add(labelTipo);

        // Adicionar ComboBox para selecionar o tipo de item
        ComboBox comboBoxTipo = new ComboBox();
        comboBoxTipo.Items.AddRange(new string[] { "Arma", "Poção", "Armadura" });
        comboBoxTipo.Location = new System.Drawing.Point(20, 50);
        comboBoxTipo.Name = "comboBoxTipo";
        comboBoxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxTipo.Size = new System.Drawing.Size(200, 40); // Ajustar o tamanho do ComboBox
        comboBoxTipo.Font = fonteMaior;
        comboBoxTipo.SelectedIndexChanged += ComboBoxTipo_SelectedIndexChanged;
        this.Controls.Add(comboBoxTipo);

        // Adicionar Label para o nome do item
        Label labelNome = new Label();
        labelNome.Text = "Escolha o Item";
        labelNome.Location = new System.Drawing.Point(17, 84);
        labelNome.AutoSize = true; // Ajustar o tamanho automaticamente
        labelNome.Font = fonteMaior;
        labelNome.Name = "labelNome";
        this.Controls.Add(labelNome);

        // Adicionar ComboBox para selecionar o nome do item
        ComboBox comboBoxNome = new ComboBox();
        comboBoxNome.Location = new System.Drawing.Point(20, 110);
        comboBoxNome.Name = "comboBoxNome";
        comboBoxNome.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxNome.Font = fonteMaior;
        comboBoxNome.Size = new System.Drawing.Size(200, 40); // Ajustar o tamanho do ComboBox
        this.Controls.Add(comboBoxNome);

        // Adicionar botão para adicionar o item ao inventário
        Button btnAdicionar = new Button();
        btnAdicionar.Location = new System.Drawing.Point(20, 150);
        btnAdicionar.Name = "Adicionar";
        btnAdicionar.Text = "Adicionar Item";
        btnAdicionar.Font = fonteMaior;
        btnAdicionar.Size = new System.Drawing.Size(200, 40); // Ajustar o tamanho do botão
        btnAdicionar.Click += btnAdicionar_Click;
        this.Controls.Add(btnAdicionar);

        // Adicionar DataGridView para exibir o inventário
        DataGridView dataGridView1 = new DataGridView();
        dataGridView1.Location = new System.Drawing.Point(230, 20);
        dataGridView1.Size = new System.Drawing.Size(600, 510);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.Font = fonteMaior;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecionar a linha inteira
        dataGridView1.ColumnHeadersHeight = 40; // Ajustar a altura da linha de cabeçalho
        dataGridView1.ReadOnly = true; // Tornar o DataGridView somente leitura
        dataGridView1.AllowUserToAddRows = false; // Desativar a adição de novas linhas
        this.Controls.Add(dataGridView1);

        // Adicionar botão para remover o item selecionado
        Button btnRemover = new Button();
        btnRemover.Location = new System.Drawing.Point(20, 190);
        btnRemover.Name = "btnRemover";
        btnRemover.Text = "Remover Item";
        btnRemover.Font = fonteMaior;
        btnRemover.Size = new System.Drawing.Size(200, 40); // Ajustar o tamanho do botão
        btnRemover.Click += btnRemover_Click;
        this.Controls.Add(btnRemover);

        // Adicionar botão para usar o item selecionado
        Button btnUsar = new Button();
        btnUsar.Location = new System.Drawing.Point(20, 230);
        btnUsar.Name = "btnUsar";
        btnUsar.Text = "Usar Item";
        btnUsar.Font = fonteMaior;
        btnUsar.Size = new System.Drawing.Size(200, 40); // Ajustar o tamanho do botão
        btnUsar.Click += btnUsar_Click;
        this.Controls.Add(btnUsar);

        // Adicionar Label para "Suas interações"
        Label labelInteracoes = new Label();
        labelInteracoes.Text = "Suas interações";
        labelInteracoes.Location = new System.Drawing.Point(20, 280);
        labelInteracoes.AutoSize = true;
        labelInteracoes.Font = fonteMaior;
        this.Controls.Add(labelInteracoes);

        // Adicionar TextBox para exibir mensagens interativas OUTPUT LOG
        textBoxMensagens = new TextBox();
        textBoxMensagens.Location = new System.Drawing.Point(20, 310);
        textBoxMensagens.Name = "textBoxMensagens";
        textBoxMensagens.Size = new System.Drawing.Size(200, 220);
        textBoxMensagens.Multiline = true;
        textBoxMensagens.ReadOnly = true;
        textBoxMensagens.Font = new Font("Arial", 11); // Fonte menor
        textBoxMensagens.BackColor = SystemColors.Control; // Manter a cor de fundo padrão
        textBoxMensagens.ForeColor = Color.Black; // Manter a cor do texto preta
        textBoxMensagens.ScrollBars = ScrollBars.Vertical; // Adicionar barra de rolagem vertical
        textBoxMensagens.Enter += (s, e) => { this.ActiveControl = null; }; // Evitar que o TextBox receba foco
        this.Controls.Add(textBoxMensagens);
    }

    // Evento de mudança de seleção do ComboBox de tipo de item
    private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox comboBoxTipo = (ComboBox)sender;
        ComboBox comboBoxNome = (ComboBox)this.Controls["comboBoxNome"];
        Label labelNome = (Label)this.Controls["labelNome"];

        comboBoxNome.Items.Clear();

        // Atualizar o texto da label e adicionar itens ao ComboBox com base no tipo selecionado
        switch (comboBoxTipo.SelectedItem.ToString())
        {
            case "Arma":
                comboBoxNome.Items.AddRange(new string[] { "Dragon Slayer", "Gorehowl", "Thori'dal" });
                labelNome.Text = "Escolha sua arma";
                break;
            case "Poção":
                comboBoxNome.Items.AddRange(new string[] { "Poção de Cura", "Poção de Mana" });
                labelNome.Text = "Escolha sua poção";
                break;
            case "Armadura":
                comboBoxNome.Items.AddRange(new string[] { "Armadura de Couro", "Armadura de Ferro" });
                labelNome.Text = "Escolha sua armadura";
                break;
            default:
                labelNome.Text = "Escolha sua arma ou poção ou armadura";
                break;
        }

        if (comboBoxNome.Items.Count > 0)
        {
            comboBoxNome.SelectedIndex = 0; // Definir o item padrão
        }
    }

    // Evento de clique do botão Adicionar Item
    private void btnAdicionar_Click(object sender, EventArgs e)
    {
        // Obter os valores dos controles
        ComboBox comboBoxTipo = (ComboBox)this.Controls["comboBoxTipo"];
        ComboBox comboBoxNome = (ComboBox)this.Controls["comboBoxNome"];

        // Verificar se um tipo e um nome foram selecionados
        if (comboBoxTipo.SelectedItem == null)
        {
            textBoxMensagens.AppendText("Nenhum tipo selecionado.\r\n\r\n");
            return;
        }

        if (comboBoxNome.SelectedItem == null)
        {
            textBoxMensagens.AppendText("Nenhum item selecionado.\r\n\r\n");
            return;
        }

        // Obter os valores dos ComboBoxes
        string tipo = comboBoxTipo.SelectedItem.ToString();
        string nome = comboBoxNome.SelectedItem.ToString();

        // Definir valores específicos para cada item
        double peso = 0;
        double valor = 0;
        int atributo = 0;

        switch (nome)
        {
            case "Dragon Slayer":
                peso = 30;
                valor = 100;
                atributo = 50; // Dano
                break;
            case "Gorehowl":
                peso = 40;
                valor = 120;
                atributo = 60; // Dano
                break;
            case "Thori'dal":
                peso = 20;
                valor = 90;
                atributo = 40; // Dano
                break;
            case "Poção de Cura":
                peso = 10;
                valor = 50;
                atributo = 30; // Cura
                break;
            case "Poção de Mana":
                peso = 10;
                valor = 60;
                atributo = 40; // Mana
                break;
            case "Armadura de Couro":
                peso = 50;
                valor = 150;
                atributo = 20; // Defesa
                break;
            case "Armadura de Ferro":
                peso = 70;
                valor = 200;
                atributo = 40; // Defesa
                break;
        }

        // Criar o item com base no tipo selecionado
        Item item = null;
        switch (tipo)
        {
            case "Arma":
                item = new Item.Arma(nome, peso, valor, atributo);
                break;
            case "Poção":
                item = new Item.Pocao(nome, peso, valor, atributo);
                break;
            case "Armadura":
                item = new Item.Armadura(nome, peso, valor, atributo);
                break;
        }

        // Adicionar o item ao inventário e atualizar o DataGridView
        if (item != null)
        {
            inventario.AdicionarItem(item);
            AtualizarDataGridView();
            textBoxMensagens.AppendText($"Item {item.Nome} adicionado ao inventário.\r\n\r\n");

            // Verificar se o item adicionado é "Gorehowl" e exibir a mensagem específica
            if (nome == "Gorehowl")
            {
                textBoxMensagens.AppendText("O machado de guerra de Grom Hellscream, famoso por sua enorme força e ligação com a história dos orcs, outrora empunhado por Garrosh.\r\n\r\n");
            }
            if(nome == "Thori'dal")
            {
                textBoxMensagens.AppendText("O arco de Thori'dal, a Fúria das Estrelas, é um dos artefatos mais poderosos de Quel'Thalas, capaz de disparar flechas mágicas sem fim.\r\n\r\n");
            }
            if(nome == "Dragon Slayer")
            {
                textBoxMensagens.AppendText("A Dragon Slayer representa o peso da batalha contínua de seu antigo portador Guts e sua luta interminável contra o destino.\r\n\r\n");
            }
        }
    }

    // Evento de clique do botão Remover Item
    private void btnRemover_Click(object sender, EventArgs e)
    {
        DataGridView dataGridView1 = (DataGridView)this.Controls["dataGridView1"];
        if (dataGridView1.SelectedRows.Count > 0)
        {
            // Retrieve the original item from the Tag property
            var item = (Item)dataGridView1.SelectedRows[0].Tag;
            inventario.RemoverItem(item);
            AtualizarDataGridView();
            textBoxMensagens.AppendText($"Item {item.Nome} removido do inventário.\r\n\r\n");
        }
        else
        {
            textBoxMensagens.AppendText("Nenhum item selecionado para remover.\r\n\r\n");
        }
    }

    // Evento de clique do botão Usar Item
    private void btnUsar_Click(object sender, EventArgs e)
    {
        DataGridView dataGridView1 = (DataGridView)this.Controls["dataGridView1"];
        if (dataGridView1.SelectedRows.Count > 0)
        {
            // Retrieve the original item from the Tag property
            var item = (Item)dataGridView1.SelectedRows[0].Tag;
            item.Usar();
            inventario.RemoverItem(item);
            AtualizarDataGridView();
            textBoxMensagens.AppendText($"Item {item.Nome} usado.\r\n\r\n");
        }
        else
        {
            textBoxMensagens.AppendText("Nenhum item selecionado para usar.\r\n\r\n");
        }
    }

    // Remover o texto de placeholder quando o TextBox ganha foco
    private void RemovePlaceholderText(TextBox textBox, string placeholder)
    {
        if (textBox.Text == placeholder)
        {
            textBox.Text = "";
            textBox.ForeColor = System.Drawing.Color.Black;
        }
    }

    // Definir o texto de placeholder quando o TextBox perde foco
    private void SetPlaceholderText(TextBox textBox, string placeholder)
    {
        if (string.IsNullOrWhiteSpace(textBox.Text))
        {
            textBox.Text = placeholder;
            textBox.ForeColor = System.Drawing.Color.Gray;
        }
    }

    // Atualizar o DataGridView com os itens do inventário
    private void AtualizarDataGridView()
    {
        DataGridView dataGridView1 = (DataGridView)this.Controls["dataGridView1"];
        dataGridView1.Rows.Clear();
        dataGridView1.Columns.Clear();

        dataGridView1.Columns.Add("Qt", "Qt");
        dataGridView1.Columns.Add("Nome", "Nome");
        dataGridView1.Columns.Add("Peso", "Peso");
        dataGridView1.Columns.Add("Valor", "Valor");
        dataGridView1.Columns.Add("Propriedade", "Propriedade");

        // Ajustar a largura das colunas
        dataGridView1.Columns["Qt"].Width = 50;
        dataGridView1.Columns["Nome"].Width = 200;
        dataGridView1.Columns["Peso"].Width = 70;
        dataGridView1.Columns["Valor"].Width = 70;
        dataGridView1.Columns["Propriedade"].Width = 150;

        foreach (var item in inventario.Itens)
        {
            var propriedade = item is Item.Arma ? $"Dano: {((Item.Arma)item).Dano}" :
                             item is Item.Armadura ? $"Defesa: {((Item.Armadura)item).Defesa}" :
                             item is Item.Pocao ? $"Cura: {((Item.Pocao)item).Cura}" : "";

            var row = new DataGridViewRow();
            row.CreateCells(dataGridView1, item.Quantidade, item.Nome, item.Peso, item.Valor, propriedade);
            row.Tag = item; // Store the original item in the Tag property
            dataGridView1.Rows.Add(row);
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Método de carregamento do formulário, atualmente vazio
    }
}
