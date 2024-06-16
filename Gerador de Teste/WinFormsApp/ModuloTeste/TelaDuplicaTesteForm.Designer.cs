namespace WinFormsApp.ModuloTeste
{
    partial class TelaDuplicaTesteForm
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
            bntCancelar = new Button();
            btnGravar = new Button();
            grpDuplicidadeQuestoesSelecionadas = new GroupBox();
            scrollDuplicidade = new VScrollBar();
            listDuplicidadeQuestao = new ListBox();
            btnDuplicidadeSortearQuestoes = new Button();
            chkDuplicadoRecuperacao = new CheckBox();
            cmbDuplicidadeMateria = new ComboBox();
            label4 = new Label();
            nudQtdeDuplicidade = new NumericUpDown();
            label3 = new Label();
            cmbDuplicacaoDisciplina = new ComboBox();
            label2 = new Label();
            txtId = new TextBox();
            txtDuplicacaoTitulo = new TextBox();
            label1 = new Label();
            grpDuplicidadeQuestoesSelecionadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtdeDuplicidade).BeginInit();
            SuspendLayout();
            // 
            // bntCancelar
            // 
            bntCancelar.BackColor = Color.FromArgb(192, 0, 0);
            bntCancelar.DialogResult = DialogResult.Cancel;
            bntCancelar.Location = new Point(423, 551);
            bntCancelar.Name = "bntCancelar";
            bntCancelar.Size = new Size(111, 49);
            bntCancelar.TabIndex = 25;
            bntCancelar.Text = "Cancelar";
            bntCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.Lime;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(299, 551);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(111, 49);
            btnGravar.TabIndex = 24;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = false;
            // 
            // grpDuplicidadeQuestoesSelecionadas
            // 
            grpDuplicidadeQuestoesSelecionadas.Controls.Add(scrollDuplicidade);
            grpDuplicidadeQuestoesSelecionadas.Controls.Add(listDuplicidadeQuestao);
            grpDuplicidadeQuestoesSelecionadas.Controls.Add(btnDuplicidadeSortearQuestoes);
            grpDuplicidadeQuestoesSelecionadas.Location = new Point(56, 226);
            grpDuplicidadeQuestoesSelecionadas.Name = "grpDuplicidadeQuestoesSelecionadas";
            grpDuplicidadeQuestoesSelecionadas.Size = new Size(478, 309);
            grpDuplicidadeQuestoesSelecionadas.TabIndex = 23;
            grpDuplicidadeQuestoesSelecionadas.TabStop = false;
            grpDuplicidadeQuestoesSelecionadas.Text = "Questões Selecionadas";
            // 
            // scrollDuplicidade
            // 
            scrollDuplicidade.Location = new Point(458, 67);
            scrollDuplicidade.Name = "scrollDuplicidade";
            scrollDuplicidade.Size = new Size(20, 239);
            scrollDuplicidade.TabIndex = 13;
            // 
            // listDuplicidadeQuestao
            // 
            listDuplicidadeQuestao.BackColor = SystemColors.Control;
            listDuplicidadeQuestao.BorderStyle = BorderStyle.FixedSingle;
            listDuplicidadeQuestao.FormattingEnabled = true;
            listDuplicidadeQuestao.ItemHeight = 20;
            listDuplicidadeQuestao.Location = new Point(3, 66);
            listDuplicidadeQuestao.Name = "listDuplicidadeQuestao";
            listDuplicidadeQuestao.Size = new Size(475, 242);
            listDuplicidadeQuestao.TabIndex = 1;
            // 
            // btnDuplicidadeSortearQuestoes
            // 
            btnDuplicidadeSortearQuestoes.Location = new Point(19, 26);
            btnDuplicidadeSortearQuestoes.Name = "btnDuplicidadeSortearQuestoes";
            btnDuplicidadeSortearQuestoes.Size = new Size(145, 36);
            btnDuplicidadeSortearQuestoes.TabIndex = 0;
            btnDuplicidadeSortearQuestoes.Text = "Sortear Questões";
            btnDuplicidadeSortearQuestoes.UseVisualStyleBackColor = true;
            // 
            // chkDuplicadoRecuperacao
            // 
            chkDuplicadoRecuperacao.AutoSize = true;
            chkDuplicadoRecuperacao.Location = new Point(354, 169);
            chkDuplicadoRecuperacao.Name = "chkDuplicadoRecuperacao";
            chkDuplicadoRecuperacao.Size = new Size(176, 24);
            chkDuplicadoRecuperacao.TabIndex = 22;
            chkDuplicadoRecuperacao.Text = "Prova de Recuperação";
            chkDuplicadoRecuperacao.UseVisualStyleBackColor = true;
            // 
            // cmbDuplicidadeMateria
            // 
            cmbDuplicidadeMateria.FormattingEnabled = true;
            cmbDuplicidadeMateria.Location = new Point(135, 166);
            cmbDuplicidadeMateria.Name = "cmbDuplicidadeMateria";
            cmbDuplicidadeMateria.Size = new Size(191, 28);
            cmbDuplicidadeMateria.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 170);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 20;
            label4.Text = "Materia:";
            // 
            // nudQtdeDuplicidade
            // 
            nudQtdeDuplicidade.Location = new Point(470, 114);
            nudQtdeDuplicidade.Name = "nudQtdeDuplicidade";
            nudQtdeDuplicidade.Size = new Size(56, 27);
            nudQtdeDuplicidade.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(354, 116);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 18;
            label3.Text = "Qtde Questões:";
            // 
            // cmbDuplicacaoDisciplina
            // 
            cmbDuplicacaoDisciplina.FormattingEnabled = true;
            cmbDuplicacaoDisciplina.Location = new Point(135, 113);
            cmbDuplicacaoDisciplina.Name = "cmbDuplicacaoDisciplina";
            cmbDuplicacaoDisciplina.Size = new Size(191, 28);
            cmbDuplicacaoDisciplina.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 116);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 16;
            label2.Text = "Disciplina:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(131, 37);
            txtId.Name = "txtId";
            txtId.Size = new Size(79, 27);
            txtId.TabIndex = 15;
            txtId.Visible = false;
            // 
            // txtDuplicacaoTitulo
            // 
            txtDuplicacaoTitulo.Location = new Point(131, 70);
            txtDuplicacaoTitulo.Name = "txtDuplicacaoTitulo";
            txtDuplicacaoTitulo.Size = new Size(395, 27);
            txtDuplicacaoTitulo.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 73);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 13;
            label1.Text = "Titulo:";
            // 
            // TelaDuplicaTesteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 637);
            Controls.Add(bntCancelar);
            Controls.Add(btnGravar);
            Controls.Add(grpDuplicidadeQuestoesSelecionadas);
            Controls.Add(chkDuplicadoRecuperacao);
            Controls.Add(cmbDuplicidadeMateria);
            Controls.Add(label4);
            Controls.Add(nudQtdeDuplicidade);
            Controls.Add(label3);
            Controls.Add(cmbDuplicacaoDisciplina);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(txtDuplicacaoTitulo);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaDuplicaTesteForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Duplicação de Teste";
            grpDuplicidadeQuestoesSelecionadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudQtdeDuplicidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bntCancelar;
        private Button btnGravar;
        private GroupBox grpDuplicidadeQuestoesSelecionadas;
        private VScrollBar scrollDuplicidade;
        private ListBox listDuplicidadeQuestao;
        private Button btnDuplicidadeSortearQuestoes;
        private CheckBox chkDuplicadoRecuperacao;
        private ComboBox cmbDuplicidadeMateria;
        private Label label4;
        private NumericUpDown nudQtdeDuplicidade;
        private Label label3;
        private ComboBox cmbDuplicacaoDisciplina;
        private Label label2;
        private TextBox txtId;
        private TextBox txtDuplicacaoTitulo;
        private Label label1;
    }
}