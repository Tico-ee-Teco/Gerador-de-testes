namespace WinFormsApp.ModuloTeste
{
    partial class TelaVisualizaTesteForm
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
            label2 = new Label();
            label3 = new Label();
            txtTitulo = new TextBox();
            txtDisciplina = new TextBox();
            txtMateria = new TextBox();
            grpQuestoesSelecionadas = new GroupBox();
            listQuestoes = new ListBox();
            btnFechar = new Button();
            grpQuestoesSelecionadas.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 51);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Titulo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 114);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Disciplina:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 171);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 2;
            label3.Text = "Materia:";
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = SystemColors.Control;
            txtTitulo.BorderStyle = BorderStyle.None;
            txtTitulo.Enabled = false;
            txtTitulo.Location = new Point(104, 51);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(279, 20);
            txtTitulo.TabIndex = 3;
            // 
            // txtDisciplina
            // 
            txtDisciplina.BackColor = SystemColors.Control;
            txtDisciplina.BorderStyle = BorderStyle.None;
            txtDisciplina.Enabled = false;
            txtDisciplina.Location = new Point(104, 114);
            txtDisciplina.Name = "txtDisciplina";
            txtDisciplina.Size = new Size(279, 20);
            txtDisciplina.TabIndex = 4;
            // 
            // txtMateria
            // 
            txtMateria.BackColor = SystemColors.Control;
            txtMateria.BorderStyle = BorderStyle.None;
            txtMateria.Enabled = false;
            txtMateria.Location = new Point(104, 171);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(279, 20);
            txtMateria.TabIndex = 5;
            // 
            // grpQuestoesSelecionadas
            // 
            grpQuestoesSelecionadas.Controls.Add(listQuestoes);
            grpQuestoesSelecionadas.Location = new Point(21, 234);
            grpQuestoesSelecionadas.Name = "grpQuestoesSelecionadas";
            grpQuestoesSelecionadas.Size = new Size(434, 312);
            grpQuestoesSelecionadas.TabIndex = 6;
            grpQuestoesSelecionadas.TabStop = false;
            grpQuestoesSelecionadas.Text = "Questões Selecionadas";
            // 
            // listQuestoes
            // 
            listQuestoes.BackColor = SystemColors.Control;
            listQuestoes.BorderStyle = BorderStyle.None;
            listQuestoes.Dock = DockStyle.Fill;
            listQuestoes.FormattingEnabled = true;
            listQuestoes.ItemHeight = 20;
            listQuestoes.Location = new Point(3, 23);
            listQuestoes.Name = "listQuestoes";
            listQuestoes.Size = new Size(428, 286);
            listQuestoes.TabIndex = 0;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.FromArgb(192, 0, 0);
            btnFechar.DialogResult = DialogResult.Cancel;
            btnFechar.Location = new Point(379, 577);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(111, 49);
            btnFechar.TabIndex = 13;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            // 
            // TelaVisualizaTesteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 629);
            Controls.Add(btnFechar);
            Controls.Add(grpQuestoesSelecionadas);
            Controls.Add(txtMateria);
            Controls.Add(txtDisciplina);
            Controls.Add(txtTitulo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaVisualizaTesteForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Visualização de Testes";
            grpQuestoesSelecionadas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitulo;
        private TextBox txtDisciplina;
        private TextBox txtMateria;
        private GroupBox grpQuestoesSelecionadas;
        private Button btnFechar;
        private ListBox listQuestoes;
    }
}