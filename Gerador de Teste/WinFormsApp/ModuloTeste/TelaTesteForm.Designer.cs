namespace WinFormsApp.ModuloTeste
{
    partial class TelaTesteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtTitulo = new TextBox();
            txtId = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            comboBox2 = new ComboBox();
            label4 = new Label();
            chkProvaRecuperacao = new CheckBox();
            grpQuestoesSelecionadas = new GroupBox();
            scrollQuestaoTeste = new VScrollBar();
            listQuestao = new ListBox();
            btnSortearQuestoes = new Button();
            btnCancelar = new Button();
            btnGravar = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            grpQuestoesSelecionadas.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 61);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Titulo:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(91, 58);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(395, 27);
            txtTitulo.TabIndex = 1;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(91, 25);
            txtId.Name = "txtId";
            txtId.Size = new Size(79, 27);
            txtId.TabIndex = 2;
            txtId.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 104);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 3;
            label2.Text = "Disciplina:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(95, 101);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(191, 28);
            comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(314, 104);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 5;
            label3.Text = "Qtde Questões:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(430, 102);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(56, 27);
            numericUpDown1.TabIndex = 6;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(95, 154);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(191, 28);
            comboBox2.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 158);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 7;
            label4.Text = "Materia:";
            // 
            // chkProvaRecuperacao
            // 
            chkProvaRecuperacao.AutoSize = true;
            chkProvaRecuperacao.Location = new Point(314, 157);
            chkProvaRecuperacao.Name = "chkProvaRecuperacao";
            chkProvaRecuperacao.Size = new Size(176, 24);
            chkProvaRecuperacao.TabIndex = 9;
            chkProvaRecuperacao.Text = "Prova de Recuperação";
            chkProvaRecuperacao.UseVisualStyleBackColor = true;
            // 
            // grpQuestoesSelecionadas
            // 
            grpQuestoesSelecionadas.Controls.Add(scrollQuestaoTeste);
            grpQuestoesSelecionadas.Controls.Add(listQuestao);
            grpQuestoesSelecionadas.Controls.Add(btnSortearQuestoes);
            grpQuestoesSelecionadas.Location = new Point(16, 214);
            grpQuestoesSelecionadas.Name = "grpQuestoesSelecionadas";
            grpQuestoesSelecionadas.Size = new Size(478, 309);
            grpQuestoesSelecionadas.TabIndex = 10;
            grpQuestoesSelecionadas.TabStop = false;
            grpQuestoesSelecionadas.Text = "Questões Selecionadas";
            // 
            // scrollQuestaoTeste
            // 
            scrollQuestaoTeste.Location = new Point(458, 67);
            scrollQuestaoTeste.Name = "scrollQuestaoTeste";
            scrollQuestaoTeste.Size = new Size(20, 239);
            scrollQuestaoTeste.TabIndex = 13;
            // 
            // listQuestao
            // 
            listQuestao.BackColor = SystemColors.Control;
            listQuestao.BorderStyle = BorderStyle.FixedSingle;
            listQuestao.FormattingEnabled = true;
            listQuestao.ItemHeight = 20;
            listQuestao.Location = new Point(3, 66);
            listQuestao.Name = "listQuestao";
            listQuestao.Size = new Size(475, 242);
            listQuestao.TabIndex = 1;
            // 
            // btnSortearQuestoes
            // 
            btnSortearQuestoes.Location = new Point(19, 26);
            btnSortearQuestoes.Name = "btnSortearQuestoes";
            btnSortearQuestoes.Size = new Size(145, 36);
            btnSortearQuestoes.TabIndex = 0;
            btnSortearQuestoes.Text = "Sortear Questões";
            btnSortearQuestoes.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(383, 539);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 49);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.Lime;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(259, 539);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(111, 49);
            btnGravar.TabIndex = 11;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = false;
            // 
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 600);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(grpQuestoesSelecionadas);
            Controls.Add(chkProvaRecuperacao);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(txtTitulo);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaTesteForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Testes";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            grpQuestoesSelecionadas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitulo;
        private TextBox txtId;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox2;
        private Label label4;
        private CheckBox chkProvaRecuperacao;
        private GroupBox grpQuestoesSelecionadas;
        private Button btnCancelar;
        private Button btnGravar;
        private Button btnSortearQuestoes;
        private ListBox listQuestao;
        private VScrollBar scrollQuestaoTeste;
    }
}